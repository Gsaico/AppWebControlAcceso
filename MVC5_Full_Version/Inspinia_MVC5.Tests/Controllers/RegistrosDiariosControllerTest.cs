using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspinia_MVC5.Models;
using Inspinia_MVC5.Controllers;

namespace Inspinia_MVC5.Tests.Controllers
{
    [TestClass]
    public class RegistrosDiariosControllerTest
    {

        [TestMethod]
        public void Test_GetColaboradoresTopCinco()
        {
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradoresTopCinco() as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        /*
        [TestMethod]
        public void Test_GetColaboradorDesconocido()
        {
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorDesconocido() as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Test_GetColaboradorById()
        {
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("1") as PartialViewResult;

            // Assert
            Assert.AreEqual("COLABORADOR NO REGISTRADO", result.ViewBag.desconocido);
            
        }
        */
        [TestMethod]
        public void Test_GetColaboradorById_ColaboradorNoregistrado()
        {//Colaborador no registrado en el sistema
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("00000000") as PartialViewResult;

            // Assert
            Assert.AreEqual("COLABORADOR NO REGISTRADO", result.ViewBag.desconocido);

        }

        [TestMethod]
        public void Test_GetColaboradorById_ColaboradorEstadoDesactivo()
        {
            //colaborador que esta registrado pero que esta desactivo
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("66666666") as PartialViewResult;

            // Assert
            Assert.AreEqual("ACCESO DENEGADO", result.ViewBag.estado);

        }

        [TestMethod]
        public void Test_GetColaboradorById_ColaboradorEstadoActivoIngreso_ContratoVigente()
        {
            //colaborador que esta registrado y registra su Ingreso con contrato Vigente
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("11111111") as PartialViewResult;

            // Assert
            Assert.AreEqual("ACCESO REGISTRADO", result.ViewBag.estado, "INGRESO",result.ViewBag.ingresosalida);

        }
        [TestMethod]
        public void TTest_GetColaboradorById_ColaboradorEstadoActivoSalida_ContratoVigente()
        {
            //colaborador que esta registrado y ya  registro su Ingreso  y esta registrando su SALIDA pero con contrato activo
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("11111111") as PartialViewResult;

            // Assert
            Assert.AreEqual("ACCESO REGISTRADO", result.ViewBag.estado, "SALIDA", result.ViewBag.ingresosalida);

        }

        [TestMethod]
        public void TTest_GetColaboradorById_ColaboradorEstadoActivo_YaMarcoIngresoYSalida_ContratoVigente()
        {
            //colaborador que esta registrado y ya  registro su Ingreso  y salida pero con contrato vigente
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("11111111") as PartialViewResult;

            // Assert
            Assert.AreEqual("UD YA NO PUEDE INGRESAR A LAS INSTALACIONES EL DIA DE HOY",result.ViewBag.estado);

        }
        [TestMethod]
        public void TTest_GetColaboradorById_ColaboradorEstadoActivo_ContratoVencido()
        {
            //colaborador que esta registrado y su contrato esta vencido
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("99999999") as PartialViewResult;

            // Assert
            Assert.AreEqual("ACCESO DENEGADO", result.ViewBag.estado);

        }
    }
}
