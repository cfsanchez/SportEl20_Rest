using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SportEl20.BE;
using System.ServiceModel.Web;

namespace RestSportEl20
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IDenunciasService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IDenunciasService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Denuncias", ResponseFormat = WebMessageFormat.Json)]
        DENUNCIA CrearDenuncia(DENUNCIA DenunciaCrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Denuncias/{id}", ResponseFormat = WebMessageFormat.Json)]
        DENUNCIA ObtenerDenuncia(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Denuncias", ResponseFormat = WebMessageFormat.Json)]
        DENUNCIA ModificarDenuncia(DENUNCIA DenunciaModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Denuncias/{id}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarDenuncia(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Denuncias", ResponseFormat = WebMessageFormat.Json)]
        List<DENUNCIA> ListarDenuncia();
    }
}
