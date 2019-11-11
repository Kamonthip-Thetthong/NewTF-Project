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
    public partial class allowSet : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        public allowSet()
        {
            InitializeComponent();
        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(str);
            var result = context.ProductSets
                .Where(p => p.set_id == id)
                .First();

            label26.Text = result.set_id.ToString();
            label28.Text = result.set_name;
            label30.Text = result.set_price.ToString();

            var coms = context.Composes
                .Where(c => c.set_id == result.set_id)
                .ToList();

            foreach (var com in coms)
            {
                var product = context.ProductNews
                    .Where(p => p.product_id == com.product_id)
                    .First();

                string[] item = new string[]
                {
                    product.product_id.ToString(),
                    product.product_name,
                    com.product_amount.ToString()
                };

                listView1.Items.Add(new ListViewItem(item));
            }
        }

        private void AllowSet_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);

            label2.Left = (this.Width - label2.Width) / 2;
            dataGridView3.DataSource = context.ProductSets
                .Where(p => p.set_status == false && p.set_isDel == 0)
                .ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label26.Text);

            var result = context.ProductSets
                .Where(p => p.set_id == id)
                .First();

            result.set_status = true;

            int change = context.SaveChanges();
            if(change > 0)
            {
                MessageBox.Show("อนุมัติสินค้า!!!");
            }
            updateSet();
            label26.Text = "";
            label28.Text = "";
            label30.Text = "";
            listView1.Items.Clear();
        }

        public void updateSet()
        {
            label2.Left = (this.Width - label2.Width) / 2;
            dataGridView3.DataSource = context.ProductSets
                .Where(p => p.set_status == false && p.set_isDel == 0)
                .ToList();
        }

        private void DataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(str);
            var result = context.ProductSets
                .Where(p => p.set_id == id)
                .First();

            label26.Text = result.set_id.ToString();
            label28.Text = result.set_name;
            label30.Text = result.set_price.ToString();

            var coms = context.Composes
                .Where(c => c.set_id == result.set_id)
                .ToList();

            listView1.Items.Clear();
            foreach (var com in coms)
            {
                var product = context.ProductNews
                    .Where(p => p.product_id == com.product_id)
                    .First();

                string[] item = new string[]
                {
                    product.product_id.ToString(),
                    product.product_name,
                    com.product_amount.ToString()
                };

                listView1.Items.Add(new ListViewItem(item));
            }
        }
    }
}
