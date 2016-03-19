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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ModuloDenunciaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ModuloDenunciaService.svc o ModuloDenunciaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ModuloDenunciaService : IModuloDenunciaService
    {
        private DenunciaBL oBL = new DenunciaBL();

        public DENUNCIA RegistrarDenuncia(DENUNCIA denuncia)
        {
            return oBL.RegistrarDenuncia(denuncia);
        }

        public DENUNCIA ConsultarDenunciaUsuario(int ID_USUARIO)
        {
            return oBL.ObtenerDENUNCIA(ID_USUARIO);
        }
    }
}
