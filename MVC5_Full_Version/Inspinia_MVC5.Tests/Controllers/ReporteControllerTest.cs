using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspinia_MVC5.Controllers;
using System.Web.Mvc;

namespace Inspinia_MVC5.Tests.Controllers
{
    /// <summary>
    /// Descripción resumida de ReporteControllerTest
    /// </summary>
    [TestClass]
    public class ReporteControllerTest
    {
        [TestMethod]
        public void ShowReportRegistro()
        {
            // Arrange
            ReportesController controller = new ReportesController() ;

            // Act
            ViewResult result = controller.ShowReportRegistroControlDeAsistenciasXDNI() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ShowReportNumeroColaboradoresEnLasInstalacionesHoy()
        {//NO FUNCIONAN ESTAS PRUEBAS PORQUE NO ESTA VIGENTE LOS REPORTES
            // Arrange
            ReportesController controller = new ReportesController();

            // Act
            ViewResult result = controller.ShowReportNumeroColaboradoresEnLasInstalacionesHoy() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
