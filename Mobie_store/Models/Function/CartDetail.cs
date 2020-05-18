using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mobie_store.ViewService;

namespace Mobie_store.Models.Function
{
    public class CartDetail
    {
        public CartDetail() { }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
        public int? Price { get; set; }
        public int Quantity { get; set; }

        public static CartDetail Post(product prAdd, int SoLuong)
        {
            string price = null;
            foreach (char item in prAdd.price)
            {
                if (item != '.')
                {
                    price += item;
                }
            }
            CartDetail newCartDetail = new CartDetail();
            newCartDetail.ID = prAdd.id;
            newCartDetail.Name = prAdd.name;
            newCartDetail.Price = int.Parse(price);
            newCartDetail.Images = prAdd.image;
            newCartDetail.Quantity = SoLuong;
            return newCartDetail;
        }
    }
}