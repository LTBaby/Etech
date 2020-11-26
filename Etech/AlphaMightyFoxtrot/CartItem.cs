using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etech.AlphaMightyFoxtrot
{
    class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }

        public string AddCartItem()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Cart_Item";
            string Values = "SEQ_CartItemId.nextval," + CartId.ToString() + "," + ProductId.ToString() + "," + Quantity.ToString() + "," + Price.ToString() + "," + Discount.ToString();
            string err = oracleDB.InsertIntoDB(TableName, Values);
            return err;
        }
    }
}
