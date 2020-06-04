using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyWCFService.Models.Entity;
using MyWCFService.Models.Function;

namespace MyWCFService.api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        private dbContext db = new dbContext();
        private MyWCFService.api.AddService addSV = new AddService();

        public string LoginAdmin(string email, string password, out int id)
        {
            var ad = db.admins.FirstOrDefault(m => m.email == email && m.pwd == password);
            if (ad != null)
            {
                string token = Hash.CreateToken();
                db.tokens.Add(new token()
                {
                    id = addSV.ID_Return("token"),
                    admin_id = ad.id,
                    value = token
                });
                db.SaveChanges();
                id = ad.id;
                return token;
            }
            id = -1;
            return null;
        }

        public string LoginUser(string username, string password, out int id)
        {
            var user = db.users.FirstOrDefault(m => m.username == username && m.pwd == password);
            if (user != null)
            {
                string token = Hash.CreateToken();
                db.utokens.Add(new utoken()
                {
                    id = addSV.ID_Return("utoken"),
                    user_id = user.id,
                    value = token
                });
                db.SaveChanges();
                id = user.id;
                return token;
            }
            id = -1;
            return null;
        }
        public string DeleteToken(string nameLogin, string nametable, string oldToken)
        {
            try
            {
                switch (nametable)
                {
                    case "admin":
                        // login by email
                        var adm = db.admins.FirstOrDefault(m => m.email.Equals(nameLogin));
                        if (db.tokens.Where(m => m.admin_id.Equals(adm.id) && m.value == oldToken) != null)
                        {
                            db.Database.ExecuteSqlCommand("DELETE token WHERE admin_id = " + adm.id);
                            db.SaveChanges();
                        }
                        return "Delete token success!";
                    case "user":
                        // login by username
                        var user = db.users.FirstOrDefault(m => m.username.Equals(nameLogin));
                        if (db.utokens.Where(m => m.user_id.Equals(user.id) && m.value == oldToken) != null)
                        {
                            db.Database.ExecuteSqlCommand("DELETE utoken WHERE user_id = " + user.id);
                            db.SaveChanges();
                        }
                        return "Delete token success!";
                    default:
                        break;
                }
                return "Delete token failed!";
            }
            catch (Exception)
            {
                return "Delete token failed!";
            }
        }
    }
}
