using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etech.AlphaMightyFoxtrot
{
    class Promotion
    {
        public int PromotionId { get; set; }
        public string Discount { get; set; }
        public string CategoryId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductId { get; set; }

        public List<string> GetPromotion()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Promotion";
            string Column = "Discount";
            List<string> Discount = oracleDB.SelectFromDBReader(TableName, Column);
            return Discount;
        }

        public string AddPromotion()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Promotion";
            string Values = "SEQ_Promotion.nextval," + Discount;
            string err = oracleDB.InsertIntoDB(TableName, Values);
            return err;
        }

        public string AddProductsOnPromotionOfACategory()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Product";
            string Values = "Promotion_Id = " + PromotionId.ToString();
            string Where = "Category_Id = " + CategoryId;
            string err = oracleDB.UpdateWhereDB(TableName, Values, Where);
            return err;
        }

        public string AddProductsOnPromotion()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Product";
            string Values = "Promotion_Id = " + PromotionId.ToString();
            string Where = "Product_Id = " + ProductId;
            string err = oracleDB.UpdateWhereDB(TableName, Values, Where);
            return err;
        }
    }
}
