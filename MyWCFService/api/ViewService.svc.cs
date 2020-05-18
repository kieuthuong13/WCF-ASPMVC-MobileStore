using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyWCFService.Models;

namespace MyWCFService.api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ViewService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ViewService.svc or ViewService.svc.cs at the Solution Explorer and start debugging.
    public class ViewService : IViewService
    {
        private static MyDBContext db = new MyDBContext();
        
        public admin[] Get_admin(string token, int admin_id, int id)
        {
            if (db.tokens.Where(m => m.value.Equals(token) && m.admin_id.Equals(admin_id)) != null)
                return MyClass<admin>.GetData("admin", id);
            return null;
        }

        public category[] Get_category(int id)
        {
            return MyClass<category>.GetData("category", id);
        }

        public comment[] Get_comment(int id)
        {
            return MyClass<comment>.GetData("comment", id);
        }

        public discount[] Get_discount(int id)
        {
            return MyClass<discount>.GetData("discount", id);
        }

        public image[] Get_image(int id)
        {
            return MyClass<image>.GetData("image", id);
        }

        public order[] Get_order(string utoken, int id, int? user_id = null, int? admin_id = null)
        {
            try
            {
                if (user_id != null && db.utokens.Where(m => m.value.Equals(utoken) && m.user_id.Equals(user_id)) != null)
                {
                    if (id == 0)
                        return db.orders.Where(m => m.users_id.Equals(user_id)).ToArray();
                    else
                        return db.orders.Where(m => m.users_id.Equals(user_id) && m.id.Equals(id)).ToArray();
                }
                else if (admin_id != null && db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(admin_id)) != null)
                {
                    if (id == 0)
                        return db.orders.ToArray();
                    else
                        return db.orders.Where(m => m.id.Equals(id)).ToArray();
                }
            }
            catch (Exception)
            {
                
            }
            return null;
        }

        public post[] Get_post(int id)
        {
            return MyClass<post>.GetData("post", id);
        }

        public product[] Get_product(int id)
        {
            return MyClass<product>.GetData("product", id);
        }

        public review[] Get_review(int id)
        {
            return MyClass<review>.GetData("review", id);
        }

        public token[] Get_token(string token, int admin_id, int id)
        {
            if (db.tokens.Where(m => m.value.Equals(token) && m.admin_id.Equals(admin_id)) != null)
                return MyClass<token>.GetData("token", id);
            return null;
        }

        public user[] Get_user(string utoken, int id, int? admin_id = null)
        {
            if (db.utokens.Where(m => m.value.Equals(utoken) && m.user_id.Equals(id)) != null
                | db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(admin_id)) != null)
                return MyClass<user>.GetData("user", id);
            return null;
        }

        public utoken[] Get_utoken(string utoken, int user_id, int id)
        {
            if(db.utokens.Where(m => m.value.Equals(utoken) && m.user_id.Equals(user_id)) != null
                | db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(user_id)) != null)
                return MyClass<utoken>.GetData("utoken", id);
            return null;
        }

        private class MyClass<T>
        {
            public static T[] GetData(string nametable, int id)
            {
                try
                {
                    switch (nametable)
                    {
                        case "admin":
                            if (id == 0)
                                return db.admins.Cast<T>().ToArray();
                            else if (id > 0)
                                return (from m in db.admins where m.id == id select m).Cast<T>().ToArray();
                            break;
                        case "category":
                            if (id == 0)
                                return db.categories.Cast<T>().ToArray();
                            else if (id > 0)
                                return (from m in db.categories where m.id == id select m).Cast<T>().ToArray();
                            break;
                        case "comment":
                            if (id == 0)
                                return db.comments.Cast<T>().ToArray();
                            else if (id > 0)
                                return (from m in db.comments where m.id == id select m).Cast<T>().ToArray();
                            break;
                        case "discount":
                            if (id == 0)
                                return db.discounts.Cast<T>().ToArray();
                            else if (id > 0)
                                return (from m in db.discounts where m.id == id select m).Cast<T>().ToArray();
                            break;
                        case "image":
                            if (id == 0)
                                return db.images.Cast<T>().ToArray();
                            else if (id > 0)
                                return (from m in db.images where m.id == id select m).Cast<T>().ToArray();
                            break;
                        case "order":
                            if (id == 0)
                                return db.orders.Cast<T>().ToArray();
                            else if (id > 0)
                                return (from m in db.orders where m.id == id select m).Cast<T>().ToArray();
                            break;
                        case "post":
                            if (id == 0)
                                return db.posts.Cast<T>().ToArray();
                            else if (id > 0)
                                return (from m in db.posts where m.id == id select m).Cast<T>().ToArray();
                            break;
                        case "product":
                            if (id == 0)
                                return db.products.OrderByDescending(m => m.follow).Cast<T>().ToArray();
                            else if (id > 0)
                            {
                                product record = db.products.Where(m => m.id == id).FirstOrDefault();
                                record.follow = record.follow == null ? 1 : record.follow + 1;
                                if(record != null)
                                    db.SaveChanges();

                                return (from m in db.products where m.id == id select m).Cast<T>().ToArray();
                            }
                            break;
                        case "review":
                            if (id == 0)
                                return db.reviews.Cast<T>().ToArray();
                            else if (id > 0)
                                return (from m in db.reviews where m.id == id select m).Cast<T>().ToArray();
                            break;
                        case "user":
                            if (id == 0)
                                return db.users.Cast<T>().ToArray();
                            else if (id > 0)
                                return (from m in db.users where m.id == id select m).Cast<T>().ToArray();
                            break;
                        case "token":
                            if (id == 0)
                                return db.tokens.Cast<T>().ToArray();
                            else if (id > 0)
                                return (from m in db.tokens where m.id == id select m).Cast<T>().ToArray();
                            break;
                        case "utoken":
                            if (id == 0)
                                return db.utokens.Cast<T>().ToArray();
                            else if (id > 0)
                                return (from m in db.utokens where m.id == id select m).Cast<T>().ToArray();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                return null;
            }
        }
    }
}
