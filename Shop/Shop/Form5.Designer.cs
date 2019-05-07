namespace Shop
{
    partial class Form5
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
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summabuyerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyer1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.archive3DataSet = new Shop.Archive3DataSet();
            this.buyer1TableAdapter = new Shop.Archive3DataSetTableAdapters.buyer1TableAdapter();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btnDEL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buyer1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archive3DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.surnameDataGridViewTextBoxColumn,
            this.summabuyerDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.buyer1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(51, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(242, 251);
            this.dataGridView1.TabIndex = 0;
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "Surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "Surname";
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            // 
            // summabuyerDataGridViewTextBoxColumn
            // 
            this.summabuyerDataGridViewTextBoxColumn.DataPropertyName = "summa_buyer";
            this.summabuyerDataGridViewTextBoxColumn.HeaderText = "summa_buyer";
            this.summabuyerDataGridViewTextBoxColumn.Name = "summabuyerDataGridViewTextBoxColumn";
            this.summabuyerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // buyer1BindingSource
            // 
            this.buyer1BindingSource.DataMember = "buyer1";
            this.buyer1BindingSource.DataSource = this.archive3DataSet;
            // 
            // archive3DataSet
            // 
            this.archive3DataSet.DataSetName = "Archive3DataSet";
            this.archive3DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buyer1TableAdapter
            // 
            this.buyer1TableAdapter.ClearBeforeFill = true;
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(400, 54);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(100, 23);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "SQL";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(400, 83);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(100, 23);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "Поиск по ключу";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btnDEL
            // 
            this.btnDEL.Location = new System.Drawing.Point(425, 282);
            this.btnDEL.Name = "btnDEL";
            this.btnDEL.Size = new System.Drawing.Size(75, 23);
            this.btnDEL.TabIndex = 3;
            this.btnDEL.Text = "Очистить";
            this.btnDEL.UseVisualStyleBackColor = true;
            this.btnDEL.Click += new System.EventHandler(this.btnDEL_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDEL);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form5";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buyer1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archive3DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Archive3DataSet archive3DataSet;
        private System.Windows.Forms.BindingSource buyer1BindingSource;
        private Archive3DataSetTableAdapters.buyer1TableAdapter buyer1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summabuyerDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btnDEL;
    }
}