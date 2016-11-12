using Inspinia_MVC5.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspinia_MVC5.Tests.Models
{
    [TestClass]
    public class ColaboradorModelTest
    {
        private IDCHECKDBEntities db = new IDCHECKDBEntities();
        private Colaboradores col = new Colaboradores();

        [TestMethod]
        public void HU001_SEARCH_BYCODIGO_1()
        {
            //CODIGO CORRRECTO
            //arrage plantear
            col.COD_Colaborador = "11111111";
            //act Prueba
            var querycolaborador = db.Colaboradores.Where(q => q.COD_Colaborador == col.COD_Colaborador).ToList();
            ICollection<Colaboradores> icolec = querycolaborador;
            //Comprueba afirmacion
            Assert.AreEqual(1, icolec.Count());

        }


        //  AssertFailedException fe = new AssertFailedException();
        [TestMethod]
        public void HU001_SEARCH_BYAPELLIDO()
        {
            //CODIGO CORRRECTO
            //arrage plantear
            col.ApellidoMaterno = "VALDIVIA";
            //act Prueba
            var querycolaborador = db.Colaboradores.Where(q => q.ApellidoPaterno == col.ApellidoPaterno).ToList();
            ICollection<Colaboradores> icolec = querycolaborador;
            //Comprueba afirmacion
            Assert.AreEqual(0, icolec.Count());
        }
        [TestMethod]
        public void HU001_SEARCH_NOMBRES()
        {
            //CODIGO CORRRECTO
            //arrage plantear
            col.Nombres = "Juan";
            //act Prueba
            var querycolaborador = db.Colaboradores.Where(q => q.Nombres == col.Nombres).ToList();
            ICollection<Colaboradores> icolec = querycolaborador;
            //Comprueba afirmacion
            Assert.AreEqual(0, icolec.Count());
        }
        [TestMethod]
        public void HU001_ListadoColaboradores()
        {
            //CODIGO CORRRECTO
            //arrage plantear

            //act Prueba
            var querycolaborador = db.Colaboradores.Select(q => q);

            ICollection<Colaboradores> Icola = querycolaborador.ToList();




            //ICollection<Colaboradores> icolec = querycolaborador;
            //Comprueba afirmacion
            Assert.AreNotEqual(0, Icola.Count());
            //Assert.AreEqual(0, Icola.Count());
        }

        [TestMethod]
        public void HU001_Create_colaboradores()
        {
            Colaboradores col = new Colaboradores();
            {
                col.COD_Colaborador = "1288888";
                col.COD_Empresa = "20234567543";
                col.ApellidoPaterno = "saico";
                col.ApellidoMaterno = "lopez";
                col.Nombres = "alberto";
                col.ID_Area = 1;
                col.FechaNacimiento = Convert.ToDateTime("2016-10-5");
                col.FechaContratacion = Convert.ToDateTime("01/12/2012");
                col.FechaIngresoReingreso = Convert.ToDateTime("01/01/2012");
                col.FechaCese = Convert.ToDateTime("01/5/2012");
                col.COD_Departamento = 1.ToString();
                col.COD_Provincia = 1.ToString();
                col.COD_Distrito = "1";
                col.Direccion = "Avenida las peñas";
                col.Cargo = "2";
                col.Estado = true;
            };

            db.Colaboradores.Add(col);
            db.SaveChanges();

            var querycolaboradores = from c in db.Colaboradores
                                     where c.COD_Colaborador == col.COD_Colaborador
                                     select c;
            ICollection<Colaboradores> icolec = querycolaboradores.ToList();

            Assert.AreEqual(col.COD_Colaborador.ToString(), icolec.First().COD_Colaborador);


        }
    }
}
