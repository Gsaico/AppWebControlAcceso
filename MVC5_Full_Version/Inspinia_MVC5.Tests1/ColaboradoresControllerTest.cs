using System.Threading.Tasks;
// <copyright file="ColaboradoresControllerTest.cs">Copyright ©  2014</copyright>
using System;
using System.Web.Mvc;
using Inspinia_MVC5.Controllers;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inspinia_MVC5.Controllers.Tests
{
    /// <summary>Esta clase contiene pruebas unitarias parametrizadas para ColaboradoresController</summary>
    [PexClass(typeof(ColaboradoresController))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ColaboradoresControllerTest
    {
        /// <summary>Código auxiliar de prueba para ListadoColaboradores()</summary>
        [PexMethod]
        public ActionResult ListadoColaboradoresTest([PexAssumeUnderTest]ColaboradoresController target)
        {
            ActionResult result = target.ListadoColaboradores();
            return result;
            // TODO: agregar aserciones a método ColaboradoresControllerTest.ListadoColaboradoresTest(ColaboradoresController)
        }

        /// <summary>Código auxiliar de prueba para Search(String, String, String)</summary>
        [PexMethod]
        public Task<ActionResult> SearchTest(
            [PexAssumeUnderTest]ColaboradoresController target,
            string SearchStringApePaterno,
            string SearchStringNombres,
            string SearchStringDNI
        )
        {
            Task<ActionResult> result
               = target.Search(SearchStringApePaterno, SearchStringNombres, SearchStringDNI);
            return result;
            // TODO: agregar aserciones a método ColaboradoresControllerTest.SearchTest(ColaboradoresController, String, String, String)
        }
    }
}
