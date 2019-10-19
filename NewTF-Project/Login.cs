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
    public partial class Login : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                HomePage home = new HomePage();
                home.Show();
                this.Hide();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /*try
            {
                var result = context.Employees
                    .Where(e => e.)
            }
            catch { }*/
        }
    }
}
