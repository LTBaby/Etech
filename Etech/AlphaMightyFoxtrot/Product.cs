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
            string[] Catergories =  {"Name"};
            OracleDB oracleDB = new OracleDB();
            string TableName = "Category";
            string Column = "Name";
            List<string> result = oracleDB.SelectFromDBReader(TableName, Column, Catergories);
            return result;
        }
    }
}