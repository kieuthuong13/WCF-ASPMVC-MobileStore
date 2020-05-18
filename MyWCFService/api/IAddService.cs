using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyWCFService.Models;

namespace MyWCFService.api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAddService" in both code and config file together.
    [ServiceContract]
    public interface IAddService
    {
        [OperationContract]
        int ID_Return(string nametable); // tra ve id tiep theo trong table "nametable"

        [OperationContract]
        string Add_admin(string token, int admin_id, int id, string _username, string _pwd, string _email, string _address, string _phone, int? _level, string _image, string _fullname);

        [OperationContract]
        string Add_category(string token, int admin_id, int id, string _name, string _description);

        [OperationContract]
        string Add_comment(string utoken, int _user_id, int id, int? _product_id, string _comments);

        [OperationContract]
        string Add_discount(string token, int admin_id, int id, string _value, string _name);

        [OperationContract]
        string Add_image(string token, int admin_id, int id, string _url, int? _product_id);

        [OperationContract]
        string Add_order(string utoken, int _user_id, int id, string _total_money, string _date_create, string _method);

        [OperationContract]
        string Add_order_detail(string utoken, int _user_id, int _order_id, int _product_id, int _quantity, int _money);

        [OperationContract]
        string Add_post(string token, int admin_id, int id, int? _product_id, string _name, string _descripton);

        [OperationContract]
        string Add_product(string token, int admin_id, int id, string _sku, string _name, string _price, string _Ghz, string _color, string _sensor, string _cpu, string _ram, string _storage, string _camera_front, string _camera_rear, string _battery, string _display, string _sim, string _status, int? _activate, int? _product_cate_id, int? _discount_id, string _image);

        [OperationContract]
        string Add_review(string utoken, int _user_id, int id, int? _product_id, string _reviews);

        [OperationContract]
        string Add_user(int id, string _username, string _fullname, string _pwd, string _email, string _address, string _phone, string _image, int? _activated);
    }
}
