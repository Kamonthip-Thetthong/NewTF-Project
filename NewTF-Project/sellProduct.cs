using AForge.Video.DirectShow;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace NewTF_Project
{
    public partial class sellProduct : Form
    {
        FilterInfoCollection webcams;
        VideoCaptureDevice videoIn;
        bool isOpen = false;
        int price = 0;
        int clickIn = 1;
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        public sellProduct()
        {
            InitializeComponent();
        }

        private void SellProduct_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);

            label2.Left = (this.Width - label2.Width) / 2;

            productNewBindingSource.DataSource = context.ProductNews
                .Where(p => p.product_status != 0)
                .ToList();

            productSetBindingSource.DataSource = context.ProductSets
                .Where(p => p.set_isDel == 0 && p.set_status == true)
                .ToList();
            webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo webcam in webcams)
            {
                comboBox1.Items.Add(webcam.Name);
            }
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            productNewBindingSource.DataSource = context.ProductNews
                .Where(p => p.product_status != 0 && (
                p.product_id.ToString().Contains(textBox1.Text) ||
                p.product_name.Contains(textBox1.Text) ||
                p.product_detail.Contains(textBox1.Text) ||
                p.product_type.Contains(textBox1.Text)))
                .ToList();
            productSetBindingSource.DataSource = context.ProductSets
                .Where(p => p.set_id.ToString().Contains(textBox1.Text) ||
                p.set_name.Contains(textBox1.Text) &&
                p.set_status == true && p.set_isDel == 0)
                .ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(isOpen == false)
            {
                int selectedCamInd = comboBox1.SelectedIndex;
                videoIn = new VideoCaptureDevice(webcams[selectedCamInd].MonikerString);
                videoSourcePlayer1.VideoSource = videoIn;
                videoSourcePlayer1.Start();
                isOpen = true;
                timer1.Start();
            }
            else
            {
                if(videoIn != null && videoIn.IsRunning)
                {
                    videoSourcePlayer1.Stop();
                    timer1.Stop();
                    isOpen = false;
                }
            }
        }

        private void SellProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoIn != null && videoIn.IsRunning)
            {
                videoSourcePlayer1.Stop();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var capture = videoSourcePlayer1.GetCurrentVideoFrame();
            if(capture != null)
            {
                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode(capture);
                if (result != null)
                {
                    int id = int.Parse(result.Text);
                    try
                    {
                        if( result.Text.Length == 5)
                        {
                            productNewBindingSource.DataSource = context.ProductNews
                                .Where(p => p.product_id == id)
                                .First();
                            productSetBindingSource.Clear();
                        }
                        else if(result.Text.Length == 6)
                        {
                            productSetBindingSource.DataSource = context.ProductSets
                                .Where(p => p.set_id == id)
                                .First();
                            productNewBindingSource.Clear();
                        }
                        timer1.Stop();
                        videoSourcePlayer1.Stop();
                        isOpen = false;
                    }
                    catch
                    {
                        MessageBox.Show("ไม่พบสินค้า");
                    }
                    
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("จำนวนสินค้า", "กรุณาใส่จำนวนสินค้า", "0", -1, -1);
            int num = 0;
            try
            {
                num = int.Parse(input);
            }
            catch
            {
                MessageBox.Show("กรุณาใส่เป็นตัวเลข!!!");
            }
            
            if (num > 0)
            {
                string str = "";
                if(clickIn == 1)
                {
                    str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                }
                else if(clickIn == 2)
                {
                    str = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                }
                int id = int.Parse(str);
                
                if(str.Length == 5)
                {
                    var result = context.ProductNews
                        .Where(p => p.product_id == id)
                        .First();
                    if(result.product_amount >= num)
                    {
                        string[] item = new string[]
                        {
                            str,
                            result.product_name,
                            num.ToString(),
                            (result.product_price * num).ToString()
                        };
                        listView1.Items.Add(new ListViewItem(item));
                        price += (int)result.product_price * num;
                        label6.Text = price.ToString();
                    }
                    else
                    {
                        MessageBox.Show("สินค้ามีจำนวนไม่พอ!!");
                    }
                    
                }else if(str.Length == 6)
                {
                    var result = context.ProductSets
                        .Where(p => p.set_id == id)
                        .First();
                    var sets = context.Composes
                        .Where(c => c.set_id == result.set_id)
                        .ToList();

                    bool moreThanStore = false;
                    foreach(var set in sets)
                    {
                        if(set.product_amount > num)
                        {
                            moreThanStore = true;
                            break;
                        }
                    }
                    if(moreThanStore == true)
                    {
                        string[] item = new string[]
                        {
                            str,
                            result.set_name,
                            num.ToString(),
                            (result.set_price * num).ToString()
                        };
                        listView1.Items.Add(new ListViewItem(item));
                        price += (int)result.set_price * num;
                        label6.Text = price.ToString();
                    }
                    else
                    {
                        MessageBox.Show("สินค้ามีจำนวนไม่พอ!!");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกจำนวนสินค้า");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            price = 0;
            listView1.Items.Clear();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clickIn = 1;
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clickIn = 2;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickIn = 1;
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickIn = 2;
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    string input = Interaction.InputBox("จำนวนสินค้า", "กรุณาใส่จำนวนสินค้า", listView1.Items[i].SubItems[2].Text, -1, -1);
                    if(int.Parse(input) <= 0)
                    {
                        MessageBox.Show("จำนวนสินค้าต้องไม่น้อยกว่า 0");
                    }
                    else
                    {
                        int pr = (int.Parse(listView1.Items[i].SubItems[3].Text) / int.Parse(listView1.Items[i].SubItems[2].Text));
                        price -= (int.Parse(listView1.Items[i].SubItems[3].Text));
                        listView1.Items[i].SubItems[2].Text = input;
                        listView1.Items[i].SubItems[3].Text = (int.Parse(input) * pr).ToString();
                        price += int.Parse(listView1.Items[i].SubItems[3].Text);
                        label6.Text = price.ToString();
                    }
                    
                }
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    price -= (int.Parse(listView1.Items[i].SubItems[3].Text));
                    label6.Text = price.ToString();
                    listView1.Items[i].Remove();
                }
            }
        }
    }
}
