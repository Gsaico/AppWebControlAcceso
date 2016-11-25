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
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método INDEX, su funcionamiento
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }



        [TestMethod]
        public void About()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método ABOUT, su funcionamiento
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método su funcionamiento
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
