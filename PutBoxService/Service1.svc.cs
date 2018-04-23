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
        private PutBoxDbManager pbManager = new PutBoxDbManager();
        public bool Registration(UserInfo user) =>
            pbManager.Register(user.Email,user.Password);

        public bool Login(UserInfo user)
        {
            using (var db = new PutBoxSqlModel())
            {
                var tmpPassword = user.Password.GetHashCode().ToString();
                return db.UserDatas.Any(x => x.email == user.Email 
                                             && x.password == tmpPassword);
            }
        }

        public string GetFtpHost() => pbManager.FtpHost;
        public string GetUserDir() => pbManager.UserDir;
        public string GetFtpUser() => pbManager.FtpUser;
        public string GetFtpPassword() => pbManager.FtpPassword;

        public string GetPath(UserInfo user)
        {
            using (var db = new PutBoxSqlModel())
            {
                var tmpPassword = user.Password.GetHashCode().ToString();
                return db.UserDatas.First(x => x.email == user.Email
                                             && x.password == tmpPassword).path;
            }
        }
    }
}
