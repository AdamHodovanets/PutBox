﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PutBoxService
{
    [ServiceContract]
    public interface IPutBoxService
    {
        [OperationContract]
        bool Registration(UserInfo user);

        [OperationContract]
        bool Login(UserInfo user);

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        UserInfo GetDataUsingDataContract(UserInfo composite);
    }

    [DataContract]
    public class UserInfo
    {
        public UserInfo() { }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Path { get; set; }
    }
}
