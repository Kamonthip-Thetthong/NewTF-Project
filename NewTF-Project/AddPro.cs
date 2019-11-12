using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTF_Project
{
    public partial class AddPro : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        proForm1 pro;
        string imgUrl = "";
        public AddPro(proForm1 pro)
        {
            this.pro = pro;
            InitializeComponent();
        }

        private void AddPro_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            label2.Left = (this.Width - label2.Width) / 2;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            string url = "https://www.jib.co.th/web/product/readProduct/" + textBox1.Text;
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);

            textBox2.Text = textBox1.Text;
            var html = doc.DocumentNode.Descendants("meta");
            var title = html.Where(t => t.GetAttributeValue("property", "") == "og:title").First();
            textBox3.Text = title.GetAttributeValue("content", "");
            var desc = html.Where(t => t.GetAttributeValue("property", "") == "og:description").First();
            textBox4.Text = desc.GetAttributeValue("content", "");

            var html2 = doc.DocumentNode.Descendants("div");
            var price = html2.Where(p => p.GetAttributeValue("class", "") == "col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center price_block")
                .First();
            var pr = price.Descendants("strong").First();
            textBox6.Text = ""+pr.InnerText;

            var tp = html2.Where(p => p.GetAttributeValue("class", "") == "step_nav")
                .First();
            var types = tp.Descendants("a")
                .Where(n => n.GetAttributeValue("title", "") != "Home").ToList();
            /*var type = tp.GetAttributeValue("title", "");*/
            var i = 0;
            foreach(var type in types)
            {
                if(i == 1)
                {
                    textBox5.Text = type.GetAttributeValue("title", "").ToString();
                    break;
                }
                i += 1;
            }

            var pic = html.Where(t => t.GetAttributeValue("name", "") == "twitter:image").First();
            string url1 = pic.GetAttributeValue("content", "").ToString();
            imgUrl = url1;

            pictureBox1.Load(url1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox2.Text);
                var result = context.ProductNews
                    .Where(p => p.product_id == id)
                    .First();
                if(result.product_status == 0)
                {
                    result.product_amount = Decimal.ToInt32(numericUpDown1.Value);
                    result.product_status = 1;
                    result.product_pic= imgUrl;

                    int add = context.SaveChanges();


                    if (add > 0)
                    {
                        MessageBox.Show("เพิ่มสินค้าเรียบร้อยแล้ว");
                        //pro.updateDataSorce();
                        //this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("มีสินค้าอยู่ในคลังแล้ว");
                }
                
            }
            catch
            {
                ProductNew product = new ProductNew();

                product.product_id = int.Parse(textBox2.Text);
                product.product_name = textBox3.Text;
                product.product_detail = textBox4.Text;
                product.product_type = textBox5.Text;
                product.product_price = float.Parse(textBox6.Text);
                product.product_amount = Decimal.ToInt32(numericUpDown1.Value);
                product.product_pic = imgUrl;
                product.product_status = 1;

                context.ProductNews.Add(product);
                int add = context.SaveChanges();

                RestClient client = new RestClient("http://www.csmsu.net");
                RestRequest request = new RestRequest("/APDServiceRest/api/Product");

                insertProduct insertP = new insertProduct();
                insertP.productid = textBox2.Text;
                insertP.productname = textBox3.Text;
                insertP.productdetail = textBox4.Text;
                string str = textBox6.Text;
                while (str.Contains(","))
                {
                    int inx = textBox6.Text.IndexOf(',');
                    str = textBox6.Text.Remove(inx, 1);
                }  
                insertP.productprice = int.Parse(str);
                insertP.productimgurl = imgUrl;
                insertP.shopid = 8;
                request.AddObject(insertP);

                var result = client.Execute(request, Method.POST);
                if (add > 0 && result.ResponseStatus == ResponseStatus.Completed)
                {
                    MessageBox.Show("เพิ่มสินค้าเรียบร้อยแล้ว!!!");
                    //pro.updateDataSorce();
                    //this.Close();
                }
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            pro.updateDataSorce();
            this.Close();
        }
    }
}
