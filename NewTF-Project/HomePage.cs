﻿using System;
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
        Employee user;
        public HomePage(Employee user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(user.employee_position.ToString() == "เจ้าของร้าน")
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
                    emForm1 employee = new emForm1(this);
                    employee.MdiParent = this;
                    employee.Show();
                }
            }
            else
            {
                MessageBox.Show("คุณไม่มีสิทธิ์ในการเข้าถึงฟังก์ชันนี้");
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
                memberForm1 employee = new memberForm1(this);
                employee.MdiParent = this;
                employee.Show();
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            label1.Text = user.employee_user.ToString();
            label2.Text = user.employee_position.ToString();
            if(user.employee_position.ToString() == "เจ้าของร้าน")
            {
                emForm1 em = new emForm1(this);
                em.MdiParent = this;
                em.Show();
            }
        }
    }
}
