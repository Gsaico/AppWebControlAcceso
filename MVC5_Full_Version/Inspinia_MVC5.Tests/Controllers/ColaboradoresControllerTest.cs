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
        /*
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
        */
        /*
        [TestMethod]
        public async Task Search_ByDNI_Existente()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            Colaboradores colaborador = new Colaboradores();

            string DNI = "11111111";
            string ApePaterno = "";
            string ApeMaterno = "";
            string Nombres = "";
            string Area = "";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area);
            
            foreach(Colaboradores col in result.ExecuteResult)
            {

            }
            
            //result.GetHashCode();
          //  ViewResult vr = result  ;
            ActionResult rs = result;
      
               // PartialViewResult r = result ;
           
           // Assert.AreEqual(0,result);
            
            // Assert
           // Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void Search_ByDNI_Inexistente()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();

            // Act
            ViewResult result = controller.Edit("00000000") as ViewResult;

            // Assert
            Assert.IsNull(result);
        }
       */
        [TestMethod]
        public void empypage()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();

            // Act
            ViewResult result = controller.EmptyPage() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Search_Imprimir()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string id = "11111111";
            // Act
            ViewResult result = controller.SearchImprimir(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
          
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result,"Debería devolver no nulo si hay colaboradores");

        }
        [TestMethod]
        public void Details_NoNull()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "11111111";
            // Act
            ViewResult result = controller.Details(dni) as ViewResult;

            // Assert
            
            Assert.IsNotNull(result, "Debería devolver no nulo si hay colaboradores");

        }
        [TestMethod]
        public void Details_Null()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "";
            // Act
            ViewResult result = controller.Details(dni) as ViewResult;

            // Assert

            Assert.IsNull(result, "Debería devolver nulo si hay colaboradores");

        }
        [TestMethod]
        public void Details_NoNull_ColaboradorNoExiste()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "00000000";
            // Act
            ViewResult result = controller.Details(dni) as ViewResult;

            // Assert

            Assert.IsNull(result, "Debería devolver nulo porque no exite dni");

        }
        [TestMethod]
        public void Create()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "00000000";
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert

            Assert.IsNotNull(result, "Debería devolver no nulo ");

        }
        [TestMethod]
        public void Edith_DniNull()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "";
            // Act
            ViewResult result = controller.Edit(dni) as ViewResult;

            // Assert

            Assert.IsNull(result, "Debería devolver nulo porque no exite dni");

        }
        [TestMethod]
        public void Edith_DniNoNull_ColaboradorNUll()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "00000000";
            // Act
            ViewResult result = controller.Edit(dni) as ViewResult;

            // Assert

            Assert.IsNull(result, "Debería devolver nulo porque no exite colaborador");

        }
        [TestMethod]
        public void Edith_DniNoNull_Colaborador()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "11111111";
            // Act
            ViewResult result = controller.Edit(dni) as ViewResult;

            // Assert

            Assert.IsNotNull(result, "Debería devolver no nulo porque  exite colaborador");

        }
        [TestMethod]
        public void Delete_DniNull()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "";
            // Act
            ViewResult result = controller.Delete(dni) as ViewResult;

            // Assert

            Assert.IsNull(result, "Debería devolver nulo porque no exite dni");

        }
        [TestMethod]
        public void Delete_DniNoNull_ColaboradorNull()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "00000000";
            // Act
            ViewResult result = controller.Delete(dni) as ViewResult;

            // Assert

            Assert.IsNull(result, "Debería devolver nulo porque no exite colaborador");

        }
        [TestMethod]
        public void Delete_DniNoNull_Colaborador_CONRegistrosDiarios()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "11111111";
            // Act
            ViewResult result = controller.Delete(dni) as ViewResult;

            // Assert

            Assert.AreEqual("Los datos del colaborador no se pueden eliminar, ya existe información registrada", result.ViewBag.mensajedelete);

        }
        [TestMethod]
        public void Delete_DniNoNull_Colaborador_SinRegistrosDiarios()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "99999999";
            // Act
            ViewResult result = controller.Delete(dni) as ViewResult;

            // Assert

            Assert.AreEqual("¿Estás seguro que quieres eliminar los datos del colaborador?", result.ViewBag.mensajedelete);

        }

        
    }
}
