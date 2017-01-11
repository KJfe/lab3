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
        /// <summary>
        /// объявление Подписей к TextBox
        /// </summary>
        private BindingList<Label> LabelList = new BindingList<Label>();
        private BindingList<TextBox> TextBoxList = new BindingList<TextBox>();

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
                if (_VolumeFigure == null|| value.TypeFigyre == "")
                    return;
                Figures fig = (Figures) Enum.Parse(typeof(Figures), value.TypeFigyre);
                cbTypeFigure.SelectedIndex = Convert.ToInt32(fig);
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
            List<ControlCollection> ListContol = new List<ControlCollection>();
            var create = new CreateTextBox();
            ListContol.Add(Controls);
            ListContol.Add(groupBox1.Controls);
            try
            {
                TextBoxList = create.CreatingTextBox(((Figures)cbTypeFigure.SelectedIndex).ToString(), TextBoxList, ListContol);
                LabelList = create.CreateLabel(((Figures)cbTypeFigure.SelectedIndex).ToString(), LabelList, ListContol);
                if (_VolumeFigure!=null)
                {
                    var calculateVolume = new CalculateVolumeFigures();
                    calculateVolume.WriteOperation(_VolumeFigure.TypeFigyre, TextBoxList, _VolumeFigure);
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("system error: 2");
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
            catch (ArgumentException)
            {
                MessageBox.Show("System error: 3");
            }
        }
        /// <summary>
        /// расчет объема фигуры
        /// </summary>
        private void SelectionFigyre()
        {
            IValumeFigyre VolumeFigure = null;
            if (TextBoxList != null)
            {
                var calculateVolume = new CalculateVolumeFigures();
                VolumeFigure = calculateVolume.CalculateOperaion(((Figures)cbTypeFigure.SelectedIndex).ToString(), TextBoxList);
                if (VolumeFigure != null)
                {
                    VolumeFigureText.Text = Convert.ToString(VolumeFigure.Valume);
                    _VolumeFigure = VolumeFigure;
                }
            }
        }
    }
}
