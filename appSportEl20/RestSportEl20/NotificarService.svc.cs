using SportEl20.BE;
using SportEl20.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestSportEl20
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "NotificarService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione NotificarService.svc o NotificarService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class NotificarService : INotificarService
    {
        public bool EnvioarEmail(Email email)
        {
            Comun onj = new Comun();

            return onj.Enviar(email);
        }
    }
}
