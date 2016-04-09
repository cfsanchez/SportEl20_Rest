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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IModuloDenunciaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IModuloDenunciaService
    {

        [OperationContract]
        List<DENUNCIA> ConsultarDenunciaUsuario(int ID_USUARIO);

    }
}
