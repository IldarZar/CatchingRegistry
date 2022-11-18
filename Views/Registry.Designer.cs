namespace CatchingRegistry.Views
{
    partial class Registry
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewRegistry = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddRecord = new System.Windows.Forms.Button();
            this.buttonRemoveRecord = new System.Windows.Forms.Button();
            this.buttonOpenCard = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistry)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewRegistry
            // 
            this.dataGridViewRegistry.AllowUserToAddRows = false;
            this.dataGridViewRegistry.AllowUserToDeleteRows = false;
            this.dataGridViewRegistry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegistry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRegistry.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewRegistry.Name = "dataGridViewRegistry";
            this.dataGridViewRegistry.ReadOnly = true;
            this.dataGridViewRegistry.RowHeadersVisible = false;
            this.dataGridViewRegistry.RowHeadersWidth = 51;
            this.dataGridViewRegistry.RowTemplate.Height = 29;
            this.dataGridViewRegistry.Size = new System.Drawing.Size(1192, 341);
            this.dataGridViewRegistry.TabIndex = 0;
            this.dataGridViewRegistry.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRegistry_CellClick);
            this.dataGridViewRegistry.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRegistry_CellDoubleClick);
            this.dataGridViewRegistry.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewRegistry);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1198, 367);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Реестр отлова";
            // 
            // buttonAddRecord
            // 
            this.buttonAddRecord.Location = new System.Drawing.Point(226, 385);
            this.buttonAddRecord.Name = "buttonAddRecord";
            this.buttonAddRecord.Size = new System.Drawing.Size(101, 51);
            this.buttonAddRecord.TabIndex = 2;
            this.buttonAddRecord.Text = "Создать акт отлова";
            this.buttonAddRecord.UseVisualStyleBackColor = true;
            this.buttonAddRecord.Click += new System.EventHandler(this.buttonAddRecord_Click);
            // 
            // buttonRemoveRecord
            // 
            this.buttonRemoveRecord.Location = new System.Drawing.Point(333, 385);
            this.buttonRemoveRecord.Name = "buttonRemoveRecord";
            this.buttonRemoveRecord.Size = new System.Drawing.Size(102, 51);
            this.buttonRemoveRecord.TabIndex = 3;
            this.buttonRemoveRecord.Text = "Удалить";
            this.buttonRemoveRecord.UseVisualStyleBackColor = true;
            this.buttonRemoveRecord.Click += new System.EventHandler(this.buttonRemoveRecord_Click);
            // 
            // buttonOpenCard
            // 
            this.buttonOpenCard.Location = new System.Drawing.Point(115, 385);
            this.buttonOpenCard.Name = "buttonOpenCard";
            this.buttonOpenCard.Size = new System.Drawing.Size(105, 51);
            this.buttonOpenCard.TabIndex = 4;
            this.buttonOpenCard.Text = "Открыть";
            this.buttonOpenCard.UseVisualStyleBackColor = true;
            this.buttonOpenCard.Click += new System.EventHandler(this.buttonOpenCard_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 51);
            this.button1.TabIndex = 6;
            this.button1.Text = "Экспорт в Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 549);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(46, 20);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "name";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(84, 549);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(35, 20);
            this.labelRole.TabIndex = 8;
            this.labelRole.Text = "role";
            // 
            // Registry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 578);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonAddRecord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonOpenCard);
            this.Controls.Add(this.buttonRemoveRecord);
            this.Controls.Add(this.groupBox1);
            this.Name = "Registry";
            this.Text = "Реестр отлова";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Registry_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistry)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewRegistry;
        private GroupBox groupBox1;
        private Button buttonAddRecord;
        private Button buttonRemoveRecord;
        private Button buttonOpenCard;
        private Button button1;
        private Label labelName;
        private Label labelRole;
    }
}