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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form form in fc)
            {
                if (form.Name == "emForm1")
                {
                    FormFound = true;
                    form.Focus();
                    break;
                }
            }
            if (FormFound == false)
            {
                emForm1 employee = new emForm1();
                employee.MdiParent = this;
                employee.Show();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form form in fc)
            {
                if (form.Name == "memberForm1")
                {
                    FormFound = true;
                    form.Focus();
                    break;
                }
            }
            if (FormFound == false)
            {
                memberForm1 employee = new memberForm1();
                employee.MdiParent = this;
                employee.Show();
            }
        }
    }
}
