using SportEl20.BE;
using SportEl20.Util;
using SportEl20.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace SportEl20.BL
{
    public class UsuarioBL
    {
        private UsuarioDAO oDAO = new UsuarioDAO();

        public USUARIO CrearUSUARIO(USUARIO USUARIOACrear)
        {
            if (oDAO.Obtener(USUARIOACrear.EMAIL) != null)
            {
                throw new FaultException<ExceptionBase>(
                    new ExceptionBase()
                    {
                        Codigo = "101",
                        Descripcion = "El USUARIO ya existe",
                    }, new FaultReason("Error al intentar creacion"));
            }

            return oDAO.Crear(USUARIOACrear);
        }

        public USUARIO ObtenerUSUARIO(string email)
        {
            return oDAO.Obtener(email);
        }

        public USUARIO ModificarUSUARIO(USUARIO USUARIOAModificar)
        {
            if (oDAO.Obtener(USUARIOAModificar.EMAIL) == null)
            {
                throw new FaultException<ExceptionBase>(
                    new ExceptionBase()
                    {
                        Codigo = "102",
                        Descripcion = "El USUARIO no se encuentra registrado",
                    }, new FaultReason("Error al intentar modificar"));
            }

            return oDAO.Modificar(USUARIOAModificar);
        }


        public USUARIO Login(USUARIO usuario)
        {
            USUARIO obj = new USUARIO();
            obj = oDAO.Obtener(usuario.EMAIL);

            if (obj.PASSWORD.Equals(usuario.PASSWORD))
            {
                throw new FaultException<ExceptionBase>(
                    new ExceptionBase()
                    {
                        Codigo = "102",
                        Descripcion = "El Usuario o Contraseña son incorrecto",
                    }, new FaultReason("Error al intentar logearse"));
            }

            return obj;
        }

        public USUARIO RecuperarContrasenia(string email)
        {
            USUARIO obj = null;
            obj = oDAO.Obtener(email);

            if (obj == null)
            {
                throw new FaultException<ExceptionBase>(
                    new ExceptionBase()
                    {
                        Codigo = "103",
                        Descripcion = "El Usuario no existe",
                    }, new FaultReason("Error al intentar recuperar contraseña"));
            }


            Email oEmail = new Email()
            {
                EmailTo = obj.EMAIL,
                Cuerpo = "Su contraseña de la app es " + obj.PASSWORD,
                Asunto = "Recuperar contraseña"
            };


            Comun comun = new Comun();
            comun.Enviar(oEmail);

            return obj;
        }
    }
}
