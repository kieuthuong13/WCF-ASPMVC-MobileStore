using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWCFService.api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDeleteService" in both code and config file together.
    [ServiceContract]
    public interface IDeleteService
    {
        [OperationContract]
        string Delete_admin(string token, int admin_id, int id);

        [OperationContract]
        string Delete_category(string token, int admin_id, int id);

        [OperationContract]
        string Delete_comment(string utoken, int user_id, int id);

        [OperationContract]
        string Delete_discount(string token, int admin_id, int id);

        [OperationContract]
        string Delete_image(string token, int admin_id, int id);

        [OperationContract]
        string Delete_order(string utoken, int user_id, int id);

        [OperationContract]
        string Delete_post(string token, int admin_id, int id);

        [OperationContract]
        string Delete_product(string token, int admin_id, int id);

        [OperationContract]
        string Delete_review(string utoken, int user_id, int id);

        [OperationContract]
        string Delete_user(string utoken, int user_id, int? admin_id);

        [OperationContract]
        string Delete_token(string utoken, int user_id);
    }
}
