using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyWCFService.Models;

namespace MyWCFService.api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IViewService" in both code and config file together.
    // NOTE: "utoken" co the dien token cua admin, "user_id" co the dien token admin
    [ServiceContract]
    public interface IViewService
    {
        [OperationContract]
        admin[] Get_admin(string token, int admin_id, int id);
        
        [OperationContract]
        category[] Get_category(int id);
        
        [OperationContract]
        comment[] Get_comment(int id);
        
        [OperationContract]
        discount[] Get_discount(int id);
        
        [OperationContract]
        image[] Get_image(int id);
        
        /// <summary>
        /// Lấy danh sách đặt hàng dựa theo mã người dùng
        /// </summary>
        /// <param name="utoken">Token của người dùng</param>
        /// <param name="user_id">ID người dùng</param>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        order[] Get_order(string utoken, int id, int? user_id, int? admin_id);
        
        [OperationContract]
        post[] Get_post(int id);
        
        [OperationContract]
        product[] Get_product(int id);
        
        [OperationContract]
        review[] Get_review(int id);
        
        [OperationContract]
        user[] Get_user(string utoken, int id, int? admin_id);

        [OperationContract]
        token[] Get_token(string token, int admin_id, int id);

        [OperationContract]
        utoken[] Get_utoken(string utoken, int user_id, int id);
    }
}
