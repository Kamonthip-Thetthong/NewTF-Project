﻿namespace NewTF_Project
{
    partial class proForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.productNewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producttypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productdatailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productpictureDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.productamountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.composesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productNewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("KodchiangUPC", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(460, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "แก้ไขข้อมูลพนักงาน";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1055, 45);
            this.panel1.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1055, 533);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1047, 495);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "รายการสินค้าทั้งหมด";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("KodchiangUPC", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 26);
            this.label1.TabIndex = 34;
            this.label1.Text = "ค้นหา";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("KodchiangUPC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(69, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(352, 34);
            this.textBox1.TabIndex = 33;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("KodchiangUPC", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(887, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 40);
            this.button2.TabIndex = 32;
            this.button2.Text = "นำเข้าสินค้าใหม่";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productidDataGridViewTextBoxColumn,
            this.productnameDataGridViewTextBoxColumn,
            this.producttypeDataGridViewTextBoxColumn,
            this.productdatailDataGridViewTextBoxColumn,
            this.productpictureDataGridViewImageColumn,
            this.productamountDataGridViewTextBoxColumn,
            this.productpriceDataGridViewTextBoxColumn,
            this.composesDataGridViewTextBoxColumn,
            this.receiptsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.productNewBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(8, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(876, 418);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1047, 495);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "เซ็ตสินค้าที่ผ่านการอนุมัติแล้ว";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1047, 495);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "เซ็ตสินค้าที่ยังไม่ผ่านการอนุมัติ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // productNewBindingSource
            // 
            this.productNewBindingSource.DataSource = typeof(NewTF_Project.ProductNew);
            // 
            // productidDataGridViewTextBoxColumn
            // 
            this.productidDataGridViewTextBoxColumn.DataPropertyName = "product_id";
            this.productidDataGridViewTextBoxColumn.HeaderText = "product_id";
            this.productidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productidDataGridViewTextBoxColumn.Name = "productidDataGridViewTextBoxColumn";
            this.productidDataGridViewTextBoxColumn.ReadOnly = true;
            this.productidDataGridViewTextBoxColumn.Width = 125;
            // 
            // productnameDataGridViewTextBoxColumn
            // 
            this.productnameDataGridViewTextBoxColumn.DataPropertyName = "product_name";
            this.productnameDataGridViewTextBoxColumn.HeaderText = "product_name";
            this.productnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productnameDataGridViewTextBoxColumn.Name = "productnameDataGridViewTextBoxColumn";
            this.productnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.productnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // producttypeDataGridViewTextBoxColumn
            // 
            this.producttypeDataGridViewTextBoxColumn.DataPropertyName = "product_type";
            this.producttypeDataGridViewTextBoxColumn.HeaderText = "product_type";
            this.producttypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.producttypeDataGridViewTextBoxColumn.Name = "producttypeDataGridViewTextBoxColumn";
            this.producttypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.producttypeDataGridViewTextBoxColumn.Width = 125;
            // 
            // productdatailDataGridViewTextBoxColumn
            // 
            this.productdatailDataGridViewTextBoxColumn.DataPropertyName = "product_datail";
            this.productdatailDataGridViewTextBoxColumn.HeaderText = "product_datail";
            this.productdatailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productdatailDataGridViewTextBoxColumn.Name = "productdatailDataGridViewTextBoxColumn";
            this.productdatailDataGridViewTextBoxColumn.ReadOnly = true;
            this.productdatailDataGridViewTextBoxColumn.Width = 125;
            // 
            // productpictureDataGridViewImageColumn
            // 
            this.productpictureDataGridViewImageColumn.DataPropertyName = "product_picture";
            this.productpictureDataGridViewImageColumn.HeaderText = "product_picture";
            this.productpictureDataGridViewImageColumn.MinimumWidth = 6;
            this.productpictureDataGridViewImageColumn.Name = "productpictureDataGridViewImageColumn";
            this.productpictureDataGridViewImageColumn.ReadOnly = true;
            this.productpictureDataGridViewImageColumn.Width = 125;
            // 
            // productamountDataGridViewTextBoxColumn
            // 
            this.productamountDataGridViewTextBoxColumn.DataPropertyName = "product_amount";
            this.productamountDataGridViewTextBoxColumn.HeaderText = "product_amount";
            this.productamountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productamountDataGridViewTextBoxColumn.Name = "productamountDataGridViewTextBoxColumn";
            this.productamountDataGridViewTextBoxColumn.ReadOnly = true;
            this.productamountDataGridViewTextBoxColumn.Width = 125;
            // 
            // productpriceDataGridViewTextBoxColumn
            // 
            this.productpriceDataGridViewTextBoxColumn.DataPropertyName = "product_price";
            this.productpriceDataGridViewTextBoxColumn.HeaderText = "product_price";
            this.productpriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productpriceDataGridViewTextBoxColumn.Name = "productpriceDataGridViewTextBoxColumn";
            this.productpriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.productpriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // composesDataGridViewTextBoxColumn
            // 
            this.composesDataGridViewTextBoxColumn.DataPropertyName = "Composes";
            this.composesDataGridViewTextBoxColumn.HeaderText = "Composes";
            this.composesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.composesDataGridViewTextBoxColumn.Name = "composesDataGridViewTextBoxColumn";
            this.composesDataGridViewTextBoxColumn.ReadOnly = true;
            this.composesDataGridViewTextBoxColumn.Width = 125;
            // 
            // receiptsDataGridViewTextBoxColumn
            // 
            this.receiptsDataGridViewTextBoxColumn.DataPropertyName = "Receipts";
            this.receiptsDataGridViewTextBoxColumn.HeaderText = "Receipts";
            this.receiptsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.receiptsDataGridViewTextBoxColumn.Name = "receiptsDataGridViewTextBoxColumn";
            this.receiptsDataGridViewTextBoxColumn.ReadOnly = true;
            this.receiptsDataGridViewTextBoxColumn.Width = 125;
            // 
            // proForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 578);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "proForm1";
            this.Text = "proForm1";
            this.Load += new System.EventHandler(this.ProForm1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productNewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn producttypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productdatailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn productpictureDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productamountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn composesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptsDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource productNewBindingSource;
    }
}