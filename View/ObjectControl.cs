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
        private BindingList<TextBox> TextBoxList = new BindingList<TextBox>();
        private List<ControlCollection> ListContol = new List<ControlCollection>();

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
                    cbTypeFigure.SelectedIndex = 1;
                }
                else if (value.TypeFigyre == "Parallepiped")
                {    
                    cbTypeFigure.SelectedIndex = 0;
                }
                else
                {                   
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
            switch ((Figures)cbTypeFigure.SelectedIndex)
            {
                case Figures.Box:
                    {
                        double heightBox = InspectionParametr.Parametr(TextBoxList[0].Text, TextBoxList[0].Name);
                        double widthBox = InspectionParametr.Parametr(TextBoxList[1].Text, TextBoxList[1].Name);
                        double deepBox = InspectionParametr.Parametr(TextBoxList[2].Text, TextBoxList[2].Name);
                        VolumeFigure = new Box(height: heightBox, width: widthBox, deep: deepBox);
                        break;
                    }
                case Figures.Sphear:
                    {
                        double radiusSphear = InspectionParametr.Parametr(TextBoxList[0].Text, TextBoxList[0].Name);
                        VolumeFigure = new Sphear(radius: radiusSphear);
                        break;
                    }

                case Figures.Pyramid:
                    {
                        double heightPyramid = InspectionParametr.Parametr(TextBoxList[0].Text, TextBoxList[0].Name);
                        double areaPyramid = InspectionParametr.Parametr(TextBoxList[1].Text, TextBoxList[1].Name);
                        VolumeFigure = new Pyramid(height: heightPyramid, area: areaPyramid);
                        break;
                    }
            }
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
