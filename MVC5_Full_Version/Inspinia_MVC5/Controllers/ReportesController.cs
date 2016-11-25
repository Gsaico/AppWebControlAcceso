using CrystalDecisions.CrystalReports.Engine;
using Inspinia_MVC5.cnx;
using Inspinia_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    [Authorize]
    public class ReportesController : Controller
    {
        private IDCHECKDBEntities db = new IDCHECKDBEntities();
        public ActionResult SearchRegistroControlDeAsistenciasXDNI(string COD_Colaborador)
        {

            ViewBag.COD_Colaborador = COD_Colaborador;

            return View();

        }

       

       
        [HttpGet]
        public ActionResult ImprimirReportRegistroControlDeAsistenciasXDNI(string COD_Colaborador)
        {
            //creamos nuestro objeto
            Conexion oConexion = new Conexion();

            //ejecutamos el metodo
            oConexion.getData();
            String ConnStr = "data source= " + oConexion.servidor + ";initial catalog=" + oConexion.baseDeDatos + ";persist security info=True;user id=" + oConexion.usuario + ";password=" + oConexion.password;

            SqlConnection myConnection = new SqlConnection(ConnStr);
            DataTable dt = new DataTable();
            try
            {
                myConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_RegistroControlDeAsistenciasXDNI", myConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@CodColaborador", COD_Colaborador.ToString());

                da.Fill(dt);
                myConnection.Close();

            }
            catch (Exception e)
            {


            }
            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reports/CrystalReportRegistroControlDeAsistenciasXDNI.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

           // return PartialView(File(stream, "application/pdf"));
            return File(stream, "application/pdf");
            // return File(stream, "application/pdf", "FotocheckColaboradores.pdf");
        }
        public ActionResult VistReportNumeroColaboradoresEnLasInstalacionesHoy()
        {
                     

            return View();

        }


        [HttpGet]
        public ActionResult ImprimirReportNumeroColaboradoresEnLasInstalacionesHoy()
        {
            //creamos nuestro objeto
            Conexion oConexion = new Conexion();

            //ejecutamos el metodo
            oConexion.getData();
            String ConnStr = "data source= " + oConexion.servidor + ";initial catalog=" + oConexion.baseDeDatos + ";persist security info=True;user id=" + oConexion.usuario + ";password=" + oConexion.password;

            SqlConnection myConnection = new SqlConnection(ConnStr);
            DataTable dt = new DataTable();
            try
            {
                myConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NumeroColaboradoresEnLasInstalacionesHoy", myConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
               

                da.Fill(dt);
                myConnection.Close();

            }
            catch (Exception e)
            {


            }
            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reports/CrystalReportDSNumeroColaboradoresEnLasInstalacionesHoy.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            // return PartialView(File(stream, "application/pdf"));
            return File(stream, "application/pdf");
            // return File(stream, "application/pdf", "FotocheckColaboradores.pdf");
        }
 

    }
}