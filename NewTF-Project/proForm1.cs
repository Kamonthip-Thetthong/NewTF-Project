using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
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

            label2.Left = (this.Width - label2.Width) / 2;

            string str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(str);

            var result = context.ProductNews
                .Where(p => p.product_id == id)
                .First();

            label8.Text = result.product_id.ToString();
            label9.Text = result.product_name.ToString();
            label10.Text = result.product_detail.ToString();
            label11.Text = result.product_price.ToString();
            label12.Text = result.product_amount.ToString();
            label14.Text = result.product_type.ToString();
            pictureBox1.Image = byteArrayToImage(result.product_picture);

            dataGridView2.DataSource = context.ProductSets
                .Where(s => s.set_status == true && s.set_isDel == 0)
                .ToList();

            dataGridView3.DataSource = context.ProductSets
                .Where(s => s.set_status == false && s.set_isDel == 0)
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

        public void updateSet()
        {
            dataGridView2.DataSource = context.ProductSets
                .Where(s => s.set_status == true && s.set_isDel == 0)
                .ToList();

            dataGridView3.DataSource = context.ProductSets
                .Where(s => s.set_status == false && s.set_isDel == 0)
                .ToList();
        }

        //public void delSet()
        //{
        //    //apd621_60011212001Entities context2 = new apd621_60011212001Entities();
        //}

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

        private void Button3_Click(object sender, EventArgs e)
        {
            string data = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            var result = context.ProductNews
                .Where(p => p.product_id.ToString() == data)
                .First();

            DialogResult dialogResult = MessageBox.Show("คุณต้องการลบสินค้านี้ออก ใช่หรือไม่?", "ยืนยันการไล่ออก", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                result.product_status = 0;
                result.product_amount = 0;
                context.SaveChanges();
                MessageBox.Show("ลบเรียบร้อย");
                updateDataSorce();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(str);

            var result = context.ProductNews
                .Where(p => p.product_id == id)
                .First();

            label8.Text = result.product_id.ToString();
            label9.Text = result.product_name.ToString();
            label10.Text = result.product_detail.ToString();
            label11.Text = result.product_price.ToString();
            label12.Text = result.product_amount.ToString();
            label14.Text = result.product_type.ToString();
            pictureBox1.Image = byteArrayToImage(result.product_picture);
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void DataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(str);

            var result = context.ProductNews
                .Where(p => p.product_id == id)
                .First();

            label8.Text = result.product_id.ToString();
            label9.Text = result.product_name.ToString();
            label10.Text = result.product_detail.ToString();
            label11.Text = result.product_price.ToString();
            label12.Text = result.product_amount.ToString();
            label14.Text = result.product_type.ToString();
            pictureBox1.Image = byteArrayToImage(result.product_picture);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            addSet set = new addSet(this);
            set.MdiParent = home;
            set.Show();
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

            foreach(var com in coms)
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

            listView1.Items.Clear();

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

        private void DataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(str);
            var result = context.ProductSets
                .Where(p => p.set_id == id)
                .First();

            label23.Text = result.set_id.ToString();
            label24.Text = result.set_name;
            label25.Text = result.set_price.ToString();

            var coms = context.Composes
                .Where(c => c.set_id == result.set_id)
                .ToList();

            listView2.Items.Clear();
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

                listView2.Items.Add(new ListViewItem(item));
            }
        }

        private void DataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(str);
            var result = context.ProductSets
                .Where(p => p.set_id == id)
                .First();

            label23.Text = result.set_id.ToString();
            label24.Text = result.set_name;
            label25.Text = result.set_price.ToString();

            var coms = context.Composes
                .Where(c => c.set_id == result.set_id)
                .ToList();

            listView2.Items.Clear();
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

                listView2.Items.Add(new ListViewItem(item));
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label23.Text);

            var del = context.ProductSets
                .Where(p => p.set_id == id)
                .First();

            del.set_isDel = 1;
            int change = context.SaveChanges();
            if(change > 0)
            {
                MessageBox.Show("ลบเซ็ตสินค้าเรียบร้อย");
            }
            updateSet();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label26.Text);

            var del = context.ProductSets
                .Where(p => p.set_id == id)
                .First();

            del.set_isDel = 1;
            int change = context.SaveChanges();
            if (change > 0)
            {
                MessageBox.Show("ยกเลิกการขออนุมัติเซ็ตสินค้าเรียบร้อย");
            }
            updateSet();
        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void TabControl1_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = context.ProductSets
                .Where(s => s.set_status == true && s.set_isDel == 0)
                .ToList();

            dataGridView3.DataSource = context.ProductSets
                .Where(s => s.set_status == false && s.set_isDel == 0)
                .ToList();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            viewReportProduct view = new viewReportProduct();
            view.MdiParent = home;
            view.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            printBarcode print = new printBarcode(int.Parse(label8.Text));
            print.MdiParent = home;
            print.Show();
        }
    }
}
