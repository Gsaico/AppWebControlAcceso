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
    }
}
