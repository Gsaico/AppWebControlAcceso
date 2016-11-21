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
            var controller = new ReportesController() ;

            // Act
            //ViewResult result = controller.ShowReportRegistroControlDeAsistenciasXDNI() as ViewResult;
            var result = controller.ShowReportRegistroControlDeAsistenciasXDNI()  as RedirectResult;
            
            // Assert
            Assert.IsNotNull(result.Url);
        }
        [TestMethod]
        public void ShowReportNumeroColaboradoresEnLasInstalacionesHoy()
        {
            // Arrange
            var controller = new ReportesController();

            // Act
            //ViewResult result = controller.ShowReportRegistroControlDeAsistenciasXDNI() as ViewResult;
            var result = controller.ShowReportNumeroColaboradoresEnLasInstalacionesHoy() as RedirectResult;

            // Assert
            Assert.IsNotNull(result.Url);
        }
    }
}
