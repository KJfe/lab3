namespace View
{
    partial class AddOrModify
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
            this.objectControl1 = new View.ObjectControl();
            this.Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // objectControl1
            // 
            //this.objectControl1.Delegate = null;
            this.objectControl1.Location = new System.Drawing.Point(3, 5);
            this.objectControl1.Name = "objectControl1";
            this.objectControl1.Object = null;
            this.objectControl1.ReadOnly = false;
            this.objectControl1.Size = new System.Drawing.Size(165, 229);
            this.objectControl1.TabIndex = 0;
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(85, 208);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 1;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // AddOrModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(168, 237);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.objectControl1);
            this.Name = "AddOrModify";
            this.Text = "AddOrModify";
            this.ResumeLayout(false);

        }

        #endregion

        private ObjectControl objectControl1;
        private System.Windows.Forms.Button Close;
    }
}