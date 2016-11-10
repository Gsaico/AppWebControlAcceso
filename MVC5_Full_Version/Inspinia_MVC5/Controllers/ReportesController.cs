using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult ShowReportRegistroControlDeAsistenciasXDNI()
        {

            // var query = db.RegistrosDiarios.Where(r => r.FechaYHora.Value.Month == 10 && r.FechaYHora.Value.Year == 2016 && r.FechaYHora.Value.Day == 25).Include(c => c.Colaboradores).ToList();


            //query = query.GroupBy(h => h.FechaYHora, h => new {h.COD_Colaborador }).ToList();

            return Redirect("../ReportViewerSSRS/ReportViewerRegistroControlDeAsistenciasXDNI.aspx");

        }
        public ActionResult ShowReportNumeroColaboradoresEnLasInstalacionesHoy()
        {

            // var query = db.RegistrosDiarios.Where(r => r.FechaYHora.Value.Month == 10 && r.FechaYHora.Value.Year == 2016 && r.FechaYHora.Value.Day == 25).Include(c => c.Colaboradores).ToList();


            //query = query.GroupBy(h => h.FechaYHora, h => new {h.COD_Colaborador }).ToList();

            return Redirect("../ReportViewerSSRS/ReportViewerNumeroColaboradoresEnLasInstalacionesHoy.aspx");

        }
    }
}