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
        public bool Registration(UserInfo user) =>
        new PutBoxDbManager().Register(user.Email,user.Password);

        public bool Login(UserInfo user)
        {
            using (var db = new PutBoxSqlModel())
            {
                var tmpPassword = user.Password.GetHashCode().ToString();
                return db.UserDatas.Any(x => x.email == user.Email && x.password == tmpPassword);
            }
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
