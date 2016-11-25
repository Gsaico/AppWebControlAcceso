using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspinia_MVC5.Controllers;
using System.Threading.Tasks;
using Inspinia_MVC5.Models;
using System;
using System.Drawing;
using System.Web;
using System.Linq;

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
        [TestMethod]
        public void ConvertirAImagen_DniExistente()
        {
            //arrange
            var controller = new ColaboradoresController();
            string dni = "11111111";
            //act
            var result = controller.ConvertirAImagen(dni);
            //asert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void ConvertirAImagen_DniINExistente()
        {
            //arrange
            var controller = new ColaboradoresController();
            string dni = "00000000";
            //act
            var result = controller.ConvertirAImagen(dni);
            //asert
            Assert.IsNull(result);

        }
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
        #region SEARCH
        [TestMethod]
        public async Task Search_ByDNI_Existente()
        {
            // Arrange
            var controller = new ColaboradoresController();
            
            string DNI = "11111111";
            string ApePaterno = "";
            string ApeMaterno = "";
            string Nombres = "";
            string Area = "";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;
            
            Assert.IsNotNull(result.Model);

           
        }
        [TestMethod]
        public async Task Search_ByDNI_Inexistente()
        {
            // Arrange
            var controller = new ColaboradoresController();
            
            string DNI = "00000000";
            string ApePaterno = "";
            string ApeMaterno = "";
            string Nombres = "";
            string Area = "";

            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;
            Assert.AreEqual("No hay datos", result.ViewBag.Datos);
        }

        [TestMethod]
        public async Task Search_ApellidoPaterno_Existente()
        {
            // Arrange
            var controller = new ColaboradoresController();
            Colaboradores colaborador = new Colaboradores();

            string DNI = "";
            string ApePaterno = "SULLA";
            string ApeMaterno = "";
            string Nombres = "";
            string Area = "";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;

            Assert.IsNotNull(result.Model);


        }
        [TestMethod]
        public async Task Search_ApellidoPaterno_Inexistente()
        {
            // Arrange
            var controller = new ColaboradoresController();
            string DNI = "";
            string ApePaterno = "ZZZZZZZZZ";
            string ApeMaterno = "";
            string Nombres = "";
            string Area = "";
            // Act
            
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;
            //asert
            Assert.AreEqual("No hay datos", result.ViewBag.Datos);

        }

        [TestMethod]
        public async Task Search_ApellidoMaterno_Existente()
        {
            // Arrange
            var controller = new ColaboradoresController();
            Colaboradores colaborador = new Colaboradores();

            string DNI = "";
            string ApePaterno = "";
            string ApeMaterno = "OLAECHEA";
            string Nombres = "";
            string Area = "";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;

            Assert.IsNotNull(result.Model);


        }
        [TestMethod]
        public async Task Search_ApellidoMaterno_Inexistente()
        {
            // Arrange
            var controller = new ColaboradoresController();
            string DNI = "";
            string ApePaterno ="" ;
            string ApeMaterno = "ZZZ";
            string Nombres = "";
            string Area = "";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;
            //assert
            Assert.AreEqual("No hay datos", result.ViewBag.Datos);

        }

        [TestMethod]
        public async Task Search_Nombres_Existente()
        {
            // Arrange
            var controller = new ColaboradoresController();
            Colaboradores colaborador = new Colaboradores();

            string DNI = "";
            string ApePaterno = "";
            string ApeMaterno = "";
            string Nombres = "JOSE CARLOS";
            string Area = "";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;

            Assert.IsNotNull(result.Model);


        }
        [TestMethod]
        public async Task Search_Nombres_Inexistente()
        {
            // Arrange
            var controller = new ColaboradoresController();
            string DNI = "";
            string ApePaterno = "";
            string ApeMaterno = "";
            string Nombres = "EVARISTO";
            string Area = "";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;
            //assert
            Assert.AreEqual("No hay datos", result.ViewBag.Datos);

        }
        [TestMethod]
        public async Task Search_AREA_Existente()
        {
            // Arrange
            var controller = new ColaboradoresController();
            Colaboradores colaborador = new Colaboradores();

            string DNI = "";
            string ApePaterno = "";
            string ApeMaterno = "";
            string Nombres = "";
            string Area = "1";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;

            Assert.IsNotNull(result.Model);


        }
        [TestMethod]
        public async Task Search_AREA_Inexistente()
        {
            // Arrange
            var controller = new ColaboradoresController();
            string DNI = "";
            string ApePaterno = "";
            string ApeMaterno = "";
            string Nombres = "";
            string Area = "0";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;
            //assert
            Assert.AreEqual("No hay datos", result.ViewBag.Datos);

        }
        [TestMethod]
        public async Task Search_TODOS_CAMPOS_VACIO()
        {
            //En esta prueba cuando no se le escribe nada envía todos la listad e trabajadores por default
            // Arrange
            var controller = new ColaboradoresController();
            string DNI = "";
            string ApePaterno = "";
            string ApeMaterno = "";
            string Nombres = "";
            string Area = "";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;
            //assert
            Assert.AreEqual("hay datos", result.ViewBag.Datos);

        }
        [TestMethod]
        public async Task Search_2CAMPOS_EXISTENTES_MISMO_COLABORADOR()
        {
            //En esta prueba de datos del mismo colaborador resulve solo uno
            // Arrange
            var controller = new ColaboradoresController();
            string DNI = "11111111";
            string ApePaterno = "SULLA";
            string ApeMaterno = "";
            string Nombres = "";
            string Area = "";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;
            //assert
            Assert.AreEqual("hay datos", result.ViewBag.Datos);

        }
        [TestMethod]
        public async Task Search_2CAMPOS_EXISTENTES_DIFERENTE_COLABORADOR()
        {
            //LA FORMA DE BUSQUEDA ES:EL primer filtro DNI y sobre eso hacen las demás busquedas.Es por eso que cuando pones mas datos devolverá null
             // Arrange
            var controller = new ColaboradoresController();
            string DNI = "11111111";
            string ApePaterno = "ACEVEDO";
            string ApeMaterno = "";
            string Nombres = "";
            string Area = "";
            // Act
            var result = await controller.Search(DNI, ApePaterno, ApeMaterno, Nombres, Area) as ViewResult;
            //assert
            Assert.AreEqual("No hay datos", result.ViewBag.Datos);

        }
        [TestMethod]
        #endregion

        public void Index()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
          
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result,"Debería devolver no nulo si hay colaboradores");

        }
        #region DETAILS
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
        #endregion
        [TestMethod]
        public void Create()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            //string dni = "00000000";
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert

            Assert.IsNotNull(result, "Debería devolver no nulo ");

        }
        #region CREATE
        [TestMethod]
        public  async Task Create_Colaborador_Existente()
        {
            // Arrange
            var controller = new ColaboradoresController();
            Colaboradores col = new Colaboradores();
            {
                col.COD_Colaborador = "11111111";
                col.COD_Empresa = "20234567543";
                col.ApellidoPaterno = "SAICO";
                col.ApellidoMaterno = "LOPEZ";
                col.Nombres = "ALBERTO";
                col.ID_Area = 1;
                col.FechaNacimiento = Convert.ToDateTime("2016-10-5");
                col.FechaContratacion = Convert.ToDateTime("01/12/2012");
                col.FechaIngresoReingreso = Convert.ToDateTime("01/01/2012");
                col.FechaCese = Convert.ToDateTime("01/5/2012");
                col.Direccion = "CAYMA AV LAS PEÑAS";
                col.Cargo = "OPERADOR DE CAMION";
                col.Estado = true;
            };
          //  string ruta = "D:/GitHub/AppWebControlAcceso/Extras/Imagenes/OperadorImagen.jpg";
            //Image img = Image.FromFile(ruta);
            // Imagen img = Image.FromFile(ruta);
           // HttpPostedFileBase ht= img;
            // Act
            var result = await controller.Create(col,null) as ViewResult;
            // Assert
            Assert.AreEqual("Error El DNI que ud desea ingresar ya existe en la Base de Datos", result.ViewBag.MensajeAlerta);

        }
        [TestMethod]
        public async Task Create_Colaborador_Nuevo()
        {
            // Arrange
            var controller = new ColaboradoresController();
            IDCHECKDBEntities db = new IDCHECKDBEntities();
            Colaboradores col = new Colaboradores();
            {
                col.COD_Colaborador = "12888888";
                col.COD_Empresa = "20234567543";
                col.ApellidoPaterno = "SAICO";
                col.ApellidoMaterno = "LOPEZ";
                col.Nombres = "ALBERTO";
                col.ID_Area = 1;
                col.FechaNacimiento = Convert.ToDateTime("2016-10-5");
                col.FechaContratacion = Convert.ToDateTime("01/12/2012");
                col.FechaIngresoReingreso = Convert.ToDateTime("01/01/2012");
                col.FechaCese = Convert.ToDateTime("01/5/2012");
                col.Direccion = "CAYMA AV LAS PEÑAS";
                col.Cargo = "OPERADOR DE CAMION";
                col.Estado = true;
            };
            var result = await controller.Create(col, null) as RedirectToRouteResult;

            var query = db.Colaboradores.Where(q => q.COD_Colaborador == col.COD_Colaborador);
            
            //var result = await controller.Create(col, null) as RedirectResult;
             Assert.IsNotNull(query);
        }
        #endregion
        #region EDIT
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
        #endregion
        #region DELETE
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
            string dni = "12888888";
            // Act
            ViewResult result = controller.Delete(dni) as ViewResult;

            // Assert

            Assert.AreEqual("¿Estás seguro que quieres eliminar los datos del colaborador?", result.ViewBag.mensajedelete);

        }

       
        [TestMethod]
        public void DeleteConfirme()
        {
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "12888888";
            // Act
          var result = controller.DeleteConfirmed(dni) ;
            IDCHECKDBEntities db = new IDCHECKDBEntities();
            // Assert
            var query = db.Colaboradores.Where(q => q.COD_Colaborador == dni);
            Assert.AreEqual(0,query.Count());

        }
        
        #endregion
    }
}
