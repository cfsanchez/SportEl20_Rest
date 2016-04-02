using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using SportEl20.BE;
using System.ServiceModel;

namespace UnitTestSportEI20
{
    [TestClass]
    public class UnitTestUsuarioWCF
    {
        #region Usuario

        [TestMethod]
        public void TestCrearUsuario()
        {
            WCFUsuario.UsuariosServiceClient wcf = new WCFUsuario.UsuariosServiceClient();
            USUARIO objCreado = wcf.CrearUsuario(new USUARIO
            {
                NOMBRE = "Carlos",
                APE_PAT = "Sanchez",
                APE_MAT = "Angulo",
                EMAIL = "cfsanchez.a@gmail.com",
                TIPOPROFESION = "Sistemas",
                SEXO = "M",
                PASSWORD = "789456",
                COD_PERFIL = "USU",
            });

            Assert.IsTrue(objCreado.ID_USUARIO > 0);
            Assert.AreEqual("Sanchez", objCreado.APE_PAT);
        }

        [TestMethod]
        public void TestDuplicidadUsuario()
        {
            try
            {
                WCFUsuario.UsuariosServiceClient wcf = new WCFUsuario.UsuariosServiceClient();
                USUARIO objCreado = wcf.CrearUsuario(new USUARIO
                {
                    NOMBRE = "Carlos",
                    APE_PAT = "Sanchez",
                    APE_MAT = "Angulo",
                    EMAIL = "cfsanchez.a@gmail.com",
                    TIPOPROFESION = "Sistemas",
                    SEXO = "M",
                    PASSWORD = "789456",
                    COD_PERFIL = "USU",
                });

                Assert.IsTrue(objCreado.ID_USUARIO > 0);
                Assert.AreEqual("Sanchez", objCreado.APE_PAT);
            }
            catch (FaultException<ExceptionBase> error)
            {
                Assert.AreEqual("Error al intentar creacion", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "El USUARIO ya existe");
            }
        }

        [TestMethod]
        public void TestModificarUsuarioNoExiste()
        {
            try
            {
                WCFUsuario.UsuariosServiceClient wcf = new WCFUsuario.UsuariosServiceClient();
                USUARIO objCreado = wcf.ModificarUsuario(new USUARIO
                {
                    NOMBRE = "Luis",
                    APE_PAT = "Ramos",
                    APE_MAT = "Perez",
                    EMAIL = "noResitrado@gmail.com",
                    TIPOPROFESION = "Sistemas",
                    SEXO = "M",
                    PASSWORD = "741852963",
                });

                Assert.AreEqual("Ramos", objCreado.APE_PAT);
            }
            catch (FaultException<ExceptionBase> error)
            {
                Assert.AreEqual("Error al intentar modificar", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "102");
                Assert.AreEqual(error.Detail.Descripcion, "El USUARIO no se encuentra registrado");
            }
        }


        [TestMethod]
        public void TestLoginOk()
        {
            try
            {
                WCFSeguridad.ModuloSeguridadServiceClient wcf = new WCFSeguridad.ModuloSeguridadServiceClient();
                USUARIO objCreado = wcf.LoginUsuario(new USUARIO
                {
                    EMAIL = "cfsanchez.a@gmail.com",
                    PASSWORD = "789456",
                });

                Assert.AreEqual("Carlos", objCreado.NOMBRE);
            }
            catch (FaultException<ExceptionBase> error)
            {
                Assert.AreEqual("Error al intentar logearse", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "102");
                Assert.AreEqual(error.Detail.Descripcion, "El Usuario o Contraseña son incorrecto");
            }
        }

        #endregion
    }
}
