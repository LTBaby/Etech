﻿using System;
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
        public string CategorySelected { get; set; }
        public string CurrentCategoryBrowsing { get; set; }
        private List<string> Title = new List<string>();
        private List<string> Thumbnail = new List<string>();
        private List<string> Description = new List<string>();
        private List<string> Price = new List<string>();

        public Shop()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Shop_Load(object sender, EventArgs e)
        {
            bunifuDropdown3.Clear();
            bunifuDropdown2.Clear();
            bunifuDropdown1.Clear();
            bunifuFlatButton8.Visible = false;

            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            List<string> Categories = product.ProductCategories();
            foreach (string name in Categories)
            {
                bunifuDropdown2.Items.Add(name);

            }
            DisplayShopList();
            label11.Text = CurrentCategoryBrowsing;
            bunifuDropdown2.selectedIndex = int.Parse(CategorySelected) - 1;
            CalculatePages();
            tabControl1.Appearance = TabAppearance.FlatButtons; tabControl1.ItemSize = new Size(0, 1); tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        public void DisplayShopList()
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            product.CategoryId = int.Parse(CategorySelected);
            Title = product.GetProductsForShopTitle();
            Thumbnail = product.GetProductsForShopThumbnailUrl();
            Description = product.GetProductsForShopDescription();
            Price = product.GetProductsForShopPrice();
            int counter = 0;
            foreach(string shopItem in Title)
            {
                ContainersDisplay(counter + 1, Title[counter], Thumbnail[counter], Description[counter], Price[counter]);
                counter++;
            }
            HideEmptyContainers();
            
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

        public void CalculatePages()
        {
            decimal i = Title.Count;
            decimal d = i / 10;
            d = Math.Ceiling(d);
            i = Convert.ToInt32(d);
            for(int j = 1; j <= i; j++)
            {
                bunifuDropdown3.Items.Add(j.ToString());
            }
        }

        public void HideEmptyContainers()
        {
            if(labelPrice1.Text == "R")
                bunifuCards1.Visible = false;
            else
                bunifuCards1.Visible = true;

            if (labelPrice2.Text == "R")
                bunifuCards2.Visible = false;
            else
                bunifuCards2.Visible = true;

            if (labelPrice3.Text == "R")
                bunifuCards3.Visible = false;
            else
                bunifuCards3.Visible = true;

            if (labelPrice4.Text == "R")
                bunifuCards4.Visible = false;
            else
                bunifuCards4.Visible = true;

            if (labelPrice5.Text == "R")
                bunifuCards5.Visible = false;
            else
                bunifuCards5.Visible = true;

            if (labelPrice6.Text == "R")
                bunifuCards6.Visible = false;
            else
                bunifuCards6.Visible = true;

            if (labelPrice7.Text == "R")
                bunifuCards7.Visible = false;
            else
                bunifuCards7.Visible = true;

            if (labelPrice8.Text == "R")
                bunifuCards8.Visible = false;
            else
                bunifuCards8.Visible = true;

            if (labelPrice8.Text == "R")
                bunifuCards8.Visible = false;
            else
                bunifuCards8.Visible = true;

            if (labelPrice9.Text == "R")
                bunifuCards9.Visible = false;
            else
                bunifuCards9.Visible = true;

            if (labelPrice10.Text == "R")
                bunifuCards10.Visible = false;
            else
                bunifuCards10.Visible = true;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            label20.Text = labelTitle1.Text;
            label22.Text = labelPrice1.Text;
            pictureBox11.Image = pictureBox1.Image;
            tabControl1.SelectedIndex = 1;
            bunifuFlatButton8.Visible = true;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            label20.Text = labelTitle2.Text;
            label22.Text = labelPrice2.Text;
            pictureBox11.Image = pictureBox2.Image;
            tabControl1.SelectedIndex = 1;
            bunifuFlatButton8.Visible = true;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            label20.Text = labelTitle3.Text;
            label22.Text = labelPrice3.Text;
            pictureBox11.Image = pictureBox3.Image;
            tabControl1.SelectedIndex = 1;
            bunifuFlatButton8.Visible = true;
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            label20.Text = labelTitle4.Text;
            label22.Text = labelPrice4.Text;
            pictureBox11.Image = pictureBox4.Image;
            tabControl1.SelectedIndex = 1;
            bunifuFlatButton8.Visible = true;
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            label20.Text = labelTitle5.Text;
            label22.Text = labelPrice5.Text;
            pictureBox11.Image = pictureBox5.Image;
            tabControl1.SelectedIndex = 1;
            bunifuFlatButton8.Visible = true;
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            label20.Text = labelTitle6.Text;
            label22.Text = labelPrice6.Text;
            pictureBox11.Image = pictureBox6.Image;
            tabControl1.SelectedIndex = 1;
            bunifuFlatButton8.Visible = true;
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            label20.Text = labelTitle7.Text;
            label22.Text = labelPrice7.Text;
            pictureBox11.Image = pictureBox7.Image;
            tabControl1.SelectedIndex = 1;
            bunifuFlatButton8.Visible = true;
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            label20.Text = labelTitle8.Text;
            label22.Text = labelPrice8.Text;
            pictureBox11.Image = pictureBox8.Image;
            tabControl1.SelectedIndex = 1;
            bunifuFlatButton8.Visible = true;
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            label20.Text = labelTitle9.Text;
            label22.Text = labelPrice9.Text;
            pictureBox11.Image = pictureBox9.Image;
            tabControl1.SelectedIndex = 1;
            bunifuFlatButton8.Visible = true;
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            label20.Text = labelTitle10.Text;
            label22.Text = labelPrice10.Text;
            pictureBox11.Image = pictureBox10.Image;
            tabControl1.SelectedIndex = 1;
            bunifuFlatButton8.Visible = true;
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            bunifuFlatButton8.Visible = false;
        }
    }
}
