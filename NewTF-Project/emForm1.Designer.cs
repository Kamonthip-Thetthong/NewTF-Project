namespace NewTF_Project
{
    partial class emForm1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.employeenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeaddrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeesalaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeedateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeetelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeepositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeuserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeepassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeenameDataGridViewTextBoxColumn,
            this.employeeaddrDataGridViewTextBoxColumn,
            this.employeesalaryDataGridViewTextBoxColumn,
            this.employeedateDataGridViewTextBoxColumn,
            this.employeetelDataGridViewTextBoxColumn,
            this.employeepositionDataGridViewTextBoxColumn,
            this.employeeuserDataGridViewTextBoxColumn,
            this.employeepassDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.employeeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(26, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(854, 449);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("KodchiangUPC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(85, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(352, 34);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("KodchiangUPC", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "ค้นหา";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("KodchiangUPC", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(886, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "เพิ่มพนักงาน";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("KodchiangUPC", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(886, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "แก้ไขข้อมูล";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkRed;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("KodchiangUPC", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(886, 526);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "ไล่ออก";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1055, 45);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("KodchiangUPC", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(460, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "พนักงานทั้งหมด";
            // 
            // employeenameDataGridViewTextBoxColumn
            // 
            this.employeenameDataGridViewTextBoxColumn.DataPropertyName = "employee_name";
            this.employeenameDataGridViewTextBoxColumn.HeaderText = "employee_name";
            this.employeenameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeenameDataGridViewTextBoxColumn.Name = "employeenameDataGridViewTextBoxColumn";
            this.employeenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeenameDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeaddrDataGridViewTextBoxColumn
            // 
            this.employeeaddrDataGridViewTextBoxColumn.DataPropertyName = "employee_addr";
            this.employeeaddrDataGridViewTextBoxColumn.HeaderText = "employee_addr";
            this.employeeaddrDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeeaddrDataGridViewTextBoxColumn.Name = "employeeaddrDataGridViewTextBoxColumn";
            this.employeeaddrDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeaddrDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeesalaryDataGridViewTextBoxColumn
            // 
            this.employeesalaryDataGridViewTextBoxColumn.DataPropertyName = "employee_salary";
            this.employeesalaryDataGridViewTextBoxColumn.HeaderText = "employee_salary";
            this.employeesalaryDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeesalaryDataGridViewTextBoxColumn.Name = "employeesalaryDataGridViewTextBoxColumn";
            this.employeesalaryDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeesalaryDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeedateDataGridViewTextBoxColumn
            // 
            this.employeedateDataGridViewTextBoxColumn.DataPropertyName = "employee_date";
            this.employeedateDataGridViewTextBoxColumn.HeaderText = "employee_date";
            this.employeedateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeedateDataGridViewTextBoxColumn.Name = "employeedateDataGridViewTextBoxColumn";
            this.employeedateDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeedateDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeetelDataGridViewTextBoxColumn
            // 
            this.employeetelDataGridViewTextBoxColumn.DataPropertyName = "employee_tel";
            this.employeetelDataGridViewTextBoxColumn.HeaderText = "employee_tel";
            this.employeetelDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeetelDataGridViewTextBoxColumn.Name = "employeetelDataGridViewTextBoxColumn";
            this.employeetelDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeetelDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeepositionDataGridViewTextBoxColumn
            // 
            this.employeepositionDataGridViewTextBoxColumn.DataPropertyName = "employee_position";
            this.employeepositionDataGridViewTextBoxColumn.HeaderText = "employee_position";
            this.employeepositionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeepositionDataGridViewTextBoxColumn.Name = "employeepositionDataGridViewTextBoxColumn";
            this.employeepositionDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeepositionDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeuserDataGridViewTextBoxColumn
            // 
            this.employeeuserDataGridViewTextBoxColumn.DataPropertyName = "employee_user";
            this.employeeuserDataGridViewTextBoxColumn.HeaderText = "employee_user";
            this.employeeuserDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeeuserDataGridViewTextBoxColumn.Name = "employeeuserDataGridViewTextBoxColumn";
            this.employeeuserDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeuserDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeepassDataGridViewTextBoxColumn
            // 
            this.employeepassDataGridViewTextBoxColumn.DataPropertyName = "employee_pass";
            this.employeepassDataGridViewTextBoxColumn.HeaderText = "employee_pass";
            this.employeepassDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeepassDataGridViewTextBoxColumn.Name = "employeepassDataGridViewTextBoxColumn";
            this.employeepassDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeepassDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(NewTF_Project.Employee);
            // 
            // emForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1055, 578);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "emForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "emForm1";
            this.Load += new System.EventHandler(this.EmForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeaddrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeesalaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeedateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeetelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeepositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeuserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeepassDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}