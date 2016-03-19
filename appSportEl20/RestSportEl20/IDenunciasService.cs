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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IDenunciaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IDenunciasService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CrearDenuncia", ResponseFormat = WebMessageFormat.Json)]
        DENUNCIA CrearDenuncia(DENUNCIA denuncia);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ObtenerDenuncia", ResponseFormat = WebMessageFormat.Json)]
        DENUNCIA ObtenerDenuncia(int ID_DENUNCIA);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ListarDenuncia", ResponseFormat = WebMessageFormat.Json)]
        List<DENUNCIA> ListarDenuncia();
    }
}
