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
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/Login", ReplyAction="http://tempuri.org/IPutBoxService/LoginResponse")]
        bool Login(PutBoxDesktop.PutBoxSvc.UserInfo user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/Login", ReplyAction="http://tempuri.org/IPutBoxService/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(PutBoxDesktop.PutBoxSvc.UserInfo user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetData", ReplyAction="http://tempuri.org/IPutBoxService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetData", ReplyAction="http://tempuri.org/IPutBoxService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IPutBoxService/GetDataUsingDataContractResponse")]
        PutBoxDesktop.PutBoxSvc.UserInfo GetDataUsingDataContract(PutBoxDesktop.PutBoxSvc.UserInfo composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutBoxService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IPutBoxService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<PutBoxDesktop.PutBoxSvc.UserInfo> GetDataUsingDataContractAsync(PutBoxDesktop.PutBoxSvc.UserInfo composite);
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
        
        public bool Login(PutBoxDesktop.PutBoxSvc.UserInfo user) {
            return base.Channel.Login(user);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(PutBoxDesktop.PutBoxSvc.UserInfo user) {
            return base.Channel.LoginAsync(user);
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public PutBoxDesktop.PutBoxSvc.UserInfo GetDataUsingDataContract(PutBoxDesktop.PutBoxSvc.UserInfo composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<PutBoxDesktop.PutBoxSvc.UserInfo> GetDataUsingDataContractAsync(PutBoxDesktop.PutBoxSvc.UserInfo composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}
