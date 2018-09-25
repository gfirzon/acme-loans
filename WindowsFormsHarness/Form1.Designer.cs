namespace WindowsFormsHarness
{
    partial class Form1
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
            this.ucA1 = new WindowsFormsHarness.ucA();
            this.btnSetValues = new System.Windows.Forms.Button();
            this.txtLN = new System.Windows.Forms.TextBox();
            this.txtFN = new System.Windows.Forms.TextBox();
            this.btnGetValues = new System.Windows.Forms.Button();
            this.txtMN = new System.Windows.Forms.TextBox();
            this.ucB1 = new WindowsFormsHarness.ucB();
            this.SuspendLayout();
            // 
            // ucA1
            // 
            this.ucA1.Location = new System.Drawing.Point(12, 12);
            this.ucA1.Margin = new System.Windows.Forms.Padding(4);
            this.ucA1.Name = "ucA1";
            this.ucA1.Size = new System.Drawing.Size(397, 59);
            this.ucA1.TabIndex = 0;
            // 
            // btnSetValues
            // 
            this.btnSetValues.Location = new System.Drawing.Point(32, 192);
            this.btnSetValues.Name = "btnSetValues";
            this.btnSetValues.Size = new System.Drawing.Size(75, 23);
            this.btnSetValues.TabIndex = 1;
            this.btnSetValues.Text = "Set Values";
            this.btnSetValues.UseVisualStyleBackColor = true;
            this.btnSetValues.Click += new System.EventHandler(this.btnSetValues_Click);
            // 
            // txtLN
            // 
            this.txtLN.Location = new System.Drawing.Point(124, 192);
            this.txtLN.Name = "txtLN";
            this.txtLN.Size = new System.Drawing.Size(100, 20);
            this.txtLN.TabIndex = 2;
            // 
            // txtFN
            // 
            this.txtFN.Location = new System.Drawing.Point(238, 192);
            this.txtFN.Name = "txtFN";
            this.txtFN.Size = new System.Drawing.Size(100, 20);
            this.txtFN.TabIndex = 3;
            this.txtFN.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnGetValues
            // 
            this.btnGetValues.Location = new System.Drawing.Point(32, 221);
            this.btnGetValues.Name = "btnGetValues";
            this.btnGetValues.Size = new System.Drawing.Size(75, 23);
            this.btnGetValues.TabIndex = 4;
            this.btnGetValues.Text = "Get Values";
            this.btnGetValues.UseVisualStyleBackColor = true;
            this.btnGetValues.Click += new System.EventHandler(this.btnGetValues_Click);
            // 
            // txtMN
            // 
            this.txtMN.Location = new System.Drawing.Point(358, 192);
            this.txtMN.Margin = new System.Windows.Forms.Padding(2);
            this.txtMN.Name = "txtMN";
            this.txtMN.Size = new System.Drawing.Size(120, 20);
            this.txtMN.TabIndex = 5;
            // 
            // ucB1
            // 
            this.ucB1.Location = new System.Drawing.Point(13, 70);
            this.ucB1.Name = "ucB1";
            this.ucB1.Size = new System.Drawing.Size(300, 60);
            this.ucB1.TabIndex = 6;
            this.ucB1.DogShowedUp += new WindowsFormsHarness.AAA(this.ucB1_DogShowedUp);
            this.ucB1.CatShowedUp += new WindowsFormsHarness.AAA(this.ucB1_CatShowedUp);
            this.ucB1.Load += new System.EventHandler(this.ucB1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 249);
            this.Controls.Add(this.ucB1);
            this.Controls.Add(this.txtMN);
            this.Controls.Add(this.btnGetValues);
            this.Controls.Add(this.txtFN);
            this.Controls.Add(this.txtLN);
            this.Controls.Add(this.btnSetValues);
            this.Controls.Add(this.ucA1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucA ucA1;
        private System.Windows.Forms.Button btnSetValues;
        private System.Windows.Forms.TextBox txtLN;
        private System.Windows.Forms.TextBox txtFN;
        private System.Windows.Forms.Button btnGetValues;
        private System.Windows.Forms.TextBox txtMN;
        private ucB ucB1;
    }
}

