using System;
using System.Collections.Generic;
using System.IO;
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
                return db.UserDatas.Any(x => x.email == user.Email 
                                             && x.password == tmpPassword.GetHashCode().ToString());
            }
        }

        public string GetFtpHost() => File.ReadLines("FtpInfo.txt").ElementAt(0);
        public string GetFtpUser() => File.ReadLines("FtpInfo.txt").ElementAt(1);
        public string GetFtpPassword => File.ReadLines("FtpInfo.txt").ElementAt(2);
    }
}
