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

            bindingSource1.DataSource = context.ProductNews
                .Where(p => p.product_id.ToString() == data)
                .First();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();

            int ed = context.SaveChanges();
            if(ed > 0)
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
