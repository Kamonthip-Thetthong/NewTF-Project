using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTF_Project
{
    public partial class AddEm : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        emForm1 em;
        public AddEm(emForm1 em)
        {
            this.em = em;
            InitializeComponent();
        }

        private void AddEm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = em.Location;
            label2.Left = (this.Width - label2.Width) / 2;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var result = context.Employees
                    .Where(m => m.employee_user == textBox5.Text).First();
                
                
                MessageBox.Show("username นี้ถูกใช้ไปแล้ว!!!");
                
            }
            catch
            {
                var result = context.Employees
                    .OrderByDescending(m => m.employee_ID).First();
                int emId = int.Parse(result.employee_ID);
                int newId = emId + 1;
                string newEmId = "";
                Employee newEm = new Employee();
                if(newId < 10)
                {
                    newEmId = string.Format("00{0}", newId);
                }else if(newId < 100)
                {
                    newEmId = string.Format("0{00}", newId);
                }
                else
                {
                    newEmId = string.Format("{000}", newId);
                }
                newEm.employee_ID = newEmId.ToString();
                newEm.employee_name = textBox1.Text;
                newEm.employee_addr = textBox2.Text;
                newEm.employee_tel = textBox3.Text;
                newEm.employee_salary = float.Parse(textBox4.Text, CultureInfo.InvariantCulture.NumberFormat);
                newEm.employee_picture = ImageToByteArray(pictureBox1.Image);
                newEm.employee_date = DateTime.Now.Date;
                if (radioButton1.Checked)
                {
                    newEm.employee_position = "เจ้าของร้าน";
                }
                else if (radioButton2.Checked)
                {
                    newEm.employee_position = "พนักงานขายหน้าร้าน";
                }
                else if (radioButton3.Checked)
                {
                    newEm.employee_position = "พนักงานคลังสินค้า";
                }
                newEm.employee_user = textBox5.Text;
                newEm.employee_pass = textBox6.Text;
                newEm.employee_status = 1;
                context.Employees.Add(newEm);

                int add = context.SaveChanges();
                if (add > 0)
                {
                    MessageBox.Show("เพิ่มพนักงานเรียบร้อย");
                    em.updateDataSource();
                    this.Close();
                }
                
            }
        
        }

        public byte[] ImageToByteArray(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
    }
}
