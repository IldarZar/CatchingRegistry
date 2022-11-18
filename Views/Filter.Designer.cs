namespace CatchingRegistry.Views
{
    partial class Filter
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
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearchByWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(48, 73);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(125, 27);
            this.textBoxFilter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поиск по слову";
            // 
            // buttonSearchByWord
            // 
            this.buttonSearchByWord.Location = new System.Drawing.Point(61, 106);
            this.buttonSearchByWord.Name = "buttonSearchByWord";
            this.buttonSearchByWord.Size = new System.Drawing.Size(97, 34);
            this.buttonSearchByWord.TabIndex = 2;
            this.buttonSearchByWord.Text = "Ок";
            this.buttonSearchByWord.UseVisualStyleBackColor = true;
            this.buttonSearchByWord.Click += new System.EventHandler(this.buttonSearchByWord_Click);
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 171);
            this.Controls.Add(this.buttonSearchByWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFilter);
            this.Name = "Filter";
            this.Text = "Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxFilter;
        private Label label1;
        private Button buttonSearchByWord;
    }
}