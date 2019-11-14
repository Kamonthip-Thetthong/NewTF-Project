using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTF_Project
{
    public partial class income : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        public income()
        {
            InitializeComponent();
        }

        private void Income_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            comboBox1.Items.Add("มกราคม");
            comboBox1.Items.Add("กุมภาพันธ์");
            comboBox1.Items.Add("มีนาคม");
            comboBox1.Items.Add("เมษายน");
            comboBox1.Items.Add("พฤษภาคม");
            comboBox1.Items.Add("มิถุนายน");
            comboBox1.Items.Add("กรกฎาคม");
            comboBox1.Items.Add("สิงหาคม");
            comboBox1.Items.Add("กันยายน");
            comboBox1.Items.Add("ตุลาคม");
            comboBox1.Items.Add("พฤศจิกายน");
            comboBox1.Items.Add("ธันวาคม");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                TimeSpan day = TimeSpan.FromDays((double)numericUpDown1.Value);
                DateTime date = DateTime.Now - day;

                var pros = context.ProductNews.Include("Receipts1");
                incomeReport11.Database
                    .Tables["NewTF_Project_ProductNew"]
                    .SetDataSource(pros);

                var sets = context.ProductSets.Include("Receipts1");
                incomeReport11.Database
                    .Tables["NewTF_Project_ProductSet"]
                    .SetDataSource(sets);

                var recs = context.Receipts.Include("Employee1").Include("Member1").Include("ProductNew1").Include("ProductSet1");
                incomeReport11.Database
                    .Tables["NewTF_Project_Receipt"]
                    .SetDataSource(recs);

                incomeReport11.SetParameterValue("start", date);
                incomeReport11.SetParameterValue("end", DateTime.Now);

                crystalReportViewer1.ReportSource = incomeReport11;
                crystalReportViewer1.Show();
            }
            else if (radioButton2.Checked == true)
            {
                var pros = context.ProductNews.Include("Receipts1");
                incomeReport11.Database
                    .Tables["NewTF_Project_ProductNew"]
                    .SetDataSource(pros);

                var sets = context.ProductSets.Include("Receipts1");
                incomeReport11.Database
                    .Tables["NewTF_Project_ProductSet"]
                    .SetDataSource(sets);

                var recs = context.Receipts.Include("Employee1").Include("Member1").Include("ProductNew1").Include("ProductSet1");
                incomeReport11.Database
                    .Tables["NewTF_Project_Receipt"]
                    .SetDataSource(recs);

                incomeReport11.SetParameterValue("start", dateTimePicker2.Value);
                incomeReport11.SetParameterValue("end", dateTimePicker3.Value);

                crystalReportViewer1.ReportSource = incomeReport11;
                crystalReportViewer1.Show();
            }else if(radioButton1.Checked == true)
            {
                var pros = context.ProductNews.Include("Receipts1");
                incomeReport21.Database
                    .Tables["NewTF_Project_ProductNew"]
                    .SetDataSource(pros);

                var sets = context.ProductSets.Include("Receipts1");
                incomeReport21.Database
                    .Tables["NewTF_Project_ProductSet"]
                    .SetDataSource(sets);

                var recs = context.Receipts.Include("Employee1").Include("Member1").Include("ProductNew1").Include("ProductSet1");
                incomeReport21.Database
                    .Tables["NewTF_Project_Receipt"]
                    .SetDataSource(recs);

                incomeReport21.SetParameterValue("start", dateTimePicker1.MinDate);
                incomeReport21.SetParameterValue("end", dateTimePicker1.MaxDate);
                incomeReport21.SetParameterValue("date", dateTimePicker1.Value);

                crystalReportViewer1.ReportSource = incomeReport21;
                crystalReportViewer1.Show();
            }
            else
            {
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;
                if (comboBox1.Text == "มกราคม")
                {
                    start = DateTime.ParseExact("01/01/"+DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("01/31/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }else if (comboBox1.Text == "กุมภาพันธ์")
                {
                    start = DateTime.ParseExact("02/01/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("02/28/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }else if (comboBox1.Text == "มีนาคม")
                {
                    start = DateTime.ParseExact("03/01/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("03/31/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }else if (comboBox1.Text == "เมษายน")
                {
                    start = DateTime.ParseExact("04/01/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("04/30/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }else if (comboBox1.Text == "พฤษภาคม")
                {
                    start = DateTime.ParseExact("05/01/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("05/31/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }else if (comboBox1.Text == "มิถุนายน")
                {
                    start = DateTime.ParseExact("06/01/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("06/30/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }else if (comboBox1.Text == "กรกฎาคม")
                {
                    start = DateTime.ParseExact("07/01/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("07/31/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }else if (comboBox1.Text == "สิงหาคม")
                {
                    start = DateTime.ParseExact("08/01/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("08/31/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }else if (comboBox1.Text == "กันยายน")
                {
                    start = DateTime.ParseExact("09/01/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("09/30/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }else if (comboBox1.Text == "ตุลาคม")
                {
                    start = DateTime.ParseExact("10/01/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("10/31/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }else if (comboBox1.Text == "พฤศจิกายน")
                {
                    start = DateTime.ParseExact("11/01/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("11/30/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }else if (comboBox1.Text == "ธันวาคม")
                {
                    start = DateTime.ParseExact("12/01/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    end = DateTime.ParseExact("12/31/" + DateTime.Now.Year, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }

                var pros = context.ProductNews.Include("Receipts1");
                incomeReport11.Database
                    .Tables["NewTF_Project_ProductNew"]
                    .SetDataSource(pros);

                var sets = context.ProductSets.Include("Receipts1");
                incomeReport11.Database
                    .Tables["NewTF_Project_ProductSet"]
                    .SetDataSource(sets);

                var recs = context.Receipts.Include("Employee1").Include("Member1").Include("ProductNew1").Include("ProductSet1");
                incomeReport11.Database
                    .Tables["NewTF_Project_Receipt"]
                    .SetDataSource(recs);

                incomeReport11.SetParameterValue("start", start);
                incomeReport11.SetParameterValue("end", end);

                crystalReportViewer1.ReportSource = incomeReport11;
                crystalReportViewer1.Show();
            }
            
        }
    }
}
