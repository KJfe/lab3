namespace View
{
    partial class AddObject
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
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lableValume = new System.Windows.Forms.Label();
            this.labelDeep = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.Deep = new System.Windows.Forms.TextBox();
            this.Height = new System.Windows.Forms.TextBox();
            this.Width = new System.Windows.Forms.TextBox();
            this.tbValume = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(12, 233);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 0;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(93, 233);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lableValume);
            this.groupBox1.Controls.Add(this.labelDeep);
            this.groupBox1.Controls.Add(this.labelHeight);
            this.groupBox1.Controls.Add(this.labelWidth);
            this.groupBox1.Controls.Add(this.Deep);
            this.groupBox1.Controls.Add(this.Height);
            this.groupBox1.Controls.Add(this.Width);
            this.groupBox1.Controls.Add(this.tbValume);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 215);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volume";
            // 
            // lableValume
            // 
            this.lableValume.AutoSize = true;
            this.lableValume.Location = new System.Drawing.Point(6, 173);
            this.lableValume.Name = "lableValume";
            this.lableValume.Size = new System.Drawing.Size(42, 13);
            this.lableValume.TabIndex = 8;
            this.lableValume.Text = "Volume";
            this.lableValume.Visible = false;
            // 
            // labelDeep
            // 
            this.labelDeep.AutoSize = true;
            this.labelDeep.Location = new System.Drawing.Point(6, 129);
            this.labelDeep.Name = "labelDeep";
            this.labelDeep.Size = new System.Drawing.Size(33, 13);
            this.labelDeep.TabIndex = 7;
            this.labelDeep.Text = "Deep";
            this.labelDeep.Visible = false;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(6, 90);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 6;
            this.labelHeight.Text = "Height";
            this.labelHeight.Visible = false;
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(6, 51);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 5;
            this.labelWidth.Text = "Width";
            this.labelWidth.Visible = false;
            // 
            // Deep
            // 
            this.Deep.Location = new System.Drawing.Point(6, 145);
            this.Deep.Name = "Deep";
            this.Deep.Size = new System.Drawing.Size(100, 20);
            this.Deep.TabIndex = 4;
            this.Deep.Visible = false;
            // 
            // Height
            // 
            this.Height.Location = new System.Drawing.Point(6, 106);
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(100, 20);
            this.Height.TabIndex = 3;
            this.Height.Visible = false;
            // 
            // Width
            // 
            this.Width.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Width.BackColor = System.Drawing.SystemColors.Window;
            this.Width.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Width.Location = new System.Drawing.Point(6, 67);
            this.Width.Name = "Width";
            this.Width.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Width.Size = new System.Drawing.Size(100, 20);
            this.Width.TabIndex = 2;
            this.Width.Visible = false;
            // 
            // tbValume
            // 
            this.tbValume.Enabled = false;
            this.tbValume.Location = new System.Drawing.Point(6, 189);
            this.tbValume.Name = "tbValume";
            this.tbValume.Size = new System.Drawing.Size(100, 20);
            this.tbValume.TabIndex = 1;
            this.tbValume.Visible = false;
            // 
            // AddObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 268);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddObject";
            this.Text = "AddObject";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbValume;
        private System.Windows.Forms.Label lableValume;
        private System.Windows.Forms.Label labelDeep;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TextBox Deep;
        private System.Windows.Forms.TextBox Height;
        private System.Windows.Forms.TextBox Width;
    }
}