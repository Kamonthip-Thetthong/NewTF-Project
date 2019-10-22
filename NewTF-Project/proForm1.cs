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
    public partial class proForm1 : Form
    {
        HomePage home;
        public proForm1(HomePage home)
        {
            this.home = home;
            InitializeComponent();
        }

        private void ProForm1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AddPro add = new AddPro();
            add.MdiParent = home;
            add.Show();
        }
    }
}
