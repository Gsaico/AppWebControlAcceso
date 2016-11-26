using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspinia_MVC5.Controllers;
using System.Web.Mvc;

namespace Inspinia_MVC5.Tests.Controllers
{

    [TestClass]

    public class ReporteControllerTest
    {
        [TestMethod]
        public void SearchtareoColaboradoresXDNI()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
         //PRUEBA TRATA: Prueba el método SHOWREPORT REGISTROCONTROL DE ASISTENCIA, se prueba su funcionamiento

            // Arrange
            var controller = new ReportesController();
            string DNI = "11111111";
            string Mes = "09";
            string año = "2016";
            // Act
            //ViewResult result = controller.ShowReportRegistroControlDeAsistenciasXDNI() as ViewResult;
            var result = controller.SearchTareoColaboradoresXDNI(DNI, Mes, año);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SearchRegistroControlDeAsistenciasXDNI()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
         //PRUEBA TRATA: Prueba el método SHOWREPORT REGISTROCONTROL DE ASISTENCIA, se prueba su funcionamiento

            // Arrange
            var controller = new ReportesController();
            string DNI = "11111111";
            string Mes = "09";
            string año = "2016";
            // Act
            //ViewResult result = controller.ShowReportRegistroControlDeAsistenciasXDNI() as ViewResult;
            var result = controller.SearchRegistroControlDeAsistenciasXDNI(DNI, Mes, año);

            // Assert
            Assert.IsNotNull(result);
        }

    }
}