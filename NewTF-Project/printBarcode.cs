using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace NewTF_Project
{
    public partial class printBarcode : Form
    {
        apd621_60011212001Entities context = new apd621_60011212001Entities();
        int id;
        public printBarcode(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void PrintBarcode_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);

            label2.Left = (this.Width - label2.Width) / 2;

            var result = context.ProductNews
                .Where(p => p.product_id == id)
                .First();

            label8.Text = result.product_id.ToString();
            label9.Text = result.product_name;
            label10.Text = result.product_detail;
            label14.Text = result.product_type;
            label11.Text = result.product_price.ToString();
            label12.Text = result.product_amount.ToString();
            pictureBox2.Image = byteArrayToImage(result.product_picture);

            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.CharacterSet = "UTF-8";
            options.Width = 200;
            options.Height = 100;

            BarcodeWriter writer = new BarcodeWriter();
            writer.Options = options;
            writer.Format = BarcodeFormat.CODE_39;
            var bc = writer.Write(id.ToString());
            pictureBox1.Image = bc;

            QrCodeEncodingOptions options1 = new QrCodeEncodingOptions();
            options1.CharacterSet = "UTF-8";
            options1.Width = 200;
            options1.Height = 200;

            BarcodeWriter writer1 = new BarcodeWriter();
            writer1.Options = options1;
            writer1.Format = BarcodeFormat.QR_CODE;
            var qr = writer1.Write(id.ToString());
            pictureBox3.Image = qr;
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            int x = 5;
            int y = 5;
            for(var i=0; i<numericUpDown1.Value; i++)
            {
                if (radioButton1.Checked)
                {
                    if (x < 1000 - pictureBox1.Width)
                    {
                        Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                        e.Graphics.DrawImage(bm, x, y);
                        bm.Dispose();
                    }
                    else
                    {
                        y += pictureBox1.Height + 5;
                        x = 5;
                        Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                        e.Graphics.DrawImage(bm, x, y);
                        bm.Dispose();
                    }
                }
                else
                {
                    if (x < 1000 - pictureBox3.Width)
                    {
                        Bitmap bm = new Bitmap(pictureBox3.Width, pictureBox3.Height);
                        pictureBox3.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox3.Width, pictureBox3.Height));
                        e.Graphics.DrawImage(bm, x, y);
                        bm.Dispose();
                    }
                    else
                    {
                        y += pictureBox3.Height + 5;
                        x = 5;
                        Bitmap bm = new Bitmap(pictureBox3.Width, pictureBox3.Height);
                        pictureBox3.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox3.Width, pictureBox3.Height));
                        e.Graphics.DrawImage(bm, x, y);
                        bm.Dispose();
                    }
                }
                
                x += pictureBox1.Width + 10;
                
            }
            e.Graphics.PageUnit = GraphicsUnit.Pixel;

            //e.Graphics.DrawString("Test", new Font("Times New Roman", 30, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
