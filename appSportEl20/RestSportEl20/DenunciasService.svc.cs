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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "DenunciasService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione DenunciasService.svc o DenunciasService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class DenunciasService : IDenunciasService
    {
        private DenunciaBL oBL = new DenunciaBL();

        public DENUNCIA CrearDenuncia(DENUNCIA denuncia)
        {
            return oBL.CrearDenuncia(denuncia);
        }

        public DENUNCIA ObtenerDenuncia(string id)
        {
            int ID_DENUNCIA = 0;
            int.TryParse(id, out ID_DENUNCIA);
            return oBL.ObtenerDenuncia(ID_DENUNCIA);
        }

        public DENUNCIA ModificarDenuncia(DENUNCIA DenunciaModificar)
        {
            return oBL.ModificarDenuncia(DenunciaModificar);
        }

        public void EliminarDenuncia(string id)
        {
            int ID_DENUNCIA = 0;
            int.TryParse(id, out ID_DENUNCIA);
            oBL.EliminarDenuncia(ID_DENUNCIA);
        }

        public List<DENUNCIA> ListarDenuncia()
        {
            return oBL.ListarDenuncia();
        }

        public void CrearDetalleFoto(List<DETALLE_FOTO> DETALLE_FOTO)
        {
            oBL.CrearDetalleFoto(DETALLE_FOTO);
        }
    }
}
