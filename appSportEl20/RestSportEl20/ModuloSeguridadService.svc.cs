﻿using SportEl20.BE;
using SportEl20.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestSportEl20
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ModuloSeguridadService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ModuloSeguridadService.svc o ModuloSeguridadService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ModuloSeguridadService : IModuloSeguridadService
    {
        private UsuarioBL oBL = new UsuarioBL();

        public USUARIO LoginUsuario(USUARIO usuario)
        {
            try
            {
                return oBL.Login(usuario);
            }
            catch (FaultException ex)
            {
                var xe = (FaultException<ExceptionBase>)ex;
                throw new FaultException<ExceptionBase>(
                    new ExceptionBase()
                    {
                        Codigo = xe.Detail.Codigo,
                        Descripcion = xe.Detail.Descripcion,
                    }, new FaultReason(xe.Reason.ToString()));
            }
        }

        public USUARIO RecuperarContrasenia(string email)
        {
            try
            {
                return oBL.RecuperarContrasenia(email);
            }
            catch (FaultException ex)
            {
                var xe = (FaultException<ExceptionBase>)ex;
                throw new FaultException<ExceptionBase>(
                    new ExceptionBase()
                    {
                        Codigo = xe.Detail.Codigo,
                        Descripcion = xe.Detail.Descripcion,
                    }, new FaultReason(xe.Reason.ToString()));
            }
        }
    }
}
