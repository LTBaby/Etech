using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;


namespace Etech.AlphaMightyFoxtrot
{
    class Product
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public float Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public char Active { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }

        public byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public string AddProduct()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Product";
            string Values = "SEQ_PRODUCT.nextval,null,null,"+ CategoryId + ",'" + Title + "'," + Price + "," + "TO_DATE('" + CreatedDate.ToString("MM/dd/yyyy") + "','mm/dd/yyyy'),null,'" + Active + "','" + Description + "','" + ImageUrl + "','" + ThumbnailUrl+ "'";
            string err = oracleDB.InsertIntoDB(TableName, Values);
            return err;
        }

        public string UpdateProduct()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Product";
            string Values ="Category_Id = " + CategoryId.ToString() + ", Title = '" + Title + "', Price = " + Price + ", Update_Date = TO_DATE('" + UpdateDate.ToString("MM/dd/yyyy") + "','mm/dd/yyyy')" + ", Active = '" + Active + "', Description = '" + Description + "', ImageUrl = '" + ImageUrl + "', ThumbnailUrl = '" + ThumbnailUrl + "'";
            string Where = "Product_Id = " + ProductId.ToString();
            string err = oracleDB.UpdateWhereDB(TableName, Values, Where);
            return err;
        }

        public string CopyProductImages(string sourcePath, string ImageName)
        {
             File.Copy(sourcePath, @"ProductImages/" + ImageName, true);
            return "ProductImages/" + ImageName;
        }

        public string CopyProductThumbnails(string sourcePath, string ThumbnailName)
        {
            File.Copy(sourcePath, @"ProductThumbnails/" + ThumbnailName, true);
            return "ProductImages/" + ThumbnailName;
        }

        public  List<string> ProductCategories()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Category";
            string Column = "Name";
            List<string> result = oracleDB.SelectFromDBReader(TableName, Column);
            return result;
        }

        public List<string> GetProductsForShopTitle(string Where, int Id)
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Product";
            string Column = "Title";
            List<string> Title = oracleDB.SelectFromWhereDB(TableName, Column, Where + Id.ToString());
            return Title;
        }

        public List<string> GetProductsForShopThumbnailUrl(string Where, int Id)
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Product";
            string Column = "ThumbnailUrl";
            List<string> ThumbnailUrl = oracleDB.SelectFromWhereDB(TableName, Column, Where + Id.ToString());
            return ThumbnailUrl;
        }

        public List<string> GetProductsForShopImageUrl(string Where, int Id)
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Product";
            string Column = "ImageUrl";
            List<string> ImageUrl = oracleDB.SelectFromWhereDB(TableName, Column, Where + Id.ToString());
            return ImageUrl;
        }

        public List<string> GetProductsForShopDescription(string Where, int Id)
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Product";
            string Column = "Description";
            List<string> Description = oracleDB.SelectFromWhereDB(TableName, Column, Where + Id.ToString());
            return Description;
        }

        public List<string> GetProductsForShopPrice(string Where, int Id)
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Product";
            string Column = "Price";
            List<string> Price = oracleDB.SelectFromWhereDB(TableName, Column, Where + Id.ToString());
            return Price;
        }

        public List<string> GetProductsForShopActive(string Where, int Id)
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Product";
            string Column = "Active";
            List<string> Active = oracleDB.SelectFromWhereDB(TableName, Column, Where + Id.ToString());
            return Active;
        }

        public List<string> GetProductsCategories()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Category";
            string Column = "Name";
            List<string> Category = oracleDB.SelectFromDBReader(TableName, Column);
            return Category;
        }

        public List<string> GetProductsId(string Where, int Id)
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Product";
            string Column = "Product_Id";
            List<string> ProductsId = oracleDB.SelectFromWhereDB(TableName, Column, Where + Id.ToString());
            return ProductsId;
        }

        //public List<string> GetProductsById(int Id)
        //{
        //    OracleDB oracleDB = new OracleDB();
        //    string TableName = "Product";
        //    string Column = "*";
        //    List<string> ProductsInfo = oracleDB.SelectFromWhereDB(TableName, Column, "Product_Id = " + Id.ToString());
        //    return ProductsInfo;
        //}
    }
}