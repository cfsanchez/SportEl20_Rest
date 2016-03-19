using SportEl20.BE;
using SportEl20.Util;
using SportEl20.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace SportEl20.BL
{
    public class DenunciaBL
    {

        private DenunciaADO oDAO = new DenunciaADO();

        public DENUNCIA CrearDENUNCIA(DENUNCIA DENUNCIAACrear)
        {

            return oDAO.Crear(DENUNCIAACrear);
        }

        public DENUNCIA ObtenerDENUNCIA(int ID_DENUNCIA)
        {
            return oDAO.Obtener(ID_DENUNCIA);
        }

        public List<DENUNCIA> ObtenerDENUNCIAXUsuario(int ID_USUARIO)
        {
            return oDAO.ObtenerXUsuario(ID_USUARIO);
        }

        public List<DENUNCIA> ListarDENUNCIA()
        {
            return oDAO.Listar();
        }


        public DENUNCIA RegistrarDenuncia(DENUNCIA DENUNCIAACrear)
        {
            List<DENUNCIA> denuciaAcumulada = oDAO.ObtenerXUsuario(DENUNCIAACrear.ID_USUARIO);
            DateTime hoy = DateTime.Now.Date;
            var nunDenunciaDia = denuciaAcumulada.Where(x => x.FECHADENUNCIA >= hoy).Count();

            if (nunDenunciaDia > 5)
            {
                throw new FaultException<ExceptionBase>(
                    new ExceptionBase()
                    {
                        Codigo = "101",
                        Descripcion = "Exedio el numero maximo de denuncia por dia",
                    }, new FaultReason("Error al intentar creacion"));
            }

            return oDAO.Crear(DENUNCIAACrear);
        }

    }
}
