using HtmlAgilityPack;
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
        public AddPro(proForm1 pro)
        {
            this.pro = pro;
            InitializeComponent();
        }

        private void AddPro_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
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

            pictureBox1.Load(url1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ProductNew product = new ProductNew();

            product.product_id = int.Parse(textBox2.Text);
            product.product_name = textBox3.Text;
            product.product_detail = textBox4.Text;
            product.product_type = textBox5.Text;
            product.product_price = float.Parse(textBox6.Text);
            product.product_amount = Decimal.ToInt32(numericUpDown1.Value);
            product.product_picture = ImageToByteArray(pictureBox1.Image);

            context.ProductNews.Add(product);
            int add = context.SaveChanges();
            if (add > 0)
            {
                MessageBox.Show("เพิ่มสินค้าเรียบร้อยแล้ว");
                pro.updateDataSorce();
                this.Close();
            }

        }

        public byte[] ImageToByteArray(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
