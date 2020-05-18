using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyWCFService.Models;

namespace MyWCFService.api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEditService" in both code and config file together.
    [ServiceContract]
    public interface IEditService
    {
        [OperationContract]
        string Edit_admin(string token, int admin_id, int id, string _username, string _pwd, string _email, string _address, string _phone, int? _level, string _image, string _fullname);

        [OperationContract]
        string Edit_category(string token, int admin_id, int id, string _name, string _description);

        [OperationContract]
        string Edit_comment(string utoken, int user_id, int id, int? _product_id, string _comments);

        [OperationContract]
        string Edit_discount(string token, int admin_id, int id, string _value, string _name);

        [OperationContract]
        string Edit_image(string token, int admin_id, int id, string _url, int? _product_id);

        /// <summary>
        /// Khong cung cap API dieu chinh order
        /// </summary>
        /// <param name="token"></param>
        /// <param name="admin_id"></param>
        /// <param name="id"></param>
        /// <param name="_product_id"></param>
        /// <param name="_name"></param>
        /// <param name="_descripton"></param>
        /// <returns></returns>
        //[OperationContract]
        //string Edit_order(string utoken, int user_id, int id, string _total_money, string _date_create, string _method);

        [OperationContract]
        string Edit_post(string token, int admin_id, int id, int? _product_id, string _name, string _descripton);

        [OperationContract]
        string Edit_product(string token, int admin_id, int id, string _sku, string _name, string _price, string _Ghz, string _color, string _sensor, string _cpu, string _ram, string _storage, string _camera_front, string _camera_rear, string _battery, string _display, string _sim, string _status, int? _activate, int? _product_cate_id, int? _discount_id, string _image);

        [OperationContract]
        string Edit_review(string utoken, int user_id, int id, int? _product_id, string _reviews);

        [OperationContract]
        string Edit_user(string utoken, int id, int? admin_id, string _username, string _fullname, string _pwd, string _email, string _address, string _phone, string _image, int? _activated);

        /// <summary>
        /// 
        /// Chỉnh sửa token
        /// 
        /// </summary>
        /// <param name="utoken"> có thể là token của admin và user</param>
        /// <param name="user_id"> id của admin hoặc user</param>
        /// <param name="id"></param>
        /// <param name="_value"></param>
        /// <returns></returns>
        [OperationContract]
        string Edit_token(string utoken, int user_id, string _value);
    }
}
