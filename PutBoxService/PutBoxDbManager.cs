using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PutBoxService
{
    public class PutBoxDbManager
    {
        public string FtpHost { get; }
        public string UserDir { get; }
        public string FtpUser { get; }
        public string FtpPassword { get; }

        public PutBoxDbManager()
        {
            FtpHost = @"ftp://Dermand4433212@putbox.somee.com/www.putbox.somee.com/";
            UserDir = @"ftp://Dermand4433212@putbox.somee.com/www.putbox.somee.com/UserDirectories";
            FtpUser = @"Dermand4433212";
            FtpPassword = @"223d6vWn";
        }

        public bool Register(string email, string password)
        {
            using (var db = new PutBoxSqlModel())
            {
                if (db.UserDatas.Any(x => x.email == email)) return false;
                var tmpId = GetId();
                db.UserDatas.Add(new UserData()
                {
                    email = email,
                    password = password.GetHashCode().ToString(),
                    id = tmpId,
                    path = $@"/{tmpId}"
                });
                db.SaveChanges();
            }
            return true;
        }

        private static int GetId()
        {
            bool IsIdExists(int id)
            {
                using (var db = new PutBoxSqlModel())
                {
                    return db.FileDatas.Any(x => x.id == id) ||
                           db.FolderDatas.Any(x => x.id == id) ||
                           db.UserDatas.Any(x => x.id == id);
                }
            }

            using (var db = new PutBoxSqlModel())
            {
                var size = db.UserDatas.Count() + db.FileDatas.Count() + db.FolderDatas.Count();
                while (true)
                {
                    var tmpId = new Random().Next(0, size + 1);
                    if (!IsIdExists(tmpId))
                        return tmpId;
                }
            }
        }
    }
}