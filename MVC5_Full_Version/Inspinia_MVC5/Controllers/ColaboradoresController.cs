using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5.Models;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using Inspinia_MVC5.PDF;
using static System.Net.Mime.MediaTypeNames;

namespace Inspinia_MVC5.Controllers
{
    [Authorize]//Para solicitar autenticacion
    public class ColaboradoresController : Controller
    {
        private IDCHECKDBEntities db = new IDCHECKDBEntities();

        private static Byte[] _MyGlobalVariable;

        //public ActionResult ListadoColaboradores()
        //{
        //    ViewBag.ListColaboradores = db.Colaboradores.ToList();

        //    return View();
        //}

      
        public ActionResult FotocheckColaboradorPDF(string COD_Colaborador)
        {

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/CrystalReportFotocheck.rpt")));
            rd.SetDataSource(db.Colaboradores.Select(p => new
            {
                COD_Colaborador = p.COD_Colaborador,
                ApellidoPaterno = p.ApellidoPaterno,
                ApellidoMaterno = p.ApellidoMaterno,
                Nombres = p.Nombres,
                Foto = p.Foto

            }).Where(p => p.COD_Colaborador == COD_Colaborador));

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);


            return File(stream, "application/pdf");
            // return File(stream, "application/pdf", "FotocheckColaboradores.pdf");
        }
   

        public ActionResult ConvertirAImagen(string COD_Colaborador)
        {
            var imagenMunicipio = db.Colaboradores.Where(x => x.COD_Colaborador == COD_Colaborador).FirstOrDefault();
            if (imagenMunicipio != null)
            {
                if (imagenMunicipio.Foto != null)
                {
                    return File(imagenMunicipio.Foto, "image/jpeg");
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }


        }

        

        public ActionResult EmptyPage()
        {

            return View();


        }
       
        public  ActionResult SearchImprimir(string id)
        {

            return View();

        }

        public async Task<ActionResult> Search(string SearchStringDNI, string SearchStringApePaterno, string SearchStringApeMaterno, string SearchStringNombres, string Areasx)
        {

            ViewBag.Areasx = new SelectList(db.Areas, "ID_Area", "NombreArea");
          

            var colaboradoresquery = from m in db.Colaboradores select m;

            //if (String.IsNullOrEmpty(SearchStringDNI) && String.IsNullOrEmpty(SearchStringApePaterno) && String.IsNullOrEmpty(SearchStringApeMaterno) && String.IsNullOrEmpty(SearchStringNombres) && String.IsNullOrEmpty(Areasx))
            //{
            //    return View(null);
            //}
            //else
            //{
         
            if (!String.IsNullOrEmpty(SearchStringDNI))
            {
                colaboradoresquery = colaboradoresquery.Where(s => s.COD_Colaborador.Contains(SearchStringDNI));
                
            }

            if (!String.IsNullOrEmpty(SearchStringApePaterno))
            {
                colaboradoresquery = colaboradoresquery.Where(s => s.ApellidoPaterno.Contains(SearchStringApePaterno));
            }

            if (!String.IsNullOrEmpty(SearchStringApeMaterno))
            {
                colaboradoresquery = colaboradoresquery.Where(s => s.ApellidoMaterno.Contains(SearchStringApeMaterno));
            }

            if (!String.IsNullOrEmpty(SearchStringNombres))
            {
                colaboradoresquery = colaboradoresquery.Where(s => s.Nombres.Contains(SearchStringNombres));
            }

            if (!String.IsNullOrEmpty(Areasx))
            {
                int id;
                id = Convert.ToInt32(Areasx);

                colaboradoresquery = colaboradoresquery.Where(x => x.ID_Area == id);
            }

            if (colaboradoresquery.Count() != 0)
            {

                ViewBag.datos = "hay datos";
            }
            else
            {
                ViewBag.datos = "No hay datos";
            }
            
           
            return View(await colaboradoresquery.ToListAsync());
        }


        // GET: Colaboradores
        public ActionResult Index()
        {
            var colaboradores = db.Colaboradores.Where(c=>c.Estado ==true).Include(c => c.Areas).Include(c => c.Empresas);
            ViewBag.ListaColaboradores = colaboradores;
            return View( colaboradores.ToList());
        }

  
        // GET: Colaboradores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaboradores.Find(id);
           

            if (colaboradores == null)
            {
               // return HttpNotFound();
                return RedirectToAction("EmptyPage", "Colaboradores");
            }
            ViewBag.DetalleColaborador = colaboradores;
            return View(colaboradores);
        }

        // GET: Colaboradores/Create
        public ActionResult Create()
        {
            ViewBag.ID_Area = new SelectList(db.Areas, "ID_Area", "NombreArea");
            ViewBag.COD_Empresa = new SelectList(db.Empresas, "COD_Empresa", "RazonSocial");
            
            return View();
        }

        // POST: Colaboradores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "COD_Colaborador,COD_Empresa,ID_Area,ApellidoPaterno,ApellidoMaterno,Nombres,FechaNacimiento,FechaContratacion,FechaIngresoReingreso,FechaCese,COD_Departamento,COD_Provincia,COD_Distrito,Direccion,Foto,Cargo,Estado")] Colaboradores colaboradores, HttpPostedFileBase FotoColaborador)
        {
            if (FotoColaborador != null && FotoColaborador.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(FotoColaborador.InputStream))
                {
                    imageData = binaryReader.ReadBytes(FotoColaborador.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                colaboradores.Foto = imageData;
            }

            Colaboradores colaboradoresx = await db.Colaboradores.FindAsync(colaboradores.COD_Colaborador);
            if (colaboradoresx != null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Error El DNI que ud desea ingresar ya existe en la Base de Datos!');</script>");
                // return Content("<script language='javascript' type='text/javascript'> toastr.success('Without any options', 'Simple notification!')</script>");
            }

            else
            {
                if (ModelState.IsValid)
                {
                    db.Colaboradores.Add(colaboradores);
                    await db.SaveChangesAsync();
                    ViewBag.MensajeAlerta = "El colaborador se agrego correctamente a la Base de Datos";
                    return RedirectToAction("Index");
                }

                ViewBag.ID_Area = new SelectList(db.Areas, "ID_Area", "NombreArea", colaboradores.ID_Area);
                ViewBag.COD_Empresa = new SelectList(db.Empresas, "COD_Empresa", "RazonSocial", colaboradores.COD_Empresa);
                return View(colaboradores);
            }

        }

        // GET: Colaboradores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaboradores.Find(id);
                    
            if (colaboradores == null)
            {
                //  return HttpNotFound();
                return RedirectToAction("EmptyPage", "Colaboradores");
            }
            else
            {
                ColaboradoresController._MyGlobalVariable = colaboradores.Foto;
            }

            ViewBag.ID_Area = new SelectList(db.Areas, "ID_Area", "NombreArea", colaboradores.ID_Area);
            ViewBag.COD_Empresa = new SelectList(db.Empresas, "COD_Empresa", "RazonSocial", colaboradores.COD_Empresa);

            ViewBag.DetalleColaborador = colaboradores;
            return View(colaboradores);
        }

        // POST: Colaboradores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "COD_Colaborador,COD_Empresa,ID_Area,ApellidoPaterno,ApellidoMaterno,Nombres,FechaNacimiento,FechaContratacion,FechaIngresoReingreso,FechaCese,COD_Departamento,COD_Provincia,COD_Distrito,Direccion,Cargo,Estado")] Colaboradores colaboradores, HttpPostedFileBase FotoColaborador)
        {
            if (FotoColaborador != null && FotoColaborador.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(FotoColaborador.InputStream))
                {
                    imageData = binaryReader.ReadBytes(FotoColaborador.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                colaboradores.Foto = imageData;
            }
            else
            {

                colaboradores.Foto = ColaboradoresController._MyGlobalVariable;


            }

            if (ModelState.IsValid)
            {
                db.Entry(colaboradores).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewBag.MensajeAlerta = "Los cambios se agregaron correctamente a la Base de Datos";
                return RedirectToAction("Index");
            }
            ViewBag.ID_Area = new SelectList(db.Areas, "ID_Area", "NombreArea", colaboradores.ID_Area);
            ViewBag.COD_Empresa = new SelectList(db.Empresas, "COD_Empresa", "RazonSocial", colaboradores.COD_Empresa);

            ViewBag.DetalleColaboradorAgregado = colaboradores;
            return View(colaboradores);
        }

        // GET: Colaboradores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            Colaboradores colaboradores =  db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }

            else
            {
                RegistrosDiarios registrodiarios = db.RegistrosDiarios.Where(r => r.COD_Colaborador == id).FirstOrDefault();

                if (registrodiarios == null)
                {//no existe registro de ingresoso salidas
                    ViewBag.mensajedelete = "¿Estás seguro que quieres eliminar los datos del colaborador?";
                    ViewBag.estadobotoneleiminar = "enabled";
                }
                else
                {

                    ViewBag.mensajedelete = "Los datos del colaborador no se pueden eliminar, ya existe información registrada";

                    ViewBag.estadobotoneleiminar = "disabled";
                }

            }



            ViewBag.DetalleColaborador = colaboradores;


            return View(colaboradores);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Colaboradores colaboradores =  db.Colaboradores.Find(id);
            db.Colaboradores.Remove(colaboradores);
            db.SaveChanges();
            ViewBag.MensajeAlerta = "El colaborador se elimino de la Base de Datos";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}