using System;
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
        private int _id;
        private string _email;
        private string _password;
        private string path;

        public UserInfo(int id, string email, string password)
        {
            this._id = id;
            this._email = email;
            this._password = password;
        }

    }
}
