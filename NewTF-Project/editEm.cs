using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTF_Project
{
    public partial class editEm : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        string ed;
        emForm1 emForm;
        Employee em;
        public editEm(string ed, emForm1 emForm)
        {
            this.emForm = emForm;
            this.ed = ed;
            em = context.Employees
                .Where(s => s.employee_user == ed).First();
            
            InitializeComponent();
        }

        private void EditEm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = emForm.Location;
            bindingSource1.DataSource = em;
            var items = context.Employees
                .Select(s => new { s.employee_position})
                .Distinct();
            foreach(var item in items)
            {
                comboBox1.Items.Add(item.ToString());
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            emForm.updateDataSource();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            
            int save = context.SaveChanges();
            if (save > 0)
            {
                MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว");
                emForm.updateDataSource();
                this.Close();
            }
        }

    }
}
