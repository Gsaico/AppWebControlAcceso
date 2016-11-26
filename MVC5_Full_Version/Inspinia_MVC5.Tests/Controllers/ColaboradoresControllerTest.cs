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
        
        [TestMethod]
        public void ConvertirAImagen_DniExistente()
        {
            //REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método convertir a Imagen cuando existe el
            //dni del colaborador.
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método convertir a Imagen cuado el DNI
            //del colaborador no esta registrador en la base datos
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método EmptyPage
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();

            // Act
            ViewResult result = controller.EmptyPage() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Search_Imprimir()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el funcionamiento del metodo Search imprimir
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método SEARCH, buscando por DNI cuando
            //el colaborador existe
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método SEARCH, Buscando por DNI cuando
            //El colaborador no esta registrado
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método SEARCH, buscando por apellido parterno
            //cuando existe el colaborador
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método, buscando por apellido parterno
            //cuando el colaborador no existe
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método SEARCH,buscando por apellido marterno
            //cuando el colaborador existe
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método SEARCH, cuando el el apellido marteno
            // de colaborador no existe
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método SEARCH, buscando los nombre del colaborador
            //del colaborador que existe en el sistema
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método SEARCH, buscando por nombres del colaborador
            //que no esta registrado en el sistema
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método, SEARCH buscando por área seleccionado
            //cuando el área existe
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método SEARCH, buscando por área 
            //cuando elárea no existe
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método SEARCH, buscando cuando todos los campos
            //a buscar son vacios.
            
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método SEARCH, cuando se le envía varios parámetros,
            //en este caso en particular  solo se esta enviando 2 los cuales son DNI  Y APELLIDOPARTENO
            //de un colaborador que existe.
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
         //PRUEBA TRATA: Prueba el método SEARCH, buscando por varios parámetros, en este caso en particular
         //solo buscará por DNI y APELLIDO PARTERNO Pero a diferencia del anterior caso, se le han puesto datos
         //de colaboradores existentes pero que son distintos.
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método Index
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
          
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result,"Debería devolver no nulo si hay colaboradores");

        }
        #region DETAILS
        [TestMethod]
        public void Details_DNI_Existente_NoNull()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método DETAILS, en él se le inserta un DNI
            // de un colaborador EXISTENTE
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método DETAILS, en él se le envía un campo Nulo
            //ya que necesita que se le envíe un DNI
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método DETAILS, en él se le envía un DNI de un colaborador
            // el cual no existe
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método Create, el cual prueba su funcionamiento.
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método CREATE, en el cual vamos en enviarle datos
            // de un colaborador cuyo DNI ya esta registrado
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
          
            // Act
            var result = await controller.Create(col,null) as ContentResult;
            // Assert
            //Assert.AreEqual("Error El DNI que ud desea ingresar ya existe en la Base de Datos", result);
            Assert.AreEqual("<script language='javascript' type='text/javascript'>alert('Error El DNI que ud desea ingresar ya existe en la Base de Datos!');</script>", result.Content);

        }
        [TestMethod]
        public async Task Create_Colaborador_Nuevo()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método CREATE, en el cual se le enviando datos de un colaborador
            //cuyo DNI y Datos no están registrados
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método EDITH, y se le está enviando
            //un DNI  vacio
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método EDITH, en el cual se le envía
            //el DNI de un colaborador que no esta registrado en el sistema
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método EDITH, en el cual se le envía
            //el DNI de un colabador existente
            // Arrange
            ColaboradoresController controller = new ColaboradoresController();
            string dni = "11111111";
            // Act
            ViewResult result = controller.Edit(dni) as ViewResult;

            // Assert

            Assert.IsNotNull(result, "Debería devolver no nulo porque  exite colaborador");

        }
        [TestMethod]
        public async Task EDTIH_DatosColaborador_EXISTENTE()
        {
            //REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método EDITH, en el cual vamos en enviarle datos
            // de un colaborador cuyo DNI ya esta registrado(EN LA PRUEBA CREATE DE ESTA SECCION)
            // PARA ESTE CASO NO HAY OTRA POSIBILIDAD QUE SE INGRESE DNI DE UN COLABORADOR INEXSITENTE
            //PORQUE SE CAPTURA EL DNI DESDE LA VISTA Y SOLO SE MODIFICAN LOS DEMÁS DATOS DE COLABORADOR
            // Arrange
            var controller = new ColaboradoresController();
            IDCHECKDBEntities db = new IDCHECKDBEntities();
            Colaboradores col = new Colaboradores();
            {
                col.COD_Colaborador = "12888888";
                col.COD_Empresa = "20234567543";
                col.ApellidoPaterno = "TOMASEVICH";
                col.ApellidoMaterno = "RANDULFO";
                col.Nombres = "JAVIER ERNESTO";
                col.ID_Area = 1;
                col.FechaNacimiento = Convert.ToDateTime("1985-10-5");
                col.FechaContratacion = Convert.ToDateTime("05/05/2012");
                col.FechaIngresoReingreso = Convert.ToDateTime("01/05/2013");
                col.FechaCese = Convert.ToDateTime("01/05/2020");
                col.Direccion = "CAYMA AV LAS PEÑAS";
                col.Cargo = "OPERADOR DE CAMION";
                col.Estado = true;
            };

            // Act
            var result = await controller.Edit(col, null) as RedirectToRouteResult;

            var query = db.Colaboradores.Where(q => q.COD_Colaborador == col.COD_Colaborador && q.ApellidoPaterno==col.ApellidoPaterno);
            //Assert
              Assert.IsNotNull(query);// Assert
            
        }

        
        #endregion
        #region DELETE
        [TestMethod]
        public void Delete_DniNull()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método DELETE, en el cual se le envía un DNI
            // de un colaborador, el cual estará vacío
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método DELETE, en el cual se le envía un DNI
            // de un colaborador que no existe
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método DELETE, en el cual se le evía un DNI de un colaborador
            // que ya tiene registrado sus asistencia en el sistema
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método DELETE, en el cual se le envía un DNI de un colaborador
            // el cual no cuenta con registros de asistencia dentro del sistema
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método DELETE, en el cual se le envía un DNI de un colaborador
            // que esta registrado en el sistema.
            //EN ESTE CASO NO PUEDE OTRA POSIBILIDAD YA QUE EL SISTEMA NO PERMITE UN DNI INEXISTENTE
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
