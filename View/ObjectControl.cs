using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ValumeFigyre;

namespace View
{
    enum Figures : int
    {
        Box = 0,
        Sphear = 1,
        Pyramid = 2
    };
    public partial class ObjectControl : UserControl
    {
        //private TextBox textBox1;
        public ObjectControl()
        {
            InitializeComponent();
        }
        private TextBox tx(string Name,int LocationX,int LocationY)
        {
            TextBox txb = new TextBox();
            txb.Name = Name;
            txb.Location = new System.Drawing.Point(LocationX, LocationY);
            txb.Size = new System.Drawing.Size(100, 20);
            txb.Visible = true;
            Controls.Add(txb);
            groupBox1.Controls.Add(txb);
            return (txb);
        }
        /// <summary>
        /// Метод принимающий/отправляющий данные
        /// </summary>
        private IValumeFigyre _VolumeFigure;
        public IValumeFigyre Object
        {
            get
            {
                return _VolumeFigure;
            }
            set
            {
                _VolumeFigure = value;
                if (_VolumeFigure == null)
                    return;
                if (value.TypeFigyre == "Sphear")
                { 
                    /*Width.Text = value.Parametr[0].ToString();
                    Height.Text = "";
                    Deep.Text = "";
                    Width.Visible = true;
                    Height.Visible = false;
                    Deep.Visible = false;*/
                    cbTypeFigure.SelectedIndex = 1;
                }
                else if (value.TypeFigyre == "Parallepiped")
                {    
                    /*Width.Text = value.Parametr[0].ToString();
                    Height.Text = value.Parametr[1].ToString();
                    Deep.Text = value.Parametr[2].ToString();
                    Width.Visible = true;
                    Height.Visible = true;
                    Deep.Visible = true;*/
                    cbTypeFigure.SelectedIndex = 0;
                }
                else
                {                   
                    /*Width.Text = value.Parametr[0].ToString();
                    Height.Text = value.Parametr[1].ToString();
                    Deep.Text = "";
                    Width.Visible = true;
                    Height.Visible = true;
                    Deep.Visible = false;*/
                    cbTypeFigure.SelectedIndex = 2;
                }
            }
        }
        /// <summary>
        /// Метод разрешающий/запрещающий редактировать параметры
        /// </summary>
        private bool _ReadOnly;
        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                _ReadOnly = value;
                /*Width.Enabled = !value;
                Height.Enabled = !value;
                Deep.Enabled = !value;*/
                cbTypeFigure.Enabled = !value;
                Ok.Enabled = !value;
            }
        }
        /// <summary>
        /// Выбор необходимый тип фигуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private BindingList<TextBox> TextBoxList = new BindingList<TextBox>();
        private List<ControlCollection> ListContol = new List<ControlCollection>();
        public void cbTypeFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            var create = new CreateTextBox();
            ListContol.Add(Controls);
            ListContol.Add(groupBox1.Controls);
            create.PerformOperation(((Figures)cbTypeFigure.SelectedIndex).ToString(), TextBoxList, ListContol);
        }
        /// <summary>
        /// расчет объема фигуры
        /// </summary>
        private void SelectionFigyre()
        {
            IValumeFigyre VolumeFigure = null;
            /*switch ((Figures)cbTypeFigure.SelectedIndex)
            {
                case Figures.Box:
                    {
                        double heightBox = InspectionParametr.Parametr(Height.Text, Height.Name);
                        double widthBox = InspectionParametr.Parametr(Width.Text, Width.Name);
                        double deepBox = InspectionParametr.Parametr(Deep.Text, Deep.Name);
                        VolumeFigure = new Box(height: heightBox, width: widthBox, deep: deepBox);
                        break;
                    }
                case Figures.Sphear:
                    {
                        double radiusSphear = InspectionParametr.Parametr(Width.Text, "Radius");
                        VolumeFigure = new Sphear(radius: radiusSphear);
                        break;
                    }

                case Figures.Pyramid:
                    {
                        double heightPyramid = InspectionParametr.Parametr(Height.Text, Height.Name);
                        double areaPyramid = InspectionParametr.Parametr(Width.Text, "Area");
                        VolumeFigure = new Pyramid(height: heightPyramid, area: areaPyramid);
                        break;
                    }
            }*/
            if (VolumeFigure != null)
            {
                VolumeFigureText.Text = Convert.ToString(VolumeFigure.Valume);                
                Object= VolumeFigure;
            }
        }
        /// <summary>
        /// проверка при расчете объема фигуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Click(object sender, EventArgs e)
        {
            try
            {
                SelectionFigyre();
            }
            catch (CellOutOfRangeExxeption cellOutOfRangeExxeption)
            {
                MessageBox.Show(cellOutOfRangeExxeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (CellFormatException cellFormatError)
            {
                MessageBox.Show(cellFormatError.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
