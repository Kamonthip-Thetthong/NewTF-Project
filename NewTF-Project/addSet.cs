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

            var result = context.ProductNews
                .Where(p => p.product_id == str)
                .First();

            string[] item = new string[]
            {
                result.product_id,
                result.product_name,
                numericUpDown1.Value.ToString()
            };

            listView1.Items.Add(new ListViewItem(item));
            numericUpDown1.Value = 1;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string setId = context.ProductSets
                .Select(p => new { p.set_ID })
                .Max(m => m.set_ID);
            int Id = int.Parse(setId);
            int newId = Id + 1;
            string newSetId = newId.ToString();
            //if(newId < 10)
            //{
            //    newSetId = string.Format("00{0}", newId);
            //}else if(newId < 100)
            //{
            //    newSetId = string.Format("0{00}", newId);
            //}
            //else
            //{
            //    newSetId = string.Format("0{00}", newId);
            //}
            ProductSet set = new ProductSet();
            set.set_ID = newSetId;
            set.set_name = textBox2.Text;
            set.set_status = false;
            set.set_price = Convert.ToDouble(textBox3.Text);
            set.set_isDel = 0;

            context.ProductSets.Add(set);
            context.SaveChanges();

            //var result = context.ProductSets
            //    .Select(p => new { p.set_id })
            //    .Max(m => m.set_id);
            
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                Compose com = new Compose();
                com.set_ID = newSetId;
                com.product_id =listView1.Items[i].SubItems[0].Text;
                com.product_amount = int.Parse(listView1.Items[i].SubItems[2].Text);
                context.Composes.Add(com);
                context.SaveChanges();
            }

            MessageBox.Show("เพิ่มเซ็ตสินค้าเรียบร้อยแล้ว กรูณารอการอนุมัติ");
            pro.updateSet();

            textBox2.Text = "";
            textBox3.Text = "";
            listView1.Items.Clear();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            listView1.Items.Clear();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
