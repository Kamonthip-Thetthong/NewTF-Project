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
    public partial class EditMember : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        memberForm1 mbForm;
        string ed;
        Member member;
        public EditMember(string data, memberForm1 memberForm1)
        {
            this.ed = data;
            this.mbForm = memberForm1;
            member = context.Members
                .Where(s => s.member_user == ed).First();
            InitializeComponent();
        }

        private void EditMember_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            memberBindingSource.DataSource = member;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            mbForm.updateDataSource();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            member.member_picture = ImageToByteArray(pictureBox1.Image);
            memberBindingSource.EndEdit();

            int save = context.SaveChanges();
            if (save > 0)
            {
                MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว");
                mbForm.updateDataSource();
                this.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
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
