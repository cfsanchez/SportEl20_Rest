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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuariosService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuariosService
    {
        [FaultContract(typeof(ExceptionBase))]
        [OperationContract]
        USUARIO CrearUsuario(USUARIO usuario);

        [FaultContract(typeof(ExceptionBase))]
        [OperationContract]
        USUARIO ModificarUsuario(USUARIO usuario);

        [OperationContract]
        USUARIO ObtenerUsuario(USUARIO usuario);
    }
}
