using System;
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
    public partial class HomePage : Form
    {
        Employee user;
        Login login;
        public HomePage(Employee user, Login login)
        {
            this.user = user;
            this.login = login;
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
            if (user.employee_position.ToString() == "เจ้าของร้าน" || user.employee_position.ToString() == "พนักงานขายหน้าร้าน")
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
            else
            {
                MessageBox.Show("คุณไม่มีสิทธิ์ในการเข้าถึงฟังก์ชันนี้");
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            label1.Text = user.employee_user.ToString();
            label2.Text = user.employee_position.ToString();
            pictureBox1.Image = byteArrayToImage(user.employee_picture);
            if(user.employee_position.ToString() == "เจ้าของร้าน")
            {
                emForm1 em = new emForm1(this);
                em.MdiParent = this;
                em.Show();
            }else if(user.employee_position.ToString() == "พนักงานคลังสินค้า")
            {
                proForm1 pro = new proForm1(this);
                pro.MdiParent = this;
                pro.Show();
            }
            else if (user.employee_position.ToString() == "พนักงานขายหน้าร้าน")
            {
                sellProduct pro = new sellProduct(user);
                pro.MdiParent = this;
                pro.Show();
            }

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if(user.employee_position.ToString() == "เจ้าของร้าน" || user.employee_position.ToString() == "พนักงานคลังสินค้า")
            {
                FormCollection fc = Application.OpenForms;
                bool FormFound = false;
                foreach (Form form in fc)
                {
                    if (form.Name == "proForm1")
                    {
                        FormFound = true;
                        form.Focus();
                        break;
                    }
                }
                if (FormFound == false)
                {
                    proForm1 pro = new proForm1(this);
                    pro.MdiParent = this;
                    pro.Show();
                }
            }
            else
            {
                MessageBox.Show("คุณไม่มีสิทธิ์ในการเข้าถึงฟังก์ชันนี้");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (user.employee_position.ToString() == "เจ้าของร้าน")
            {
                FormCollection fc = Application.OpenForms;
                bool FormFound = false;
                foreach (Form form in fc)
                {
                    if(form.Name == "allowSet")
                    {
                        FormFound = true;
                        form.Focus();
                    }
                }
                if (FormFound == false)
                {
                    allowSet allow = new allowSet();
                    allow.MdiParent = this;
                    allow.Show();
                }
            }
            else
            {
                MessageBox.Show("คุณไม่มีสิทธิ์ในการเข้าถึงฟังก์ชันนี้");
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (user.employee_position.ToString() == "เจ้าของร้าน" || user.employee_position.ToString() == "พนักงานขายหน้าร้าน")
            {
                FormCollection fc = Application.OpenForms;
                bool FormFound = false;
                foreach (Form form in fc)
                {
                    if (form.Name == "sellProduct")
                    {
                        FormFound = true;
                        form.Focus();
                        break;
                    }
                }
                if (FormFound == false)
                {
                    sellProduct sell = new sellProduct(user);
                    sell.MdiParent = this;
                    sell.Show();
                }
            }
            else
            {
                MessageBox.Show("คุณไม่มีสิทธิ์ในการเข้าถึงฟังก์ชันนี้");
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            compareProduct compare = new compareProduct();
            compare.MdiParent = this;
            compare.Show();
        }
    }
}
