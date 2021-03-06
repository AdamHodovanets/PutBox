﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PutBoxDesktop.PutBoxSvc {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserInfo", Namespace="http://schemas.datacontract.org/2004/07/PutBoxService")]
    [System.SerializableAttribute()]
    public partial class UserInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PathField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Path {
            get {
                return this.PathField;
            }
            set {
                if ((object.ReferenceEquals(this.PathField, value) != true)) {
                    this.PathField = value;
                    this.RaisePropertyChanged("Path");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PutBoxSvc.IPutBoxService")]
    public interface IPutBoxService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/Registration", ReplyAction="http://tempuri.org/IPutBoxService/RegistrationResponse")]
        bool Registration(PutBoxDesktop.PutBoxSvc.UserInfo user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/Registration", ReplyAction="http://tempuri.org/IPutBoxService/RegistrationResponse")]
        System.Threading.Tasks.Task<bool> RegistrationAsync(PutBoxDesktop.PutBoxSvc.UserInfo user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetUserDir", ReplyAction="http://tempuri.org/IPutBoxService/GetUserDirResponse")]
        string GetUserDir();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetUserDir", ReplyAction="http://tempuri.org/IPutBoxService/GetUserDirResponse")]
        System.Threading.Tasks.Task<string> GetUserDirAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/Login", ReplyAction="http://tempuri.org/IPutBoxService/LoginResponse")]
        bool Login(PutBoxDesktop.PutBoxSvc.UserInfo user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/Login", ReplyAction="http://tempuri.org/IPutBoxService/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(PutBoxDesktop.PutBoxSvc.UserInfo user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetPath", ReplyAction="http://tempuri.org/IPutBoxService/GetPathResponse")]
        string GetPath(PutBoxDesktop.PutBoxSvc.UserInfo user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetPath", ReplyAction="http://tempuri.org/IPutBoxService/GetPathResponse")]
        System.Threading.Tasks.Task<string> GetPathAsync(PutBoxDesktop.PutBoxSvc.UserInfo user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetFtpHost", ReplyAction="http://tempuri.org/IPutBoxService/GetFtpHostResponse")]
        string GetFtpHost();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetFtpHost", ReplyAction="http://tempuri.org/IPutBoxService/GetFtpHostResponse")]
        System.Threading.Tasks.Task<string> GetFtpHostAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetFtpUser", ReplyAction="http://tempuri.org/IPutBoxService/GetFtpUserResponse")]
        string GetFtpUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetFtpUser", ReplyAction="http://tempuri.org/IPutBoxService/GetFtpUserResponse")]
        System.Threading.Tasks.Task<string> GetFtpUserAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetFtpPassword", ReplyAction="http://tempuri.org/IPutBoxService/GetFtpPasswordResponse")]
        string GetFtpPassword();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetFtpPassword", ReplyAction="http://tempuri.org/IPutBoxService/GetFtpPasswordResponse")]
        System.Threading.Tasks.Task<string> GetFtpPasswordAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPutBoxServiceChannel : PutBoxDesktop.PutBoxSvc.IPutBoxService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PutBoxServiceClient : System.ServiceModel.ClientBase<PutBoxDesktop.PutBoxSvc.IPutBoxService>, PutBoxDesktop.PutBoxSvc.IPutBoxService {
        
        public PutBoxServiceClient() {
        }
        
        public PutBoxServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PutBoxServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PutBoxServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PutBoxServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Registration(PutBoxDesktop.PutBoxSvc.UserInfo user) {
            return base.Channel.Registration(user);
        }
        
        public System.Threading.Tasks.Task<bool> RegistrationAsync(PutBoxDesktop.PutBoxSvc.UserInfo user) {
            return base.Channel.RegistrationAsync(user);
        }
        
        public string GetUserDir() {
            return base.Channel.GetUserDir();
        }
        
        public System.Threading.Tasks.Task<string> GetUserDirAsync() {
            return base.Channel.GetUserDirAsync();
        }
        
        public bool Login(PutBoxDesktop.PutBoxSvc.UserInfo user) {
            return base.Channel.Login(user);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(PutBoxDesktop.PutBoxSvc.UserInfo user) {
            return base.Channel.LoginAsync(user);
        }
        
        public string GetPath(PutBoxDesktop.PutBoxSvc.UserInfo user) {
            return base.Channel.GetPath(user);
        }
        
        public System.Threading.Tasks.Task<string> GetPathAsync(PutBoxDesktop.PutBoxSvc.UserInfo user) {
            return base.Channel.GetPathAsync(user);
        }
        
        public string GetFtpHost() {
            return base.Channel.GetFtpHost();
        }
        
        public System.Threading.Tasks.Task<string> GetFtpHostAsync() {
            return base.Channel.GetFtpHostAsync();
        }
        
        public string GetFtpUser() {
            return base.Channel.GetFtpUser();
        }
        
        public System.Threading.Tasks.Task<string> GetFtpUserAsync() {
            return base.Channel.GetFtpUserAsync();
        }
        
        public string GetFtpPassword() {
            return base.Channel.GetFtpPassword();
        }
        
        public System.Threading.Tasks.Task<string> GetFtpPasswordAsync() {
            return base.Channel.GetFtpPasswordAsync();
        }
    }
}
