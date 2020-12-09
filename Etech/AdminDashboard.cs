using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Oracle.DataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows.Forms.DataVisualization.Charting;

namespace Etech
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1 : AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
                    List<string> Categories = product.ProductCategories();
                    bunifuDropdown1.Items.Clear();
                    foreach (string name in Categories)
                    {
                        bunifuDropdown1.Items.Add(name);
                        
                    }
                    
                    break;

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public static byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        
        string ImageUrl, ThumbnailUrl;
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string ImageDestination = "";
            string [] ImageName ;
            try
            {
                FileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = @":C\";

                fileDialog.Filter = "Image File (*.jpg;*.bmp;*.png;)|*.jpg;*.bmp;*.png;";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageDestination = fileDialog.FileName;
                    Image img = new Bitmap(ImageDestination);

                    AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
                    ImageName = ImageDestination.Split('\\');
                    ImageUrl = product.CopyProductImages(fileDialog.FileName, ImageName[ImageName.Length - 1]);
                    pictureBox1.Image = img;
                }

                fileDialog = null;
            }
            catch (System.ArgumentException ae)
            {
                ImageDestination = " ";
                MessageBox.Show(ae.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string ImageDestination = "";
            string[] ImageName;
            try
            {
                FileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = @":C\";

                fileDialog.Filter = "Image File (*.jpg;*.bmp;*.png;)|*.jpg;*.bmp;*.png;" ;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageDestination = fileDialog.FileName;
                    Image img = new Bitmap(ImageDestination);

                    AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
                    ImageName = ImageDestination.Split('\\');
                    ThumbnailUrl = product.CopyProductThumbnails(fileDialog.FileName, ImageName[ImageName.Length - 1]);
                    pictureBox2.Image = img;
                }

                fileDialog = null;
            }
            catch (System.ArgumentException ae)
            {
                ImageDestination = " ";
                MessageBox.Show(ae.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void bunifuGradientPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            List<string> Categories = product.GetProductsCategories();
            bunifuDropdown5.Items.Clear();
            foreach (string name in Categories)
            {
                bunifuDropdown5.Items.Add(name);
            }

            AlphaMightyFoxtrot.Promotion promotion = new AlphaMightyFoxtrot.Promotion();
            bunifuDropdown6.Items.Clear();
            List<string> Discount = promotion.GetPromotion();
            foreach (string name in Discount)
            {
                bunifuDropdown6.Items.Add(name);
            }
            tabControl1.SelectedIndex = 5;
        }

        private void bunifuDropdown5_onItemSelected(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            bunifuDropdown3.Items.Clear();
            List<string> Titles = product.GetProductsForShopTitle("Category_Id = ", bunifuDropdown5.selectedIndex + 1);
            foreach (string name in Titles)
            {
                bunifuDropdown3.Items.Add(name);
            }
        }

        private void bunifuDropdown3_onItemSelected(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown6_onItemSelected(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Promotion promotion = new AlphaMightyFoxtrot.Promotion();
            promotion.Discount = bunifuMetroTextbox7.Text;
            promotion.AddPromotion();
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Promotion promotion = new AlphaMightyFoxtrot.Promotion();
            if (bunifuDropdown3.selectedIndex < 0)
            {
                promotion.CategoryId = (bunifuDropdown5.selectedIndex + 1).ToString();
                promotion.PromotionId = bunifuDropdown6.selectedIndex + 1;
                promotion.AddProductsOnPromotionOfACategory();
            }else
            {
                //promotion.ProductId = (bunifuDropdown3.selectedIndex + 1).ToString();
                promotion.ProductId = 14.ToString();
                promotion.PromotionId = bunifuDropdown6.selectedIndex + 1;
                promotion.AddProductsOnPromotion();
            }
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            List<string> Categories = product.GetProductsCategories();
            bunifuDropdown1.Items.Clear();
            foreach (string name in Categories)
            {
                bunifuDropdown1.Items.Add(name);
            }
            tabControl1.SelectedIndex = 1;
        }

        private void bunifuDropdown10_onItemSelected(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            bunifuDropdown11.Items.Clear();
            List<string> Titles = product.GetProductsForShopTitle("Category_Id = ", bunifuDropdown10.selectedIndex + 1);
            foreach (string name in Titles)
            {
                bunifuDropdown11.Items.Add(name);
            }
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            List<string> Categories = product.GetProductsCategories();
            bunifuDropdown12.Items.Clear();
            foreach (string name in Categories)
            {
                bunifuDropdown12.Items.Add(name);
                bunifuDropdown2.Items.Add(name);
            }
            tabControl1.SelectedIndex = 3;
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            List<string> Categories = product.GetProductsCategories();
            bunifuDropdown10.Items.Clear();
            foreach (string name in Categories)
            {
                bunifuDropdown10.Items.Add(name);
            }
            tabControl1.SelectedIndex = 2;
        }

        private void bunifuDropdown11_onItemSelected(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            List<string> ProductThumbnail = product.GetProductsForShopThumbnailUrl("Category_Id = ", bunifuDropdown10.selectedIndex + 1);
            ThumbnailUrl = ProductThumbnail[bunifuDropdown11.selectedIndex];
            List<string> ProductImage = product.GetProductsForShopImageUrl("Category_Id = ", bunifuDropdown10.selectedIndex + 1);
            ImageUrl = ProductImage[bunifuDropdown11.selectedIndex];

            pictureBox5.Image = Image.FromFile(@ThumbnailUrl);
            pictureBox6.Image = Image.FromFile(@ImageUrl);
        }

        private void bunifuDropdown12_onItemSelected(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            bunifuDropdown13.Items.Clear();
            List<string> Titles = product.GetProductsForShopTitle("Category_Id = ", bunifuDropdown12.selectedIndex + 1);
            foreach (string name in Titles)
            {
                bunifuDropdown13.Items.Add(name);
            }
        }

        private void bunifuDropdown13_onItemSelected(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            List<string> ProductIdList = product.GetProductsId("Category_Id = ", bunifuDropdown12.selectedIndex + 1);

            List<string> ProductTitle = product.GetProductsForShopTitle("Product_Id = ", int.Parse(ProductIdList[bunifuDropdown13.selectedIndex]));
            List<string> ProductPrice = product.GetProductsForShopPrice("Product_Id = ", int.Parse(ProductIdList[bunifuDropdown13.selectedIndex]));
            List<string> ProductDescription = product.GetProductsForShopDescription("Product_Id = ", int.Parse(ProductIdList[bunifuDropdown13.selectedIndex]));
            List<string> ProductActive = product.GetProductsForShopActive("Product_Id = ", int.Parse(ProductIdList[bunifuDropdown13.selectedIndex]));
            List<string> ProductThumbnailUrl = product.GetProductsForShopThumbnailUrl("Product_Id = ", int.Parse(ProductIdList[bunifuDropdown13.selectedIndex]));
            List<string> ProductImageUrl = product.GetProductsForShopImageUrl("Product_Id = ", int.Parse(ProductIdList[bunifuDropdown13.selectedIndex]));


            bunifuMetroTextbox5.Text = ProductTitle[0];
            bunifuMetroTextbox4.Text = ProductPrice[0];
            textBox2.Text = ProductDescription[0];
            bunifuDropdown2.selectedIndex = bunifuDropdown12.selectedIndex;
            if (ProductActive[0] == "t")
            {
                bunifuiOSSwitch1.Value = true;
            }
            else
                bunifuiOSSwitch1.Value = false;
            ThumbnailUrl = ProductThumbnailUrl[0];
            ImageUrl = ProductImageUrl[0];
            pictureBox3.Image = Image.FromFile(@ThumbnailUrl);
            pictureBox4.Image = Image.FromFile(@ImageUrl);
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            product.Title = bunifuMetroTextbox5.Text;
            product.Price = float.Parse(bunifuMetroTextbox4.Text);
            product.Description = textBox2.Text;
            var date = DateTime.Now;
            string datetime = DateTime.Now.ToString("MM/dd/yyyy");
            if (DateTime.TryParse(datetime, out date))
            {
                product.UpdateDate = date;
            }
            if (bunifuiOSSwitch2.Value)
            {
                product.Active = 't';
            }
            else
                product.Active = 'f';
            product.CategoryId = bunifuDropdown2.selectedIndex + 1;
            product.ImageUrl = ImageUrl;
            product.ThumbnailUrl = ThumbnailUrl;

            List<string> ProductIdList = product.GetProductsId("Category_Id = ", bunifuDropdown12.selectedIndex + 1);
            product.ProductId = int.Parse(ProductIdList[bunifuDropdown13.selectedIndex]);

            product.UpdateProduct();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            string ImageDestination = "";
            string[] ImageName;
            try
            {
                FileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = @":C\";

                fileDialog.Filter = "Image File (*.jpg;*.bmp;*.png;)|*.jpg;*.bmp;*.png;";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageDestination = fileDialog.FileName;
                    Image img = new Bitmap(ImageDestination);

                    AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
                    ImageName = ImageDestination.Split('\\');
                    ImageUrl = product.CopyProductImages(fileDialog.FileName, ImageName[ImageName.Length - 1]);
                    pictureBox4.Image = img;
                }

                fileDialog = null;
            }
            catch (System.ArgumentException ae)
            {
                ImageDestination = " ";
                MessageBox.Show(ae.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            string ImageDestination = "";
            string[] ImageName;
            try
            {
                FileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = @":C\";

                fileDialog.Filter = "Image File (*.jpg;*.bmp;*.png;)|*.jpg;*.bmp;*.png;";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageDestination = fileDialog.FileName;
                    Image img = new Bitmap(ImageDestination);

                    AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
                    ImageName = ImageDestination.Split('\\');
                    ThumbnailUrl = product.CopyProductThumbnails(fileDialog.FileName, ImageName[ImageName.Length - 1]);
                    pictureBox3.Image = img;
                }

                fileDialog = null;
            }
            catch (System.ArgumentException ae)
            {
                ImageDestination = " ";
                MessageBox.Show(ae.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.MongoDB mongoDB = new AlphaMightyFoxtrot.MongoDB();
            mongoDB.getSearchWords();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.MongoDB mongoDB = new AlphaMightyFoxtrot.MongoDB();
            string j = mongoDB.getSearchWords();
            List<string> searchKey = new List<string>();
            List<string> searchKeyDis = new List<string>();
            List<int> searchKeyCount = new List<int>();
            while (j != "")
            {
                int index = j.IndexOf("searchTerm");
                string k = j.Remove(0, index);
                index = k.IndexOf(":");
                k = k.Remove(0, index);
                index = k.IndexOf("\"");
                k = k.Remove(0, index);
                k = k.Remove(0, 1);
                index = k.IndexOf("\"");
                k = k.Remove(index);

                searchKey.Add(k);

                index = j.IndexOf("searchTerm");
                j = j.Remove(0,index);
                index = j.IndexOf("}");
                j = j.Remove(0, index + 2);
            }
            searchKeyDis = searchKey.Distinct().ToList();
            int count = 0;
            int searches = 0;
            foreach(var q in searchKeyDis)
            {
                searchKeyCount.Add(0);
            }
            for (int i = 0; i < searchKeyDis.Count(); i++)
            {
                foreach (var item in searchKey)
                {
                    if (item == searchKeyDis[count])
                    {
                        searches++;
                        searchKeyCount[count] = searches;
                    }
                   
                }
                searches = 0; 
                count++;
            }
            SearchWordColumnGraph(searchKeyDis.ToArray(), searchKeyCount.ToArray());
        }
        private void ProductsOrderedLineGraph(string[] x, int[] y)
        {
            //The string array x contains all the product names
            //The int array contains the values of how many products is sold
            Chart1.Series[0].LegendText = "Products ordered";//Name of the series that the graph displays
            this.Chart1.Titles.Add("Total Products");
            Chart1.Series[0].ChartType = SeriesChartType.Line;
            Chart1.Series[0].IsValueShownAsLabel = true;
            Chart1.Series[0].Points.DataBindXY(x, y);
        }

        private void RatingsPieGraph(string product, string[] x, int[] y)
        {

            Chart1.Series[0].Points.DataBindXY(x, y);
            this.Chart1.Titles.Add("Ratings for " + product);
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
            Chart1.Legends[0].Enabled = true;
            Chart1.Series[0].IsValueShownAsLabel = true;
            Chart1.Series[0].Points.DataBindXY(x, y);
        }
        private void SearchWordColumnGraph(string[] x, int[] y)
        {
            Chart1.Series[0].LegendText = "Search count";//String wat geroep word
            this.Chart1.Titles.Add("Total times words were searched");
            Chart1.Series[0].ChartType = SeriesChartType.Column;
            Chart1.Series[0].IsValueShownAsLabel = true;
            Chart1.Series[0].Points.DataBindXY(x, y);
        }
        private void UserLineGraph(string[] x, int[] y)
        {
            Chart1.Series[0].LegendText = "Search count";//String wat geroep word
            Chart1.Series[0].ChartType = SeriesChartType.Line;
            this.Chart1.Titles.Add("Total times searched");
            Chart1.Series[0].IsValueShownAsLabel = true;
            Chart1.Series[0].Points.DataBindXY(x, y);
        }
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            product.Title = bunifuMetroTextbox1.Text;
            product.Price = float.Parse(bunifuMetroTextbox2.Text);
            product.Description = textBox1.Text;
            var date = DateTime.Now;
            string datetime = DateTime.Now.ToString("MM/dd/yyyy");
            if (DateTime.TryParse(datetime, out date))
            {
                product.CreatedDate = date;
            }
            if (bunifuiOSSwitch1.Value){
                product.Active = 't';
            }else
                product.Active = 'f';
            product.CategoryId = bunifuDropdown1.selectedIndex + 1;
            product.ImageUrl = ImageUrl;
            product.ThumbnailUrl = ThumbnailUrl;
            product.AddProduct();
        }
    }
}
