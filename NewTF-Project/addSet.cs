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
    public partial class addSet : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        proForm1 pro;
        public addSet(proForm1 pro)
        {
            this.pro = pro;
            InitializeComponent();
        }

        private void AddSet_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);

            productNewBindingSource.DataSource = context.ProductNews
                .Where(p => p.product_status == 1)
                .ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(str);

            var result = context.ProductNews
                .Where(p => p.product_id == id)
                .First();

            string[] item = new string[]
            {
                result.product_id.ToString(),
                result.product_name,
                numericUpDown1.Value.ToString()
            };

            listView1.Items.Add(new ListViewItem(item));
        }
    }
}
