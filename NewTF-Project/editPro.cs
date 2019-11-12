using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTF_Project
{
    public partial class editPro : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        proForm1 pro;
        string data;
        public editPro(proForm1 pro, string data)
        {
            this.pro = pro;
            this.data = data;
            InitializeComponent();
        }

        private void EditPro_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            label2.Left = (this.Width - label2.Width) / 2;

            bindingSource1.DataSource = context.ProductNews
                .Where(p => p.product_id.ToString() == data)
                .First();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();

            int ed = context.SaveChanges();
            int id = int.Parse(textBox2.Text);
            var result = context.ProductNews
                .Where(p => p.product_id == id)
                .First();
            //RestClient client2 = new RestClient("http://www.csmsu.net");
            //RestRequest request2 = new RestRequest("/APDServiceRest/api/Product/" + result.product_id + "/8"); ;
            //var resultGet = client2.Execute<List<getProduct>>(request2, Method.GET);

            RestClient client = new RestClient("http://www.csmsu.net");
            RestRequest request = new RestRequest("/APDServiceRest/api/Product");

            putToService insertP = new putToService();
            insertP.productid = textBox2.Text;
            insertP.productname = textBox3.Text;
            insertP.productdetail = textBox4.Text;
            string str = textBox6.Text;
            while (str.Contains(","))
            {
                int inx = textBox6.Text.IndexOf(',');
                str = textBox6.Text.Remove(inx, 1);
            }
            insertP.productprice = str;

            insertP.productimgurl = result.product_pic;
            insertP.shopid = 8;
            request.AddObject(insertP);

            var result2 = client.Execute(request, Method.PUT);
            
            //MessageBox.Show("Img = "+ converted);
            if (ed > 0 && result2.ResponseStatus == ResponseStatus.Completed)
            {
                MessageBox.Show("แก้ไขข้อมูลสินค้าเรียบร้อยแล้ว");
                pro.updateDataSorce();
                this.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
