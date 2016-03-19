using SportEl20.BE;
using SportEl20.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestSportEl20
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "DenunciaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione DenunciaService.svc o DenunciaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class DenunciaService : IDenunciasService
    {
        private DenunciaBL oBL = new DenunciaBL();

        public DENUNCIA CrearDenuncia(DENUNCIA denuncia)
        {
            return oBL.CrearDENUNCIA(denuncia);
        }

        public DENUNCIA ObtenerDenuncia(int ID_DENUNCIA)
        {
            return oBL.ObtenerDENUNCIA(ID_DENUNCIA);
        }

        public List<DENUNCIA> ListarDenuncia()
        {
            return oBL.ListarDENUNCIA();
        }
    }
}
