using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etech.AlphaMightyFoxtrot
{
    class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public int CartItemId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public float OrderProgress { get; set; }
        public char DeliveryStatus { get; set; }
        public int DiscountReceived { get; set; }
        public float Total { get; set; }
        public float GrandTotal { get; set; }

        public string AddCart()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Cart";
            string Values = "SEQ_CartId.nextval," + CustomerId.ToString() + ","  + OrderProgress.ToString() + ","  + DiscountReceived.ToString() + "," + Total.ToString() + "," + GrandTotal.ToString();
            string err = oracleDB.InsertIntoDB(TableName, Values);
            return err;
        }

        public List<string> getCartIds()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Cart";
            string Column = "Cart_Id";
            List<string> result = oracleDB.SelectFromDBReader(TableName, Column);
            return result;
        }
    }
}
