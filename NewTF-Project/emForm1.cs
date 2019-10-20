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
            dataGridView1.DataSource = context.Employees.ToList();
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
            dataGridView1.DataSource = context.Employees.ToList();
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Employees
                .Where(p => p.employee_name.Contains(textBox1.Text) || 
                p.employee_addr.Contains(textBox1.Text) ||
                p.employee_tel.Contains(textBox1.Text) ||
                p.employee_position.Contains(textBox1.Text) ||
                p.employee_user.Contains(textBox1.Text))
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
            DialogResult dialogResult = MessageBox.Show("คุณต้องการไล่ " + name + " ออก ใช่หรือไม่?", "ยืนยันการไล่ออก", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                string username = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

                var toDel = context.Employees
                    .Where(s => s.employee_user == username)
                    .First();

                context.Employees.Remove(toDel);
                context.SaveChanges();
                updateDataSource();

            }
            

        }
    }
}
