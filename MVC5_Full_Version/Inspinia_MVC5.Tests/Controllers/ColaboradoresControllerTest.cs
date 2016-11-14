using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspinia_MVC5;
using Inspinia_MVC5.Controllers;
using System.Threading.Tasks;
using Inspinia_MVC5.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Inspinia_MVC5.Tests.Controllers
{
    [TestClass]
    public class ColaboradoresControllerTest
    {
       
        [TestMethod]
        public void Test_MostrarColaboradores()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Test_DetalleColaboradores()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();

            // Act
            ViewResult result = controller.Details("11111111") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Test_CreateColaboradores()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_EditColaboradores()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();

            // Act
            ViewResult result = controller.Edit("11111111") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_DeleteColaboradores()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();

            // Act
            ViewResult result = controller.Delete("11111111") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
       
    }
}
