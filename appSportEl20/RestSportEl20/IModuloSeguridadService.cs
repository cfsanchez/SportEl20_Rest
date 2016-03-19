using SportEl20.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestSportEl20
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IModuloSeguridadService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IModuloSeguridadService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "LoginUsuario", ResponseFormat = WebMessageFormat.Json)]
        USUARIO LoginUsuario(USUARIO usuario);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "RecuperarContrasenia", ResponseFormat = WebMessageFormat.Json)]
        USUARIO RecuperarContrasenia(string email);

    }
}
