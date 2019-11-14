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
    public partial class memExpense : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        public memExpense()
        {
            InitializeComponent();
        }

        private void MemExpense_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);

            MemberBindingSource1.DataSource = context.Members.Where(m => m.member_status == 1).ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var mbs = context.Members.Include("Receipts1");
            memberExpenseReport1.Database
                .Tables["NewTF_Project_Member"]
                .SetDataSource(mbs);

            var pros = context.ProductNews.Include("Receipts1");
            memberExpenseReport1.Database
                .Tables["NewTF_Project_ProductNew"]
                .SetDataSource(pros);

            var sets = context.ProductSets.Include("Receipts1");
            memberExpenseReport1.Database
                .Tables["NewTF_Project_ProductSet"]
                .SetDataSource(sets);

            var recs = context.Receipts.Include("Employee1").Include("Member1").Include("ProductNew1").Include("ProductSet1");
            memberExpenseReport1.Database
                .Tables["NewTF_Project_Receipt"]
                .SetDataSource(recs);

            string mId = "";
            if (radioButton1.Checked == true)
            {
                try
                {
                    var result = context.Members
                        .Where(m => m.member_ID == textBox1.Text)
                        .First();
                    mId = textBox1.Text;
                }
                catch
                {
                    MessageBox.Show("รหัสสมาชิกไม่ถูกต้อง");
                }
                
            }
            else
            {
                var result = context.Members
                    .Where(m => m.member_name == comboBox1.Text)
                    .First();
                mId = result.member_ID;
            }

            memberExpenseReport1.SetParameterValue("mId", mId);

            crystalReportViewer1.ReportSource = memberExpenseReport1;
            crystalReportViewer1.Show();
        }
    }
}
