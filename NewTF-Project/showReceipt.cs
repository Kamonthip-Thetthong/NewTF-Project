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
    public partial class showReceipt : Form
    {
        string recNumber;
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        public showReceipt(string recNumber)
        {
            this.recNumber = recNumber;
            InitializeComponent();
        }

        private void ShowReceipt_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);

            var emps = context.Employees.Include("Receipts1");
            recReport1.Database
                .Tables["NewTF_Project_Employee"]
                .SetDataSource(emps);

            var mbs = context.Members.Include("Receipts1");
            recReport1.Database
                .Tables["NewTF_Project_Member"]
                .SetDataSource(mbs);

            var pros = context.ProductNews.Include("Receipts1");
            recReport1.Database
                .Tables["NewTF_Project_ProductNew"]
                .SetDataSource(pros);

            var sets = context.ProductSets.Include("Receipts1");
            recReport1.Database
                .Tables["NewTF_Project_ProductSet"]
                .SetDataSource(sets);

            var recs = context.Receipts.Include("Employee1").Include("Member1").Include("ProductNew1").Include("ProductSet1");
            recReport1.Database
                .Tables["NewTF_Project_Receipt"]
                .SetDataSource(recs);

            recReport1.SetParameterValue("recNumber", recNumber);

            crystalReportViewer1.ReportSource = recReport1;
            crystalReportViewer1.Show();
        }
    }
}
