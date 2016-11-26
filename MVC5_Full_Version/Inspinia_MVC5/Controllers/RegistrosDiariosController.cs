//-- ===========================================================================================================
//-- Author:		Percy Saico Ccapa
//-- Create date:   10/2016
//-- Description:	Controlador creado para registrar  y administrar el ingreso y salidad de los colaboradores
//-- ===========================================================================================================

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

namespace Inspinia_MVC5.Controllers
{

    [Authorize]//para solicitar autenticacion
    public class RegistrosDiariosController : Controller
    {

        private IDCHECKDBEntities db = new IDCHECKDBEntities();
        private IDCHECKDBEntities dbx = new IDCHECKDBEntities();
      
       
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
           

        [HttpGet]
        public PartialViewResult GetColaboradoresTopCinco()
        {

            using (db)
            {
                var utltimoscolaboradores = db.RegistrosDiarios.OrderByDescending(u => u.UltimaActualizacion).Include(c => c.Colaboradores).Take(5).ToList();

                return PartialView("GetColaboradoresTopCinco", utltimoscolaboradores);
            }
        }

        [HttpGet]
        public PartialViewResult GetColaboradorDesconocido()
        {

            return PartialView("GetColaboradorDesconocido", null);

        }



        [HttpGet]
        public PartialViewResult GetColaboradorById(string COD_Colaborador)
        {
            using (db)
            {
                var GetColaboradorById = db.Colaboradores.Find(COD_Colaborador);

                //Colaboradores GetColaboradorById = new Colaboradores();
                //GetColaboradorById = db.Colaboradores.Find(COD_Colaborador);

                if (GetColaboradorById == null)
                {
                    ViewBag.desconocido = "COLABORADOR NO REGISTRADO";
                    ViewBag.FechayHora = DateTime.Now;
                    return PartialView("GetColaboradorDesconocido", null);


                }

                if (GetColaboradorById != null)
                {


                    if (GetColaboradorById.Estado == true)
                    {
                        if (DateTime.Now >= GetColaboradorById.FechaIngresoReingreso && DateTime.Now <= GetColaboradorById.FechaCese)
                        {//Hasta aqui el colaborador tiene permitido el ingreso y vigente su contrato
                            
                            var GetRegistroDiarioColaborador = dbx.RegistrosDiarios.Where(r => r.COD_Colaborador == COD_Colaborador && r.Fecha.Month == DateTime.Today.Month && r.Fecha.Year == DateTime.Today.Year && r.Fecha.Day == DateTime.Today.Day).FirstOrDefault();

                            if (GetRegistroDiarioColaborador == null)//el colaborador no registro el dia de hoy su ingreso o salida
                            {
                                //registramos su INGRESO al no existir registro alguno de su ingreso
                                //REGISTRAR INGRESO
                                RegistrosDiarios rd = new RegistrosDiarios();

                                rd.COD_Colaborador = COD_Colaborador;
                                rd.Periodo =Convert.ToString( DateTime.Today.Year);
                                rd.Fecha = DateTime.Now;
                                rd.FechaYHoraIngreso = DateTime.Now;
                                rd.FechaYHoraSalida = null;
                                rd.UltimaActualizacion = DateTime.Now;
                                // registramos su ingreso pero su salida lo ponemos en null
                                
                                db.RegistrosDiarios.Add(rd);
                                db.SaveChanges();

                                ViewBag.estado = "ACCESO REGISTRADO";
                                ViewBag.ingresosalida = "INGRESO";
                                ViewBag.FechayHora = DateTime.Now;

                            }
                            else
                            {//el colaborador registro solamente su  ingreso o registro ambos(Ingreso salida) 

                                if (GetRegistroDiarioColaborador.FechaYHoraIngreso != null && GetRegistroDiarioColaborador.FechaYHoraSalida == null)//el colaborador ya registro suingreso quedaria pendiente registrar su salida
                                {

                                    Calendarios GetCalendario = dbx.Calendarios.Where(r => r.Fecha == DateTime.Today).FirstOrDefault();
                                    if (GetCalendario != null)
                                    {    // T2 = Domingos feriados
                                        //  T1= horas extra 25% y 35%
                                        //  HN =  horas Normales sin sobretiempo
                                        double T1=0, T2=0, HN=0, HorasTrabajadas=0, descanso;
                                        descanso = 1;
                                        RegistrosDiarios registrodiariosx = db.RegistrosDiarios.Find(GetRegistroDiarioColaborador.ID_RegistroDiario);
                                        
                                        DateTime endTime = DateTime.Now;

                                        DateTime startTime = registrodiariosx.FechaYHoraIngreso;

                                        
                                        TimeSpan span = endTime.Subtract(startTime);
                                        HorasTrabajadas = span.TotalHours;

                                        if (span.TotalHours >= 6)
                                        {//con descanso
                                            HorasTrabajadas = span.TotalHours - descanso;
                                        }
                                        else
                                        {//sin descanso
                                            HorasTrabajadas = span.TotalHours;
                                        }


                                        if (GetCalendario.ID_TipoDia == "T2")
                                        {
                                            T2 = HorasTrabajadas;
                                            T1 = 0;
                                            HN = 0;
                                        }
                                        else if (GetCalendario.ID_TipoDia == "T1")
                                        {
                                            if (HorasTrabajadas >= 0.5 && HorasTrabajadas <= 8)
                                                {
                                                T2 = 0;
                                                T1 = 0;
                                                HN = HorasTrabajadas;

                                            }
                                            else if (HorasTrabajadas > 8)
                                            {
                                                T2 = 0;
                                                T1 = HorasTrabajadas - 8;
                                                HN = 8;
                                                                                               
                                            }
                                           

                                        }



                                        //REGISTRAR SALIDA
                                                                               
                                        registrodiariosx.FechaYHoraSalida = DateTime.Now;
                                        registrodiariosx.UltimaActualizacion = DateTime.Now;
                                        registrodiariosx.ID_TipoDia = GetCalendario.ID_TipoDia;
                                        registrodiariosx.HorasTrabajadas = Convert.ToDecimal(HorasTrabajadas);
                                        registrodiariosx.HN = Convert.ToDecimal(HN);
                                        registrodiariosx.T1 = Convert.ToDecimal(T1);
                                        registrodiariosx.T2 = Convert.ToDecimal(T2);

                                        db.Entry(registrodiariosx).State = EntityState.Modified;
                                        db.SaveChanges();

                                        ViewBag.estado = "ACCESO REGISTRADO";
                                        ViewBag.ingresosalida = "SALIDA";
                                        ViewBag.FechayHora = DateTime.Now;
                                    }


                                }
                                else if (GetRegistroDiarioColaborador.FechaYHoraIngreso != null && GetRegistroDiarioColaborador.FechaYHoraSalida != null)// el colaborador ya registro su ingreso y salida
                                {
                                    //MOSTRAR MENSAJE QUE YA NO PUEDE INGRESAR A LAS INSTALACIONES EL DIA DE HOY
                                    ViewBag.estado = "UD YA NO PUEDE INGRESAR A LAS INSTALACIONES EL DIA DE HOY";
                                    ViewBag.FechayHora = DateTime.Now;

                                }


                            }



                        }
                        else
                        {
                            ViewBag.estado = "ACCESO DENEGADO";
                        }
                    }
                    else
                    {
                        ViewBag.estado = "ACCESO DENEGADO";
                    }



                }

                DateTime fechayhoraactual = new DateTime();

                fechayhoraactual = DateTime.Parse(DateTime.Now.Date.ToString("dd/MM/yyyy"));


                ViewBag.FechaServidor = fechayhoraactual;
             


                return PartialView("GetColaboradorById", GetColaboradorById);


            }

        }
        [AllowAnonymous]
        public  ActionResult RegistroDiario()
        {
            //var registrosdiarios = db.RegistrosDiarios.Include(r => r.Colaboradores);
            //return View(await registrosdiarios.ToListAsync());


            return View();

        }

       

       
    }
}



//Si su acción de controlador espera un parámetro de cadena de consulta id:

//var url = '@Url.Action("Action", "Controller")?id=' + rowid;
//o si quieres pasarlo como parte de la ruta se puede usar reemplazar:

//var url = '@Url.Action("Action", "Controller", new { id = "_id_" })'
//    .replace('_id_', rowid);
//otra posibilidad si usted va a enviar una petición AJAX es que pasarla como parte del cuerpo POST:

//$.ajax({
//    url: '@Url.Action("Action", "Controller")',
//    type: 'POST',
//    data: { id: rowid },
//    success: function(result) {

//    }
//});
//o como un parámetro de cadena de consulta si está utilizando GET:

//$.ajax({
//    url: '@Url.Action("Action", "Controller")',
//    type: 'GET',
//    data: { id: rowid },
//    success: function(result) {

//    }
//});
//Todos los que suponen que su acción de controlador toma un parámetro id del curso:

//public ActionResult Action(string id)
//{
//    ...
//}