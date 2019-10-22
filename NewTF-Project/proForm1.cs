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
        HomePage home;
        public proForm1(HomePage home)
        {
            this.home = home;
            InitializeComponent();
        }

        private void ProForm1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            dataGridView1.DataSource = context.ProductNews
                .Where(p => p.product_status == 1)
                .ToList();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AddPro add = new AddPro(this);
            add.MdiParent = home;
            add.Show();
        }

        public void updateDataSorce()
        {
            apd621_60011212001Entities context2 = new apd621_60011212001Entities();
            dataGridView1.DataSource = context2.ProductNews
                .Where(p => p.product_status == 1)
                .ToList();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.ProductNews
                .Where(p => p.product_id.ToString().Contains(textBox1.Text) ||
                p.product_name.ToString().Contains(textBox1.Text) ||
                p.product_detail.ToString().Contains(textBox1.Text) ||
                p.product_type.ToString().Contains(textBox1.Text))
                .ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string data = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            editPro edit = new editPro(this, data);
            edit.MdiParent = home;
            edit.Show();
        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string data = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            showPro show = new showPro(data);
            show.MdiParent = home;
            show.Show();
        }
    }
}
