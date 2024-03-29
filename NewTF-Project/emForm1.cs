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
    public partial class emForm1 : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        HomePage home;
        public emForm1(HomePage home)
        {
            this.home = home;
            InitializeComponent();
        }

        private void EmForm1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            var emp = context.Employees
                .Where(p => p.employee_status == 1)
                .ToList();
            dataGridView1.DataSource = emp;
            label2.Left = (this.Width - label2.Width) / 2;

            string name = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            var result = context.Employees
                .Where(s => s.employee_user == name)
                .First();

            label3.Text = "ID : " + result.employee_ID;
            label4.Text = "ชื่อ-สกุล : " + result.employee_name.ToString();
            label5.Text = "ที่อยู่ : " + result.employee_addr.ToString();
            label6.Text = "ตำแหน่ง : " + result.employee_position.ToString();
            label7.Text = "เงินเดือน : " + result.employee_salary.ToString();
            label8.Text = "เบอร์โทรศัพท์ : " + result.employee_tel.ToString();
            label9.Text = "username : " + result.employee_user.ToString();
            label10.Text = "password : " + result.employee_pass.ToString();
            pictureBox1.Image = byteArrayToImage(result.employee_picture);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form form in fc)
            {
                if (form.Name == "AddEm")
                {
                    FormFound = true;
                    form.Focus();
                    break;
                }
            }
            if (FormFound == false)
            {
                AddEm add = new AddEm(this);
                add.MdiParent = home;
                add.Show();
            }
        }

        public void updateDataSource()
        {
            apd621_60011212001Entities context2 = new apd621_60011212001Entities();
            dataGridView1.DataSource = context2.Employees.Where(p => p.employee_status == 1).ToList();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Employees
                .Where(p => p.employee_name.Contains(textBox1.Text) || 
                p.employee_addr.Contains(textBox1.Text) ||
                p.employee_tel.Contains(textBox1.Text) ||
                p.employee_position.Contains(textBox1.Text) ||
                p.employee_user.Contains(textBox1.Text) &&
                p.employee_status == 1)
                .ToList();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string data = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            editEm edit = new editEm(data, this);
            edit.MdiParent = home;
            edit.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("คุณต้องการลบ " + name + " ออก ใช่หรือไม่?", "ยืนยันการไล่ออก", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                string username = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

                var toDel = context.Employees
                    .Where(s => s.employee_user == username)
                    .First();

                //context.Employees.Remove(toDel);
                toDel.employee_status = 0;
                context.SaveChanges();
                updateDataSource();

            }
            

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            var result = context.Employees
                .Where(s => s.employee_user == name)
                .First();

            label3.Text = "ID : " + result.employee_ID;
            label4.Text = "ชื่อ-สกุล : " + result.employee_name.ToString();
            label5.Text = "ที่อยู่ : " + result.employee_addr.ToString();
            label6.Text = "ตำแหน่ง : " + result.employee_position.ToString();
            label7.Text = "เงินเดือน : " + result.employee_salary.ToString();
            label8.Text = "เบอร์โทรศัพท์ : " + result.employee_tel.ToString();
            label9.Text = "username : " + result.employee_user.ToString();
            label10.Text = "password : " + result.employee_pass.ToString();
            pictureBox1.Image = byteArrayToImage(result.employee_picture);
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
