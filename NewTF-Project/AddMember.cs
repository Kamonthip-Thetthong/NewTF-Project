﻿using System;
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
            var result = context.Members
                .OrderByDescending(m => m.member_ID).First();
            int id = int.Parse(result.member_ID);
            int newId = id + 1;
            string newMemId = "";
            if(newId < 10)
            {
                newMemId = string.Format("00{0}", newId);
            }else if(newId < 100)
            {
                newMemId = string.Format("0{00}", newId);
            }
            else
            {
                newMemId = string.Format("{000}", newId);
            }
                Member member = new Member();
                member.member_ID = newMemId;
                member.member_name = textBox1.Text;
                member.member_tel = textBox2.Text;
                member.member_addr = textBox3.Text;
                member.member_picture = ImageToByteArray(pictureBox1.Image);
                member.member_birthday = dateTimePicker1.Value.Date;
                member.member_date = DateTime.Now.Date;
                member.member_user = "";
                member.member_pass = "";
                member.member_status = 1;
                context.Members.Add(member);

                int add = context.SaveChanges();
                if (add > 0)
                {
                    MessageBox.Show("สมัครสมาชิกเรียบร้อย");
                    mb.updateDataSource();
                    this.Close();
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
            this.Location = new Point(0, 0);
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
