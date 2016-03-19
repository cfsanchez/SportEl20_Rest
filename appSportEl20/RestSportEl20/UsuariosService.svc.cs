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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UsuariosService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UsuariosService.svc o UsuariosService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UsuariosService : IUsuariosService
    {
        private UsuarioBL oBL = new UsuarioBL();
        public USUARIO CrearUsuario(USUARIO usuario)
        {
            return oBL.CrearUSUARIO(usuario);
        }

        public USUARIO ModificarUsuario(USUARIO usuario)
        {
            return oBL.ModificarUSUARIO(usuario);
        }

        public USUARIO ObtenerUsuario(USUARIO usuario)
        {
            return oBL.ObtenerUSUARIO(usuario.EMAIL);
        }
    }
}
