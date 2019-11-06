﻿using System;
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

        }
    }
}
