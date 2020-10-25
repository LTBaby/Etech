using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etech
{
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Shop_Load(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            List<string> Categories = product.ProductCategories();
            bunifuDropdown1.Items.Clear();
            foreach (string name in Categories)
            {
                bunifuDropdown2.Items.Add(name);

            }
            DisplayShopList();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        public void DisplayShopList()
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            product.CategoryId = 1;
            List<string> Title = product.GetProductsForShopTitle();
            List<string> Thumbnail = product.GetProductsForShopThumbnailUrl();
            List<string> Description = product.GetProductsForShopDescription();
            List<string> Price = product.GetProductsForShopPrice();
            int counter = 0;
            foreach(string shopItem in Title)
            {
                ContainersDisplay(counter, Title[counter], Thumbnail[counter], Description[counter], Price[counter]);
                counter++;
            }
            
        }

        public void ContainersDisplay(int i, string Title, string Thumbnail, string Description, string Price)
        {
            switch (i)
            {
                case 1:
                    pictureBox1.Image = Image.FromFile(@Thumbnail);
                    labelTitle1.Text = Title;
                    bunifuCustomTextbox1.Text = Description;
                    labelPrice1.Text = Price;
                    break;
                case 2:
                    pictureBox2.Image = Image.FromFile(@Thumbnail);
                    labelTitle2.Text = Title;
                    bunifuCustomTextbox2.Text = Description;
                    labelPrice2.Text = Price;
                    break;
                case 3:
                    pictureBox3.Image = Image.FromFile(@Thumbnail);
                    labelTitle3.Text = Title;
                    bunifuCustomTextbox3.Text = Description;
                    labelPrice3.Text = Price;
                    break;
                case 4:
                    pictureBox4.Image = Image.FromFile(@Thumbnail);
                    labelTitle4.Text = Title;
                    bunifuCustomTextbox4.Text = Description;
                    labelPrice4.Text = Price;
                    break;
                case 5:
                    pictureBox5.Image = Image.FromFile(@Thumbnail);
                    labelTitle5.Text = Title;
                    bunifuCustomTextbox5.Text = Description;
                    labelPrice5.Text = Price;
                    break;
                case 6:
                    pictureBox6.Image = Image.FromFile(@Thumbnail);
                    labelTitle6.Text = Title;
                    bunifuCustomTextbox6.Text = Description;
                    labelPrice6.Text = Price;
                    break;
                case 7:
                    pictureBox7.Image = Image.FromFile(@Thumbnail);
                    labelTitle7.Text = Title;
                    bunifuCustomTextbox7.Text = Description;
                    labelPrice7.Text = Price;
                    break;
                case 8:
                    pictureBox8.Image = Image.FromFile(@Thumbnail);
                    labelTitle8.Text = Title;
                    bunifuCustomTextbox8.Text = Description;
                    labelPrice8.Text = Price;
                    break;
                case 9:
                    pictureBox9.Image = Image.FromFile(@Thumbnail);
                    labelTitle9.Text = Title;
                    bunifuCustomTextbox9.Text = Description;
                    labelPrice9.Text = Price;
                    break;
                case 10:
                    pictureBox10.Image = Image.FromFile(@Thumbnail);
                    labelTitle10.Text = Title;
                    bunifuCustomTextbox10.Text = Description;
                    labelPrice10.Text = Price;
                    break;
            }
        }
    }
}
