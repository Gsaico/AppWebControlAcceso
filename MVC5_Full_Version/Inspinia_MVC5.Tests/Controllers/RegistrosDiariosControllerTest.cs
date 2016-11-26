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
        public void ConvertirAImagen_DniExistente()
        {
            //REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método convertir a Imagen cuando existe el
            //dni del colaborador.
            //arrange
            var controller = new RegistrosDiariosController();
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
            var controller = new RegistrosDiariosController();
            string dni = "00000000";
            //act
            var result = controller.ConvertirAImagen(dni);
            //asert
            Assert.IsNull(result);

        }

        [TestMethod]
        public void Test_GetColaboradoresTopCinco()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método TEST GETCOLABORADORES TOP CINCO su funcionamiento
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradoresTopCinco() as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void Test_GetColaboradorDesconocido()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método GET COLABORADOR DESCONOCIDO, su funcionamiento
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorDesconocido() as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        /*
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
         //PRUEBA TRATA: Prueba el método GETCOLABORADORBYID,en el cual se le envía un DNI de un
         //colaborador el cual no esta registrado en el sistema

            //Colaborador no registrado en el sistema
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("00000000") as PartialViewResult;

            // Assert
            Assert.AreEqual("COLABORADOR NO REGISTRADO", result.ViewBag.desconocido);

        }

        [TestMethod]
        public void Test_GetColaboradorById_ColaboradorEstadoDesactivo()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
         //PRUEBA TRATA: Prueba el método GETCOLABORADORBYID, se le envía en DNI de un colaborador
         // que esta registrado pero no su ESTADO es DESACTVIO
        
         // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("66666666") as PartialViewResult;

            // Assert
            Assert.AreEqual("ACCESO DENEGADO", result.ViewBag.estado);

        }

        [TestMethod]
        public void Test_GetColaboradorById_ColaboradorEstadoActivoIngreso_ContratoVigente()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
         //PRUEBA TRATA: Prueba el método GETCOLABORADORBYID, se le envía el DNI de un colaborador
         // el cual esta registrado y su ESTADO ES ACTIVO Y LA FECHA DE CONTRATO ES VIGENTE.Como es el primer registro del día REGISTRA SU INGRESO
         
         // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("11111111") as PartialViewResult;

            // Assert
            Assert.AreEqual("ACCESO REGISTRADO", result.ViewBag.estado, "INGRESO",result.ViewBag.ingresosalida);

        }
        [TestMethod]
        public void TTest_GetColaboradorById_ColaboradorEstadoActivoSalida_ContratoVigente()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
         //PRUEBA TRATA: Prueba el método GETCOLABORADORBYID, se le envía el DNI de un colaborador
         // el cual esta registrado y su ESTADO ES ACTIVO Y LA FECHA DE CONTRATO ES VIGENTE.Como es el segundo registro del día REGISTRA SU SALIDA
         
         // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("11111111") as PartialViewResult;

            // Assert
            Assert.AreEqual("ACCESO REGISTRADO", result.ViewBag.estado, "SALIDA", result.ViewBag.ingresosalida);

        }

        [TestMethod]
        public void TTest_GetColaboradorById_ColaboradorEstadoActivo_YaMarcoIngresoYSalida_ContratoVigente()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
         //PRUEBA TRATA: Prueba el método GETCOLABORADORBYID, se le envía el DNI de un colaborador
         // el cual esta registrado y su ESTADO ES ACTIVO Y LA FECHA DE CONTRATO ES VIGENTE.Como es el Tercer registro del día ENVÏA UN MENSAJE
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
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
         //PRUEBA TRATA: Prueba el método GETCOLABORADORBYID, se le envía el DNI de un colaborador
         // el cual esta registrado y su ESTADO ES ACTIVO Y LA FECHA DE CONTRATO ESTA VENCIDA
        
         // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            PartialViewResult result = controller.GetColaboradorById("99999999") as PartialViewResult;

            // Assert
            Assert.AreEqual("ACCESO DENEGADO", result.ViewBag.estado);

        }

        [TestMethod]
        public void RegistroDiario()
        {//REALIZADO POR: JORGE KLAUZ VALDIVIA DAVALOS
            //PRUEBA TRATA: Prueba el método REGISTRODIARIO su funcionamiento
           
            // Arrange
            RegistrosDiariosController controller = new RegistrosDiariosController();

            // Act
            var result = controller.RegistroDiario() as ActionResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
