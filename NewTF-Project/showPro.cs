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
    public partial class showPro : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        string data;
        public showPro(string data)
        {
            this.data = data;
            InitializeComponent();
        }

        private void ShowPro_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);

            bindingSource1.DataSource = context.ProductNews
                .Where(p => p.product_id.ToString() == data)
                .First();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
