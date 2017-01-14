using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ValumeFigyre;

namespace View
{
    /// <summary>
    /// Список Фигур
    /// </summary>
    enum Figures : int
    {
        Box = 0,
        Sphear = 1,
        Pyramid = 2
    };

    public partial class ObjectControl : UserControl
    {
        /// <summary>
        /// Реализация полей
        /// </summary>
        private bool _readOnly;
        private IVolumeFigure _volumeFigure;
        /// <summary>
        /// Реализация UserControl (праметр формы)
        /// </summary>
        public ObjectControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// объявление Подписей к TextBox
        /// </summary>
        private BindingList<Label> labelList = new BindingList<Label>();
        /// <summary>
        /// Объявление подписй к Label
        /// </summary>
        private BindingList<TextBox> textBoxList = new BindingList<TextBox>();

        /// <summary>
        /// Метод принимающий/отправляющий данные
        /// </summary>
        public IVolumeFigure ObjectFigur
        {
            get
            {
                return _volumeFigure;
            }
            set
            {
                _volumeFigure = value;
                if (_volumeFigure == null|| value.TypeFigure == "")
                    return;
                Figures typeFigur = (Figures) Enum.Parse(typeof(Figures), value.TypeFigure);
                cbTypeFigure.SelectedIndex = Convert.ToInt32(typeFigur);
            }
        }
        /// <summary>
        /// Метод разрешающий/запрещающий редактировать параметры
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
            set
            {
                _readOnly = !value;
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
            List<ControlCollection> listContol = new List<ControlCollection>();
            var create = new CreateElementForm();
            listContol.Add(Controls);
            listContol.Add(groupBox1.Controls);
            try
            {
                textBoxList = create.CreatingTextBox(((Figures)cbTypeFigure.SelectedIndex).ToString(), textBoxList, listContol, _readOnly);
                labelList = create.CreateLabel(((Figures)cbTypeFigure.SelectedIndex).ToString(), labelList, listContol);
                if (_volumeFigure!=null)
                {
                    var calculateVolume = new CalculateVolumeFigures();
                    calculateVolume.WriteOperation(_volumeFigure.TypeFigure, textBoxList, _volumeFigure);
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The size of the parameters of the first figure more than necessary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            IVolumeFigure VolumeFigure = null;
            if (textBoxList != null)
            {
                var calculateVolume = new CalculateVolumeFigures();
                VolumeFigure = calculateVolume.CalculateOperaion(((Figures)cbTypeFigure.SelectedIndex).ToString(), textBoxList);
                if (VolumeFigure != null)
                {
                    VolumeFigureText.Text = Convert.ToString(VolumeFigure.Volume);
                    _volumeFigure = VolumeFigure;
                }
            }
        }
    }
}
