﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitTestSportEI20.WCFUsuario {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCFUsuario.IUsuariosService")]
    public interface IUsuariosService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/CrearUsuario", ReplyAction="http://tempuri.org/IUsuariosService/CrearUsuarioResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SportEl20.BE.ExceptionBase), Action="http://tempuri.org/IUsuariosService/CrearUsuarioExceptionBaseFault", Name="ExceptionBase", Namespace="http://schemas.datacontract.org/2004/07/SportEl20.BE")]
        SportEl20.BE.USUARIO CrearUsuario(SportEl20.BE.USUARIO usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/CrearUsuario", ReplyAction="http://tempuri.org/IUsuariosService/CrearUsuarioResponse")]
        System.Threading.Tasks.Task<SportEl20.BE.USUARIO> CrearUsuarioAsync(SportEl20.BE.USUARIO usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/ModificarUsuario", ReplyAction="http://tempuri.org/IUsuariosService/ModificarUsuarioResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(SportEl20.BE.ExceptionBase), Action="http://tempuri.org/IUsuariosService/ModificarUsuarioExceptionBaseFault", Name="ExceptionBase", Namespace="http://schemas.datacontract.org/2004/07/SportEl20.BE")]
        SportEl20.BE.USUARIO ModificarUsuario(SportEl20.BE.USUARIO usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/ModificarUsuario", ReplyAction="http://tempuri.org/IUsuariosService/ModificarUsuarioResponse")]
        System.Threading.Tasks.Task<SportEl20.BE.USUARIO> ModificarUsuarioAsync(SportEl20.BE.USUARIO usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/ObtenerUsuario", ReplyAction="http://tempuri.org/IUsuariosService/ObtenerUsuarioResponse")]
        SportEl20.BE.USUARIO ObtenerUsuario(SportEl20.BE.USUARIO usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/ObtenerUsuario", ReplyAction="http://tempuri.org/IUsuariosService/ObtenerUsuarioResponse")]
        System.Threading.Tasks.Task<SportEl20.BE.USUARIO> ObtenerUsuarioAsync(SportEl20.BE.USUARIO usuario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsuariosServiceChannel : UnitTestSportEI20.WCFUsuario.IUsuariosService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsuariosServiceClient : System.ServiceModel.ClientBase<UnitTestSportEI20.WCFUsuario.IUsuariosService>, UnitTestSportEI20.WCFUsuario.IUsuariosService {
        
        public UsuariosServiceClient() {
        }
        
        public UsuariosServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsuariosServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuariosServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuariosServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SportEl20.BE.USUARIO CrearUsuario(SportEl20.BE.USUARIO usuario) {
            return base.Channel.CrearUsuario(usuario);
        }
        
        public System.Threading.Tasks.Task<SportEl20.BE.USUARIO> CrearUsuarioAsync(SportEl20.BE.USUARIO usuario) {
            return base.Channel.CrearUsuarioAsync(usuario);
        }
        
        public SportEl20.BE.USUARIO ModificarUsuario(SportEl20.BE.USUARIO usuario) {
            return base.Channel.ModificarUsuario(usuario);
        }
        
        public System.Threading.Tasks.Task<SportEl20.BE.USUARIO> ModificarUsuarioAsync(SportEl20.BE.USUARIO usuario) {
            return base.Channel.ModificarUsuarioAsync(usuario);
        }
        
        public SportEl20.BE.USUARIO ObtenerUsuario(SportEl20.BE.USUARIO usuario) {
            return base.Channel.ObtenerUsuario(usuario);
        }
        
        public System.Threading.Tasks.Task<SportEl20.BE.USUARIO> ObtenerUsuarioAsync(SportEl20.BE.USUARIO usuario) {
            return base.Channel.ObtenerUsuarioAsync(usuario);
        }
    }
}
