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
    public partial class proForm1 : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        
        public proForm1()
        {
            InitializeComponent();
        }

        private void ProForm1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            dataGridView1.DataSource = context.ProductNews.ToList();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.ProductNews
                .Where(p => p.product_id.ToString().Contains(textBox1.Text) || 
                p.product_name.ToString().Contains(textBox1.Text) || 
                p.product_type.ToString().Contains(textBox1.Text) )
                .ToList();
        }
    }
}
