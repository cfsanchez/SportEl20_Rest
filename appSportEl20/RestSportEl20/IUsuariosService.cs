using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SportEl20.BE;

namespace RestSportEl20
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuarioService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuariosService
    {
        [OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "CrearUsuario", ResponseFormat = WebMessageFormat.Json)]
        USUARIO CrearUsuario(USUARIO usuario);

        [OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "ModificarUsuario", ResponseFormat = WebMessageFormat.Json)]
        USUARIO ModificarUsuario(USUARIO usuario);

        [OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "ObtenerUsuario", ResponseFormat = WebMessageFormat.Json)]
        USUARIO ObtenerUsuario(USUARIO usuario);
    }
}
