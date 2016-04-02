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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IModuloSeguridadService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IModuloSeguridadService
    {
        [FaultContract(typeof(ExceptionBase))]
        [OperationContract]
        USUARIO LoginUsuario(USUARIO usuario);

        [FaultContract(typeof(ExceptionBase))]
        [OperationContract]
        USUARIO RecuperarContrasenia(string email);

    }
}
