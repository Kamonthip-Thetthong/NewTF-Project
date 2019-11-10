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
    public partial class sellProduct : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        public sellProduct()
        {
            InitializeComponent();
        }

        private void SellProduct_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);

            label2.Left = (this.Width - label2.Width) / 2;

            productNewBindingSource.DataSource = context.ProductNews
                .Where(p => p.product_status != 0)
                .ToList();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            productNewBindingSource.DataSource = context.ProductNews
                .Where(p => p.product_status != 0 && (
                p.product_id.ToString().Contains(textBox1.Text) ||
                p.product_name.Contains(textBox1.Text) ||
                p.product_detail.Contains(textBox1.Text) ||
                p.product_type.Contains(textBox1.Text)))
                .ToList();
        }
    }
}
