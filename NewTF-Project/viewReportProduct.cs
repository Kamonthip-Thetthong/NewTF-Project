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
    public partial class viewReportProduct : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        public viewReportProduct()
        {
            InitializeComponent();
        }

        private void ViewReportProduct_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);

            var products = context.ProductNews;
            productsReport1.Database
                .Tables["NewTF_Project_ProductNew"]
                .SetDataSource(products);
            crystalReportViewer1.ReportSource = productsReport1;
            crystalReportViewer1.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
