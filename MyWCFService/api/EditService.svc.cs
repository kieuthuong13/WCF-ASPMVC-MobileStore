using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity.Migrations;
using MyWCFService.Models.Entity;

namespace MyWCFService.api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EditService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EditService.svc or EditService.svc.cs at the Solution Explorer and start debugging.
    public class EditService : IEditService
    {
        private static DbStore db = new DbStore();
        public string Edit_admin(string token, int admin_id, int id, string _username = null, string _pwd = null, string _email = null, string _address = null, string _phone = null, int? _level = null, string _image = null, string _fullname = null)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(token) && m.admin_id.Equals(admin_id)) != null)
                {
                    var record = db.admins.Where(m => m.id == id).FirstOrDefault();
                    record.username = _username ?? record.username;
                    record.pwd = _pwd ?? record.pwd;
                    record.email = _email ?? record.email;
                    record.address = _address ?? record.address;
                    record.phone = _phone ?? record.phone;
                    record.level = _level ?? record.level;
                    record.image = _image ?? record.image;
                    record.fullname = _fullname ?? record.fullname;

                    db.admins.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
            }
            catch (Exception)
            {
                return "Edit failed!";
            }
            return "Edit failed!";
        }

        public string Edit_category(string token, int admin_id, int id, string _name = null, string _description = null)
        {
            try
            {
                if(db.tokens.Where(m => m.admin_id.Equals(admin_id) && m.value.Equals(token)) != null)
                {
                    var record = db.categories.Where(m => m.id == id).FirstOrDefault();
                    record.name = _name ?? record.name;
                    record.description = _description ?? record.name;

                    db.categories.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
            }
            catch (Exception)
            {
                return "Edit failed!";
            }
            return "Edit failed!";
        }

        public string Edit_comment(string utoken, int user_id, int id, int? _product_id = null, string _comments = null)
        {
            try
            {
                // quản trị viên được phép hay đổi product_id và comment
                if (db.tokens.Where(m => m.admin_id.Equals(user_id) && m.value.Equals(utoken)) != null)
                {
                    var record = db.comments.Where(m => m.id == id).FirstOrDefault();
                    record.product_id = _product_id ?? record.product_id;
                    record.comments = _comments ?? record.comments;

                    db.comments.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
                // người dùng được phép thay đổi comment
                else if(db.utokens.Where(m => m.user_id.Equals(user_id) && m.value.Equals(utoken)) != null &&
                        db.comments.Where(m => m.users_id.Equals(user_id) && m.id.Equals(id)) != null)
                {
                    var record = db.comments.Where(m => m.id == id).FirstOrDefault();
                    record.comments = _comments ?? record.comments;

                    db.comments.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
            }
            catch (Exception)
            {
                return "Edit failed!";
            }
            return "Edit failed!";
        }

        public string Edit_discount(string token, int admin_id, int id, string _value = null, string _name = null)
        {
            try
            {
                if (db.tokens.Where(m => m.admin_id.Equals(admin_id) && m.value.Equals(token)) != null)
                {
                    var record = db.discounts.Where(m => m.id == id).FirstOrDefault();
                    record.value = _value ?? record.value;
                    record.name = _name ?? record.name;

                    db.discounts.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
            }
            catch (Exception)
            {
                return "Edit failed!";
            }
            return "Edit failed!";
        }

        public string Edit_image(string token, int admin_id, int id, string _url = null, int? _product_id = null)
        {
            try
            {
                if (db.tokens.Where(m => m.admin_id.Equals(admin_id) && m.value.Equals(token)) != null)
                {
                    var record = db.images.Where(m => m.id == id).FirstOrDefault();
                    record.url = _url ?? record.url;
                    record.product_id = _product_id ?? record.product_id;

                    db.images.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
            }
            catch (Exception)
            {
                return "Edit failed!";
            }
            return "Edit failed!";
        }

        //public string Edit_order(string utoken, int user_id, int id, string _total_money = null, string _date_create = null, string _method = null)
        //{
        //    try
        //    {
        //        if (db.utokens.Where(m => m.user_id.Equals(user_id) && m.value.Equals(utoken)) != null)
        //        {
        //            var record = db.orders.Where(m => m.id == id).FirstOrDefault();
        //            record.users_id = _user_id ?? record.users_id;
        //            record.total_money = _total_money ?? record.total_money;
        //            record.date_create = string.IsNullOrWhiteSpace(_date_create) ? record.date_create : DateTime.Parse(_date_create);
        //            record.method = _method ?? record.method;

        //            db.orders.AddOrUpdate(record);
        //            db.SaveChanges();
        //            return "Edit success!";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return "Edit failed!";
        //    }
        //    return "Edit failed!";
        //}

        public string Edit_post(string token, int admin_id, int id, int? _product_id = null, string _name = null, string _descripton = null)
        {
            try
            {
                if (db.tokens.Where(m => m.admin_id.Equals(admin_id) && m.value.Equals(token)) != null)
                {
                    var record = db.posts.Where(m => m.id == id).FirstOrDefault();
                    record.product_id = _product_id ?? record.product_id;
                    record.name = _name ?? record.name;
                    record.descripton = _descripton ?? record.descripton;

                    db.posts.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
            }
            catch (Exception)
            {
                return "Edit failed!";
            }
            return "Edit failed!";
        }

        public string Edit_product(string token, int admin_id, int id, string _sku = null, string _name = null, string _price = null, string _Ghz = null, string _color = null, string _sensor = null, string _cpu = null, string _ram = null, string _storage = null, string _camera_front = null, string _camera_rear = null, string _battery = null, string _display = null, string _sim = null, string _status = null, int? _activate = null, int? _product_cate_id = null, int? _discount_id = null, string _image = null)
        {
            try
            {
                if (db.tokens.Where(m => m.admin_id.Equals(admin_id) && m.value.Equals(token)) != null)
                {
                    var record = db.products.Where(m => m.id == id).FirstOrDefault();
                    record.sku = _sku ?? record.sku;
                    record.name = _name ?? record.name;
                    record.price = _price ?? record.price;
                    record.Ghz = _Ghz ?? record.Ghz;
                    record.color = _color ?? record.color;
                    record.sensor = _sensor ?? record.sensor;
                    record.cpu = _cpu ?? record.cpu;
                    record.ram = _ram ?? record.ram;
                    record.storage = _storage ?? record.storage;
                    record.camera_front = _camera_front ?? record.camera_front;
                    record.camera_rear = _camera_rear ?? record.camera_rear;
                    record.battery = _battery ?? record.battery;
                    record.display = _display ?? record.display;
                    record.sim = _sim ?? record.sim;
                    record.status = _status ?? record.status;
                    record.activate = _activate ?? record.activate;
                    record.product_cate_id = _product_cate_id ?? record.product_cate_id;
                    record.discount_id = _discount_id ?? record.discount_id;
                    record.image = _image ?? record.image;

                    db.products.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
            }
            catch (Exception)
            {
                return "Edit failed!";
            }
            return "Edit failed!";
        }

        public string Edit_review(string utoken, int user_id, int id, int? _product_id = null, string _reviews = null)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(user_id)) != null
                    | db.utokens.Where(m => m.value.Equals(utoken) && m.user_id.Equals(user_id)) != null &&
                        db.reviews.Where(m => m.users_id.Equals(user_id) && m.id.Equals(id)) != null)
                {
                    var record = db.reviews.Where(m => m.id == id).FirstOrDefault();
                    record.product_id = _product_id ?? record.product_id;
                    record.reviews = _reviews ?? record.reviews;

                    db.reviews.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
            }
            catch (Exception)
            {
                return "Edit failed!";
            }
            return "Edit failed!";
        }

        public string Edit_user(string utoken, int id, int? admin_id = null, 
            string _username = null, string _fullname = null, 
            string _pwd = null, string _email = null, string _address = null, 
            string _phone = null, string _image = null, int? _activated = null)
        {
            try
            {
                if (db.tokens.Where(m => m.value.Equals(utoken) && m.admin_id.Equals(admin_id)) != null
                    | db.utokens.Where(m => m.value.Equals(utoken) && m.user_id.Equals(id)) != null)
                {
                    var record = db.users.Where(m => m.id == id).FirstOrDefault();
                    record.username = _username ?? record.username;
                    record.fullname = _fullname ?? record.fullname;
                    record.pwd = _pwd ?? record.pwd;
                    record.email = _email ?? record.email;
                    record.address = _address ?? record.address;
                    record.phone = _phone ?? record.phone;
                    record.image = _image ?? record.image;
                    record.activated = _activated ?? record.activated;

                    db.users.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
            }
            catch (Exception)
            {
                return "Edit failed!";
            }
            return "Edit failed!";
        }

        public string Edit_token(string utoken, int user_id, string _value)
        {
            try
            {
                if (db.tokens.Where(m => m.admin_id.Equals(user_id) && m.value.Equals(utoken)) != null)
                {
                    var record = db.tokens.Where(m => m.admin_id.Equals(user_id)).FirstOrDefault();
                    record.value = _value ?? record.value;

                    db.tokens.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
                else if (db.utokens.Where(m => m.user_id.Equals(user_id) && m.value.Equals(utoken)) != null)
                {
                    var record = db.utokens.Where(m => m.user_id.Equals(user_id)).FirstOrDefault();
                    record.value = _value ?? record.value;

                    db.utokens.AddOrUpdate(record);
                    db.SaveChanges();
                    return "Edit success!";
                }
            }
            catch (Exception)
            {
                return "Edit failed!";
            }
            return "Edit failed!";
        }
    }
}
