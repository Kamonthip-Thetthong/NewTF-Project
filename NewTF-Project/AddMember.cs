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
    public partial class AddMember : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        memberForm1 mb;
        public AddMember(memberForm1 mb)
        {
            this.mb = mb;
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var result = context.Members
                    .Where(m => m.member_user == textBox4.Text).First();


                MessageBox.Show("username นี้ถูกใช้ไปแล้ว!!!");

            }
            catch
            {
                Member member = new Member();
                member.member_name = textBox1.Text;
                member.member_tel = textBox2.Text;
                member.member_addr = textBox3.Text;
                member.member_picture = ImageToByteArray(pictureBox1.Image);
                member.member_birthday = dateTimePicker1.Value.Date;
                member.member_date = DateTime.Now.Date;
                member.member_user = textBox4.Text;
                member.member_pass = textBox5.Text;

                context.Members.Add(member);

                int add = context.SaveChanges();
                if (add > 0)
                {
                    MessageBox.Show("สมัครสมาชิกเรียบร้อย");
                    mb.updateDataSource();
                    this.Close();
                }

            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }

        private void AddMember_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = mb.Location;
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
            mb.updateDataSource();
            this.Close();
        }
    }
}
