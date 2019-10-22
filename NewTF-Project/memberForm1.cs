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
    public partial class memberForm1 : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        HomePage home;
        public memberForm1(HomePage page)
        {
            this.home = page;
            InitializeComponent();
        }

        private void MemberForm1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            memberBindingSource.DataSource = context.Members.ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form form in fc)
            {
                if (form.Name == "AddMember")
                {
                    FormFound = true;
                    form.Focus();
                    break;
                }
            }
            if (FormFound == false)
            {
                AddMember add = new AddMember(this);
                add.MdiParent = home;
                add.Show();
            }
        }

        public void updateDataSource()
        {
            apd621_60011212001Entities context2 = new apd621_60011212001Entities();
            memberBindingSource.DataSource = context2.Members.ToList();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("คุณต้องการลบ " + name + " ออก ใช่หรือไม่?", "ยืนยันการลบ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string username = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                var toDel = context.Members
                    .Where(s => s.member_user == username)
                    .First();

                context.Members.Remove(toDel);
                context.SaveChanges();
                updateDataSource();

            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string data = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            EditMember edit = new EditMember(data, this);
            edit.MdiParent = home;
            edit.Show(); 
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Members
                .Where(p => p.member_name.Contains(textBox1.Text) ||
                p.member_addr.Contains(textBox1.Text) ||
                p.member_tel.Contains(textBox1.Text) ||
                p.member_user.Contains(textBox1.Text))
                .ToList();
        }
    }
}
