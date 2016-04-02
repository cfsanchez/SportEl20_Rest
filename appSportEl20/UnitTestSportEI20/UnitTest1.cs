using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using SportEl20.BE;

namespace UnitTestSportEI20
{
    [TestClass]
    public class UnitTest1
    {

        #region Usuario

        [TestMethod]
        public void TestCrearUsuario()
        {
            USUARIO usuario = new USUARIO()
            {
                NOMBRE = "Carlos",
                APE_PAT = "Sanchez",
                APE_MAT = "Angulo",
                EMAIL = "cfsanchez.a@gmail.com",
                TIPOPROFESION = "Sistemas",
                SEXO = "M",
                PASSWORD = "789456",
            };

            var postdata = new JavaScriptSerializer().Serialize(usuario);


            string rpt = Rest(postdata, "POST", "UsuariosService.svc/CrearUsuario");

            JavaScriptSerializer js = new JavaScriptSerializer();
            USUARIO ORPT = js.Deserialize<USUARIO>(rpt);

            Assert.AreEqual("Carlos", ORPT.NOMBRE);
            Assert.AreEqual("Sanchez", ORPT.APE_PAT);
            Assert.AreEqual("Angulo", ORPT.APE_MAT);
        }

        #endregion

        #region Denucia
        [TestMethod]
        public void TestCrearDenuncia()
        {
            Denuncia oenvio = new Denuncia()
            {
                ID_USUARIO = 2,
                TIPODENUNCIA = "Urgente",
                FECHADENUNCIA = DateTime.Now,
                DESCRIPCION = "Unos rateros golpearon a un ancia para robarle su celular",
                ESTADO = "ENVIADO",
            };

            var postdata = new JavaScriptSerializer().Serialize(oenvio);

            string rpt = Rest(postdata, "POST", "DenunciasService.svc/CrearDenuncia");

            JavaScriptSerializer js = new JavaScriptSerializer();
            Denuncia ORPT = js.Deserialize<Denuncia>(rpt);

            Assert.AreEqual(2, ORPT.ID_USUARIO);
            Assert.AreEqual("Urgente", ORPT.TIPODENUNCIA);
        }

        #endregion

        #region Utilitario

        [TestMethod]
        public void TestEnviarEmail()
        {
            Email oEnvio = new Email()
            {
                EmailTo = "cfsanchez.a@gmail.com",
                Asunto = "Prueba de email",
                Cuerpo = "Mensaje de correo de prueba",
            };

            var postdata = new JavaScriptSerializer().Serialize(oEnvio);

            string rpt = Rest(postdata, "POST", "NotificarService.svc/EnvioarEmail");

            Assert.IsTrue(bool.Parse(rpt));
        }

        #endregion

        string Rest(string obj, string metodo, string url)
        {

            byte[] data = Encoding.UTF8.GetBytes(obj);

            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1445/Service1.svc/GetDataUsingDataContract");
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1945/" + url);
            req.Method = metodo;
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string rpt = reader.ReadToEnd();

            return rpt;
        }
    }
}
