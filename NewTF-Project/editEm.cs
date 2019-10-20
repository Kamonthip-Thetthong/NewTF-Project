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
    public partial class editEm : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        string ed;
        emForm1 emForm;
        Employee em;
        public editEm(string ed, emForm1 emForm)
        {
            this.emForm = emForm;
            this.ed = ed;
            em = context.Employees
                .Where(s => s.employee_user == ed).First();
            
            InitializeComponent();
        }

        private void EditEm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = emForm.Location;

            comboBox1.Items.Add("เจ้าของร้าน");
            comboBox1.Items.Add("พนักงานขายหน้าร้าน");
            comboBox1.Items.Add("พนักงานคลังสินค้า");

            bindingSource1.DataSource = em;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            emForm.updateDataSource();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            bindingSource1.EndEdit();
            
            int save = context.SaveChanges();
            if (save > 0)
            {
                MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว");
                emForm.updateDataSource();
                this.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
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
