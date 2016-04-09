using SportEl20.BE;
using SportEl20.Util;
using SportEl20.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using System.Messaging;
using System.Data.SqlClient;

namespace SportEl20.BL
{
    public class DenunciaBL
    {

        private DenunciaADO oDAO = new DenunciaADO();
        private UsuarioDAO oUsuarioDAO = new UsuarioDAO();
        private string rutaCola = @".\private$\mqDenuncia";

        public DENUNCIA CrearDenuncia(DENUNCIA denuncia)
        {
            DENUNCIA oDENUNCIA = new DENUNCIA();
            denuncia.FECHADENUNCIA = DateTime.Now;

            //Validacion de usuario existente
            var oUsuario = oUsuarioDAO.ObtenerPorId(denuncia.ID_USUARIO);
            if (oUsuario == null)
            {
                throw new WebFaultException<string>("Usuario no se encuentra registrado", HttpStatusCode.InternalServerError);
            }

            //validacion de dos denuncias maximas por usuario al dia
            List<DENUNCIA> denuciaAcumulada = oDAO.ObtenerXUsuario(denuncia.ID_USUARIO);
            string hoy = DateTime.Now.Date.ToShortDateString();
            var nunDenunciaDia = denuciaAcumulada.Where(x => x.FECHADENUNCIA.ToShortDateString() == hoy).Count();

            if (nunDenunciaDia >= 2)
            {
                throw new WebFaultException<string>("Excedio el numero maximo de denuncia por dia", HttpStatusCode.InternalServerError);
            }

            TimeSpan timeOfDay = denuncia.FECHADENUNCIA.TimeOfDay;
            int hour = timeOfDay.Hours;
            if (hour < 5 || hour > 23)
            {
                throw new WebFaultException<string>("No se puede procesar la denuncia porque se encuentra fuera de límite de horario", HttpStatusCode.InternalServerError);
            }

            if (denuncia.TIPODENUNCIA.Trim().ToUpper().Equals("VANDALISMO"))
            {
                if (!MessageQueue.Exists(rutaCola))
                    MessageQueue.Create(rutaCola);

                MessageQueue cola = new MessageQueue(rutaCola);
                Message mensaje = new Message();
                mensaje.Label = "Enviando Cola Denuncia tipo Vandalismo";
                mensaje.Body = denuncia;

                cola.Send(mensaje);
            }
            else
            {
                oDENUNCIA = oDAO.Crear(denuncia);
            }

            return oDENUNCIA;
        }

        public DENUNCIA ObtenerDenuncia(int id)
        {
            return oDAO.Obtener(id);
        }

        public DENUNCIA ModificarDenuncia(DENUNCIA denuncia)
        {
            //Validacion de usuario existente
            var oUsuario = oUsuarioDAO.ObtenerPorId(denuncia.ID_USUARIO);
            if (oUsuario == null)
            {
                throw new WebFaultException<string>("Usuario no se encuentra registrado", HttpStatusCode.InternalServerError);
            }

            if (oUsuario.COD_PERFIL.Equals("USU"))
            {
                throw new WebFaultException<string>("Usuario no tiene permisos para modificar denuncia", HttpStatusCode.InternalServerError);
            }

            return oDAO.Modificar(denuncia);
        }

        public void EliminarDenuncia(int id)
        {
            oDAO.Eliminar(id);
        }

        public List<DENUNCIA> ListarDenuncia()
        {
            return oDAO.ListarTodos();
        }

        public List<DENUNCIA> ObtenerDenunciaPorUsuario(int ID_USUARIO)
        {
            List<DENUNCIA> oLista = null;
            var oUsuario = oUsuarioDAO.ObtenerPorId(ID_USUARIO);
            if (oUsuario == null)
            {
                throw new WebFaultException<string>("Usuario no se encuentra registrado", HttpStatusCode.InternalServerError);
            }

            if (oUsuario.COD_PERFIL.Equals("ADM"))
            {
                //Obtenemos las denuncias de la cola
                DENUNCIA oDenuncia = null;
                if (MessageQueue.Exists(rutaCola))
                {
                    MessageQueue cola = new MessageQueue(rutaCola);
                    cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(DENUNCIA) });
                    var contador = cola.GetAllMessages().Count();
                    if (contador > 0)
                    {
                        while (contador-- > 0)
                        {
                            Message mensajeIn = cola.Receive();
                            oDenuncia = (DENUNCIA)mensajeIn.Body;
                            var oCreada = oDAO.Crear(oDenuncia);
                        }
                    }
                }


                oLista = oDAO.ObtenerXAdministrador();
            }
            else
            {
                oLista = oDAO.ObtenerXUsuario(ID_USUARIO);
            }

            return oLista;
        }

    }
}
