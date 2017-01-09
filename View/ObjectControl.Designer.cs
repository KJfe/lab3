namespace View
{
    partial class ObjectControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Width = new System.Windows.Forms.TextBox();
            this.Height = new System.Windows.Forms.TextBox();
            this.Deep = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTypeFigure = new System.Windows.Forms.ComboBox();
            this.labelDeep = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.VolumeFigureText = new System.Windows.Forms.TextBox();
            this.Ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Width
            // 
            this.Width.Location = new System.Drawing.Point(6, 60);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(100, 20);
            this.Width.TabIndex = 0;
            // 
            // Height
            // 
            this.Height.Location = new System.Drawing.Point(6, 101);
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(100, 20);
            this.Height.TabIndex = 1;
            // 
            // Deep
            // 
            this.Deep.Location = new System.Drawing.Point(6, 139);
            this.Deep.Name = "Deep";
            this.Deep.Size = new System.Drawing.Size(100, 20);
            this.Deep.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTypeFigure);
            this.groupBox1.Controls.Add(this.labelDeep);
            this.groupBox1.Controls.Add(this.labelHeight);
            this.groupBox1.Controls.Add(this.labelWidth);
            this.groupBox1.Controls.Add(this.VolumeFigureText);
            this.groupBox1.Controls.Add(this.Width);
            this.groupBox1.Controls.Add(this.Height);
            this.groupBox1.Controls.Add(this.Deep);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 197);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volume";
            // 
            // cbTypeFigure
            // 
            this.cbTypeFigure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeFigure.FormattingEnabled = true;
            this.cbTypeFigure.Items.AddRange(new object[] {
            "Parallepiped",
            "Sphear",
            "Pyramid"});
            this.cbTypeFigure.Location = new System.Drawing.Point(6, 19);
            this.cbTypeFigure.Name = "cbTypeFigure";
            this.cbTypeFigure.Size = new System.Drawing.Size(121, 21);
            this.cbTypeFigure.TabIndex = 8;
            this.cbTypeFigure.SelectedIndexChanged += new System.EventHandler(this.cbTypeFigure_SelectedIndexChanged);
            // 
            // labelDeep
            // 
            this.labelDeep.AutoSize = true;
            this.labelDeep.Location = new System.Drawing.Point(6, 123);
            this.labelDeep.Name = "labelDeep";
            this.labelDeep.Size = new System.Drawing.Size(33, 13);
            this.labelDeep.TabIndex = 7;
            this.labelDeep.Text = "Deep";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(6, 85);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 6;
            this.labelHeight.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(6, 44);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 5;
            this.labelWidth.Text = "Width";
            // 
            // VolumeFigureText
            // 
            this.VolumeFigureText.Enabled = false;
            this.VolumeFigureText.Location = new System.Drawing.Point(6, 165);
            this.VolumeFigureText.Name = "VolumeFigureText";
            this.VolumeFigureText.Size = new System.Drawing.Size(69, 20);
            this.VolumeFigureText.TabIndex = 4;
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(3, 203);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 6;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // ObjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.groupBox1);
            this.Name = "ObjectControl";
            this.Size = new System.Drawing.Size(165, 229);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Width;
        private System.Windows.Forms.TextBox Height;
        private System.Windows.Forms.TextBox Deep;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox VolumeFigureText;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelDeep;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.ComboBox cbTypeFigure;
        private System.Windows.Forms.Button Ok;
    }
}
