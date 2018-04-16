using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PutBoxService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IPutBoxService
    {
        public bool Registration(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public bool Login(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public string GetData(int value)
        {
            return $"You entered: {value}";
        }

        public UserInfo GetDataUsingDataContract(UserInfo composite)
        {
            throw new NotImplementedException();
        }
    }
}
