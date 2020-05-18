using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyWCFService.Models.Entity;
using System.Data.Entity.Migrations;

namespace MyWCFService.api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AddService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AddService.svc or AddService.svc.cs at the Solution Explorer and start debugging.
    public class AddService : IAddService
    {
        private static DbStore db = new DbStore();

        #region MyFunction
        public int ID_Return(string nametable)
        {
            return db.Database.SqlQuery<int>("SELECT TOP 1 MAX(id) FROM " + nametable + " GROUP BY id ORDER BY id DESC").FirstOrDefault() + 1;
        }
        #endregion

        public string Add_admin(string token, int admin_id, int id, 
            string _username = null, string _pwd = null, string _email = null, 
            string _address = null, string _phone = null, int? _level = null, 
            string _image = null, string _fullname = null)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token)
                    && m.admin_id.Equals(admin_id)) != null)
                {
                    db.admins.Add(new admin()
                    {
                        id = id,
                        username = _username,
                        pwd = _pwd,
                        email = _email,
                        address = _address,
                        phone = _phone,
                        level = _level,
                        image = _image,
                        fullname = _fullname
                    });
                    db.SaveChanges();
                    return "Add success!";
                }
            }
            catch (Exception)
            {
                return "Add failed!";
            }
            return "Add failed!";
        }
        
        public string Add_category(string token, int admin_id, int id, 
            string _name = null, string _description = null)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token)
                    && m.admin_id.Equals(admin_id)) != null)
                {
                    db.categories.Add(new category()
                    {
                        id = id,
                        name = _name,
                        description = _description
                    });
                    db.SaveChanges();
                    return "Add success!";
                }
            }
            catch (Exception)
            {
                return "Add failed!";
            }
            return "Add failed!";
        }
        
        public string Add_comment(string utoken, int _user_id, int id, int? _product_id = null, 
            string _comments = null)
        {
            try
            {
                if (db.utokens.Where(m => m.value.Equals(utoken) && m.user_id.Equals(_user_id)) != null
                    | db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(_user_id)) != null)
                {
                    db.comments.Add(new comment()
                    {
                        id = id,
                        product_id = _product_id,
                        users_id = _user_id,
                        comments = _comments
                    });
                    db.SaveChanges();
                    return "Add success!";
                }
            }
            catch (Exception)
            {
                return "Add failed!";
            }
            return "Add failed!";
        }
        
        public string Add_discount(string token, int admin_id, int id, 
            string _value = null, string _name = null)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token)
                    && m.admin_id.Equals(admin_id)) != null)
                {
                    db.discounts.Add(new discount()
                    {
                        id = id,
                        value = _value,
                        name = _name
                    });
                    db.SaveChanges();
                    return "Add success!";
                }
            }
            catch (Exception)
            {
                return "Add failed!";
            }
            return "Add failed!";
        }
        
        public string Add_image(string token, int admin_id, int id, string _url = null, 
            int? _product_id = null)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token)
                    && m.admin_id.Equals(admin_id)) != null)
                {
                    db.images.Add(new image()
                    {
                        id = id,
                        url = _url,
                        product_id = _product_id
                    });
                    db.SaveChanges();
                    return "Add success!";
                }
            }
            catch (Exception)
            {
                return "Add failed!";
            }
            return "Add failed!";
        }
        
        public string Add_order(string utoken, int _user_id, int id, 
            string _total_money = null, string _date_create = null, string _method = null)
        {
            try
            {
                if (db.utokens.Where(m => m.value.Equals(utoken) && m.user_id.Equals(_user_id)) != null
                    | db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(_user_id)) != null)
                {
                    db.orders.Add(new order()
                    {
                        id = id,
                        users_id = _user_id,
                        total_money = _total_money,
                        date_create = DateTime.Parse(_date_create),
                        method = _method
                    });
                    db.SaveChanges();
                    return "Add success!";
                }
            }
            catch (Exception)
            {
                return "Add failed!";
            }
            return "Add failed!";
        }
        
        public string Add_post(string token, int admin_id, int id, 
            int? _product_id = null, string _name = null, 
            string _descripton = null)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token) 
                    && m.admin_id.Equals(admin_id)) != null)
                {
                    db.posts.Add(new post()
                    {
                        id = id,
                        product_id = _product_id,
                        name = _name,
                        descripton = _descripton
                    });
                    db.SaveChanges();
                    return "Add success!";
                }
            }
            catch (Exception)
            {
                return "Add failed!";
            }
            return "Add failed!";
        }
        
        public string Add_product(string token, int admin_id, int id, 
            string _sku = null, string _name = null, string _price = null, 
            string _Ghz = null, string _color = null, string _sensor = null, 
            string _cpu = null, string _ram = null, string _storage = null, 
            string _camera_front = null, string _camera_rear = null, 
            string _battery = null, string _display = null, string _sim = null, 
            string _status = null, int? _activate = null, int? _product_cate_id = null, 
            int? _discount_id = null, string _image = null)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token) 
                    && m.admin_id.Equals(admin_id)) != null)
                {
                    db.products.Add(new product()
                    {
                        id = id,
                        sku = _sku,
                        name = _name,
                        price = _price,
                        Ghz = _Ghz,
                        color = _color,
                        sensor = _sensor,
                        cpu = _cpu,
                        ram = _ram,
                        storage = _storage,
                        camera_front = _camera_front,
                        camera_rear = _camera_rear,
                        battery = _battery,
                        display = _display,
                        sim = _sim,
                        status = _status,
                        activate = _activate,
                        product_cate_id = _product_cate_id,
                        discount_id = _discount_id,
                        image = _image
                    });
                    db.SaveChanges();
                    return "Add success!";
                }
            }
            catch (Exception)
            {
                return "Add failed!";
            }
            return "Add failed!";
        }
        
        public string Add_review(string utoken, int _user_id, int id, int? _product_id = null, string _reviews = null)
        {
            try
            {
                if (db.utokens.Where(m => m.value.Equals(utoken) && m.user_id.Equals(_user_id)) != null
                    | db.tokens.Where(m => m.admin_id.Equals(_user_id) && m.value.Equals(utoken)) != null)
                {
                    db.reviews.Add(new review()
                    {
                        id = id,
                        product_id = _product_id,
                        users_id = _user_id,
                        reviews = _reviews
                    });
                    db.SaveChanges();
                    return "Add success!";
                }
            }
            catch (Exception)
            {
                return "Add failed!";
            }
            return "Add failed!";
        }

        public string Add_user(int id, string _username = null, 
            string _fullname = null, string _pwd = null, string _email = null, 
            string _address = null, string _phone = null, string _image = null, int? _activated = null)
        {
            try
            {
                db.users.Add(new user()
                {
                    id = id,
                    username = _username,
                    fullname = _fullname,
                    pwd = _pwd,
                    email = _email,
                    address = _address,
                    phone = _phone,
                    image = _image,
                    activated = _activated
                });
                db.SaveChanges();
                return "Add success!";
            }
            catch (Exception)
            {
                return "Add failed!";
            }
        }

        public string Add_order_detail(string utoken, int _user_id, int _order_id, int _product_id, int _quantity, int _money)
        {
            try
            {
                if (db.utokens.Where(m => m.value.Equals(utoken) && m.user_id.Equals(_user_id)) != null)
                {
                    db.order_detail.Add(new order_detail()
                    {
                        order_id = _order_id,
                        product_id = _product_id,
                        quantity = _quantity.ToString(),
                        money = _money.ToString()
                    });
                    db.SaveChanges();
                    return "Add success!";
                }
            }
            catch (Exception)
            {
                return "Add failed!";
            }
            return "Add failed!";
        }
    }
}
