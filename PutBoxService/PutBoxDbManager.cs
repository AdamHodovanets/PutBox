using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PutBoxService
{
    internal interface IPutBoxDbManager
    {
        bool Register(string email, string password);
        bool Login(string email, string password);

    }
    public class PutBoxDbManager : IPutBoxDbManager
    {
        public bool Register(string email, string password)
        {
            using (var db = new PutBoxSqlModel())
            {
                if (db.UserDatas.Any(x => x.email == email)) return false;
                // credentials
                int tmpId = GetId();
                db.UserDatas.Add(new UserData()
                {
                    email = email,
                    password = password.GetHashCode().ToString(),
                    id = tmpId,
                    path = "ftp://Dermand4433212@putbox.somee.com/www.putbox.somee.com/UserDirectories/" + tmpId
                });
                db.SaveChanges();
            }
            return true;
        }

        public bool Login(string email, string password)
        {
            using (var dbl = new PutBoxSqlModel())
            {
                return dbl.UserDatas.Any(x => x.email == email);
            }
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