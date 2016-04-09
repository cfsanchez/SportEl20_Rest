using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Linq;
using SportEl20.BE;

namespace UnitTestSportEI20
{
    /// <summary>
    /// Descripción resumida de UnitTestDenuncia
    /// </summary>
    [TestClass]
    public class UnitTestDenunciaRest
    {
        [TestMethod]
        public void CrearOk()
        {
            Denuncia oItem = new Denuncia
            {
                ID_USUARIO = 4,
                TIPODENUNCIA = "Vandalismo", //Parque, Casa
                FECHADENUNCIA = DateTime.Now,
                DESCRIPCION = "Se encuentra 3 ladrones robando en la galeria.",
                ESTADO = "REGISTRADO",
            };


            var postData = new JavaScriptSerializer().Serialize(oItem);

            string rpt = Rest(postData, "POST", "DenunciasService.svc/Denuncias");

            JavaScriptSerializer js = new JavaScriptSerializer();
            Denuncia oItemRespuesta = js.Deserialize<Denuncia>(rpt);

            Assert.AreEqual("Vandalismo", oItemRespuesta.TIPODENUNCIA);
            Assert.AreEqual(4, oItemRespuesta.ID_USUARIO);
        }

        [TestMethod]
        public void CrearError()
        {
            Denuncia oItem = new Denuncia
            {
                ID_USUARIO = 2,
                TIPODENUNCIA = "Parque", //Parque, Casa
                FECHADENUNCIA = DateTime.Now,
                DESCRIPCION = "Se encuentra 3 ladrones robando en la galeria.",
                ESTADO = "PENDIENTE",
            };
            var postData = new JavaScriptSerializer().Serialize(oItem);

            try
            {
                string rpt = Rest(postData, "POST", "DenunciasService.svc/Denuncias");

                JavaScriptSerializer js = new JavaScriptSerializer();
                Denuncia oItemRespuesta = js.Deserialize<Denuncia>(rpt);

                Assert.AreEqual("Parque", oItemRespuesta.TIPODENUNCIA);
                Assert.AreEqual(2, oItemRespuesta.ID_USUARIO);

            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;

                StreamReader readerError = new StreamReader(ex.Response.GetResponseStream());
                string jsone = readerError.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(jsone);
                Assert.AreEqual("Excedio el numero maximo de denuncia por dia", mensaje);
            }
        }

        [TestMethod]
        public void ModificarOK()
        {
            Denuncia oItem = new Denuncia
            {
                ID_DENUNCIA = 2,
                ID_USUARIO = 1,
                TIPODENUNCIA = "Casa", //Parque, Casa
                FECHADENUNCIA = DateTime.Now,
                DESCRIPCION = "Se encuentra 3 ladrones robando en la galeria.",
                ESTADO = "PROCESO",
            };
            var postData = new JavaScriptSerializer().Serialize(oItem);

            try
            {
                string rpt = Rest(postData, "PUT", "DenunciasService.svc/Denuncias");

                JavaScriptSerializer js = new JavaScriptSerializer();
                Denuncia oItemRespuesta = js.Deserialize<Denuncia>(rpt);

                Assert.AreEqual("Casa", oItemRespuesta.TIPODENUNCIA);
                Assert.AreEqual("PROCESO", oItemRespuesta.ESTADO);
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;

                StreamReader readerError = new StreamReader(ex.Response.GetResponseStream());
                string jsone = readerError.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(jsone);
                Assert.AreEqual("Usuario no tiene permisos para modificar denuncia", mensaje);
            }
        }

        [TestMethod]
        public void ModificarError()
        {
            Denuncia oItem = new Denuncia
            {
                ID_DENUNCIA = 2,
                ID_USUARIO = 2,
                TIPODENUNCIA = "Casa", //Parque, Casa
                FECHADENUNCIA = DateTime.Now,
                DESCRIPCION = "Se encuentra 3 ladrones robando en la galeria.",
                ESTADO = "PROCESO",
            };
            var postData = new JavaScriptSerializer().Serialize(oItem);

            try
            {
                string rpt = Rest(postData, "PUT", "DenunciasService.svc/Denuncias");

                JavaScriptSerializer js = new JavaScriptSerializer();
                Denuncia oItemRespuesta = js.Deserialize<Denuncia>(rpt);

                Assert.AreEqual("Casa", oItemRespuesta.TIPODENUNCIA);
                Assert.AreEqual("PROCESO", oItemRespuesta.ESTADO);
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;

                StreamReader readerError = new StreamReader(ex.Response.GetResponseStream());
                string jsone = readerError.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(jsone);
                Assert.AreEqual("Usuario no tiene permisos para modificar denuncia", mensaje);
            }
        }

        [TestMethod]
        public void Eliminar()
        {
            int id = 2;
            string url = string.Format("DenunciasService.svc/Denuncias/{0}", id);

            RestUrl("DELETE", url);

            string rpt = RestUrl("GET", "DenunciasService.svc/Denuncias");

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Denuncia> oItemRespuesta = js.Deserialize<List<Denuncia>>(rpt);

            Denuncia busca = oItemRespuesta.SingleOrDefault(x => x.ID_DENUNCIA.Equals(id));

            Assert.IsNull(busca);
        }


        string Rest(string obj, string metodo, string url)
        {
            byte[] data = Encoding.UTF8.GetBytes(obj);
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

        string RestUrl(string metodo, string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1945/" + url);
            req.Method = metodo;
            req.ContentType = "application/json";
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string rpt = reader.ReadToEnd();

            return rpt;
        }
    }
}
