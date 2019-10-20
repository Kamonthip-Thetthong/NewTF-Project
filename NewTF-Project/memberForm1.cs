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
            memberBindingSource.DataSource = context.Members.ToList();
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
    }
}
