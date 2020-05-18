using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyWCFService.Models;

namespace MyWCFService.api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DeleteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DeleteService.svc or DeleteService.svc.cs at the Solution Explorer and start debugging.
    public class DeleteService : IDeleteService
    {
        private MyDBContext db = new MyDBContext();
        public string Delete_admin(string token, int admin_id, int id)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token) && m.admin_id.Equals(admin_id)) != null)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM token WHERE admin_id = " + id);
                    db.Database.ExecuteSqlCommand("DELETE FROM admin WHERE id = " + id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
            }
            catch (Exception)
            {
                return "Delete failed!";
            }
            return "Delete failed!";
        }

        public string Delete_category(string token, int admin_id, int id)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token) && m.admin_id.Equals(admin_id)) != null)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM category WHERE id = " + id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
            }
            catch (Exception)
            {
                return "Delete failed!";
            }
            return "Delete failed!";
        }

        public string Delete_comment(string utoken, int user_id, int id)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(user_id)) != null
                    | db.utokens.Where(m => m.user_id.Equals(user_id) && m.value.Equals(utoken)) != null &&
                        db.comments.Where(m => m.id.Equals(id) && m.users_id.Equals(user_id)) != null)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM comments WHERE id = " + id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
            }
            catch (Exception)
            {
                return "Delete failed!";
            }
            return "Delete failed!";
        }

        public string Delete_discount(string token, int admin_id, int id)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token) && m.admin_id.Equals(admin_id)) != null)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM discount WHERE id = " + id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
            }
            catch (Exception)
            {
                return "Delete failed!";
            }
            return "Delete failed!";
        }

        public string Delete_image(string token, int admin_id, int id)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token) && m.admin_id.Equals(admin_id)) != null)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM image WHERE id = " + id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
            }
            catch (Exception)
            {
                return "Delete failed!";
            }
            return "Delete failed!";
        }

        public string Delete_order(string utoken, int user_id, int id)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(user_id)) != null
                    | db.utokens.Where(m => m.user_id.Equals(user_id) && m.value.Equals(utoken)) != null &&
                        db.orders.Where(m => m.id.Equals(id) && m.users_id.Equals(user_id)) != null)
                {
                    if(id > 0)
                    {
                        var record = db.orders.Where(m => m.id == id).FirstOrDefault();
                        if (record.status == 1)
                            return "You cant delete this Order!";
                    }
                    
                    db.Database.ExecuteSqlCommand("DELETE FROM order_detail WHERE order_id = " + id);
                    db.Database.ExecuteSqlCommand("DELETE FROM orders WHERE id = " + id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
            }
            catch (Exception)
            {
                return "Delete failed!";
            }
            return "Delete failed!";
        }

        public string Delete_post(string token, int admin_id, int id)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token) && m.admin_id.Equals(admin_id)) != null)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM posts WHERE id = " + id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
            }
            catch (Exception)
            {
                return "Delete failed!";
            }
            return "Delete failed!";
        }

        public string Delete_product(string token, int admin_id, int id)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token) && m.admin_id.Equals(admin_id)) != null)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM posts WHERE product_id = " + id);
                    db.Database.ExecuteSqlCommand("DELETE FROM order_detail WHERE product_id = " + id);
                    db.Database.ExecuteSqlCommand("DELETE FROM comments WHERE product_id = " + id);
                    db.Database.ExecuteSqlCommand("DELETE FROM reviews WHERE product_id = " + id);
                    db.Database.ExecuteSqlCommand("DELETE FROM image WHERE product_id = " + id);

                    db.Database.ExecuteSqlCommand("DELETE FROM products WHERE id = " + id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
            }
            catch (Exception)
            {
                return "Delete failed!";
            }
            return "Delete failed!";
        }

        public string Delete_review(string utoken, int user_id, int id)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(user_id)) != null
                    | db.utokens.Where(m => m.user_id.Equals(user_id) && m.value.Equals(utoken)) != null &&
                        db.reviews.Where(m => m.id.Equals(id) && m.users_id.Equals(user_id)) != null)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM reviews WHERE id = " + id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
            }
            catch (Exception)
            {
                return "Delete failed!";
            }
            return "Delete failed!";
        }

        public string Delete_user(string utoken, int user_id, int? admin_id)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(admin_id)) != null
                    | db.utokens.Where(m => m.user_id.Equals(user_id) && m.value.Equals(utoken)) != null)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM utoken WHERE user_id = " + user_id);
                    db.Database.ExecuteSqlCommand("DELETE FROM comments WHERE users_id = " + user_id);
                    db.Database.ExecuteSqlCommand("DELETE FROM reviews WHERE users_id = " + user_id);

                    List<order> lorder = db.orders.Where(m => m.users_id == user_id).ToList();
                    foreach (order item in lorder)
                    {
                        db.Database.ExecuteSqlCommand("DELETE FROM order_detail WHERE order_id = " + item.id);
                    }

                    db.Database.ExecuteSqlCommand("DELETE FROM orders WHERE users_id = " + user_id);
                    db.Database.ExecuteSqlCommand("DELETE FROM users WHERE id = " + user_id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
            }
            catch (Exception)
            {
                return "Delete failed!";
            }
            return "Delete failed!";
        }

        public string Delete_token(string utoken, int user_id)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(user_id)) != null)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM token WHERE admin_id = " + user_id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
                else if(db.utokens.Where(m => m.value.Equals(utoken) && m.user_id.Equals(user_id)) != null)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM utoken WHERE user_id = " + user_id);
                    db.SaveChanges();
                    return "Delete record success!";
                }
            }
            catch (Exception)
            {
                return "Delete failed!";
            }
            return "Delete failed!";
        }
    }
}
