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

namespace SportEl20.BL
{
    public class DenunciaBL
    {

        private DenunciaADO oDAO = new DenunciaADO();
        private UsuarioDAO oUsuarioDAO = new UsuarioDAO();

        public DENUNCIA CrearDenuncia(DENUNCIA denuncia)
        {
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

            return oDAO.Crear(denuncia);
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


        public void CrearDetalleFoto(List<DETALLE_FOTO> DETALLE_FOTO)
        {
            oDAO.CrearDetalleFoto(DETALLE_FOTO);
        }

        public List<DENUNCIA> ObtenerDenunciaPorUsuario(int ID_USUARIO)
        {
            return oDAO.ObtenerXUsuario(ID_USUARIO);
        }
    }
}
