using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.Diagnostics;
using Dapper;
using Mobie_store.ViewService;
using Mobie_store.AddService;
using Mobie_store.Hellper;
using System.Data;
using Mobile_store.Models.Function;

namespace Mobie_store.Models.Function
{
    public class orderFnc
    {
        public orderFnc()
        {
        }
        private ViewServiceClient viewSV = new ViewServiceClient();
        private AddServiceClient addSV = new AddServiceClient();
        public int id { get; set; }

        public int? users_id { get; set; }

        public int total_money { get; set; }

        public DateTime? date_create { get; set; }

        public string method { get; set; }

        public int Status { get; set; }

        public string FullName { get; set; }

        public bool Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public List<order_detail> orderDetail { set; get; }
        
        /// <summary>
        ///  Thực hiện thanh toán hoá đơn + lưu vào database
        /// </summary>
        /// <param name="lst"></param>
        /// <returns>
        ///     true nếu thanh toán + lưu vào database thành công, ngược lại false
        /// </returns>
        public bool CreateBill(List<CartDetail> lst)
        {
            #region Older code
            /*
            int check = -1;
            using (var db = SetupConnection.ConnectionFactory())
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    using (var transaction = db.BeginTransaction())
                    {
                        check = db.Execute("CreateBill",
                            new
                            {
                                date_create = this.date_create,
                                users_id = this.users_id,
                                total_money = this.total_money,
                                method = this.method,
                                Status = this.Status,
                                FullName = this.FullName,
                                Email = this.Email,
                                Address = this.Address,
                                Phone = this.Phone,
                                Gender = this.Gender
                            },
                            commandType: CommandType.StoredProcedure,
                            transaction: transaction);
                        transaction.Commit();

                        // Create Detai Bill
                        int currentBill = db.QuerySingleOrDefault<int>("SELECT IDENT_CURRENT ('orders')");
                        if (!CreateBillDetail(lst, currentBill))
                        {
                            return false;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                    return false;
                }
            }
            if (check >= 1) return true;
            else return false;
            */
            #endregion

            #region New code
            /*
            int total_money = 0;
            foreach (var item in lst)
            {
                total_money += item.Quantity * (item.Price??0);
            }

            if (addSV.Add_order(
                Session["utoken"] as string,
                (Session["user"] as Mobie_store.ViewService.user).id,
                addSV.ID_Return("orders"),
                total_money,
                DateTime.Now.ToString(),
                "COD").Equals("Add success!"))
                return true;
            else
                return false;
                */
            #endregion
            return false;
        }

        public bool CreateBillDetail(List<CartDetail> lst, int currentBill)
        {
            int check = -1;
            try
            {
                using (var db = SetupConnection.ConnectionFactory())
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    foreach (CartDetail sp in lst)
                    {
                        using (var transaction = db.BeginTransaction())
                        {
                            check = db.Execute("ins_BillDetail",
                                new
                                {
                                    order_id = currentBill,
                                    quantity = sp.Quantity,
                                    money = sp.Price,
                                    product_id = sp.ID,
                                },
                                commandType: CommandType.StoredProcedure,
                                transaction: transaction);
                            transaction.Commit();
                        }
                    }
                }
                if (check >= 1) return true;
                return false;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return false;
            }
        }
    }
}