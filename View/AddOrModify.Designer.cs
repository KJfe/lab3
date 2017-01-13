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
            this.Close = new System.Windows.Forms.Button();
            this.objectControlForFigure = new View.ObjectControl();
            this.SuspendLayout();
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
            // objectControlForFigure
            // 
            this.objectControlForFigure.Location = new System.Drawing.Point(3, 5);
            this.objectControlForFigure.Name = "objectControlForFigure";
            this.objectControlForFigure.ObjectFigur = null;
            this.objectControlForFigure.ReadOnly = false;
            this.objectControlForFigure.Size = new System.Drawing.Size(165, 229);
            this.objectControlForFigure.TabIndex = 0;
            // 
            // AddOrModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(168, 237);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.objectControlForFigure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddOrModify";
            this.Text = "AddOrModify";
            this.ResumeLayout(false);

        }

        #endregion

        private ObjectControl objectControlForFigure;
        private System.Windows.Forms.Button Close;
    }
}