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
    public partial class compareProduct : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();

        public compareProduct()
        {
            InitializeComponent();
        }

        private void CompareProduct_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            label2.Left = (this.Width - label2.Width) / 2;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                RestClient client = new RestClient("http://www.csmsu.net");
                RestRequest request;
                if (radioButton1.Checked)
                {
                    request = new RestRequest("/APDServiceRest/api/Product/" + textBox2.Text);
                }
                else
                {
                    request = new RestRequest("/APDServiceRest/api/Product/" + textBox2.Text + "/" + textBox1.Text);
                }

                
                string pid = textBox2.Text;
                var myShop = context.ProductNews
                    .Where(p => p.product_id == pid)
                    .First();
                label7.Text = myShop.product_id;
                label8.Text = myShop.product_name;
                label9.Text = myShop.product_price.ToString();
                pictureBox1.Load(myShop.product_pic);
                var result = client.Execute<List<getProduct>>(request, Method.GET);

                listView1.Items.Clear();
                foreach (var pro in result.Data)
                {
                    if(pro.shopid != 8)
                    {
                        string shopname = pro.systemUser.shopname;
                        string productname = pro.productname;
                        int price = pro.productprice;
                        string com = "";
                        if (Convert.ToInt32(myShop.product_price) < price)
                        {
                            com = "ถูกกว่า " + (price - Convert.ToInt32(myShop.product_price)) + " บาท";
                        }
                        else if (Convert.ToInt32(myShop.product_price) > price)
                        {
                            com = "แพงกว่า " + (Convert.ToInt32(myShop.product_price) - price) + " บาท";
                        }
                        else
                        {
                            com = "เท่ากัน";
                        }

                        string[] item = new string[]
                        {
                        shopname,
                        productname,
                        price.ToString(),
                        com
                        };

                        listView1.Items.Add(new ListViewItem(item));
                    }
                    
                }
            }
            catch
            {
                MessageBox.Show("ใส่ข้อมูลไม่ถูกต้อง!!");
            }
            

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
