using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolumeFigyre;

namespace View
{
    public partial class AddOrModify : Form
    {
        /// <summary>
        /// Создаем свое событие, что бы передать параметр по нажатию на кнопку Ок
        /// </summary>
        /// <param name="IVolumeFigure"></param>
        public delegate void CalculateVolumeFigure(IVolumeFigure IVolumeFigure);
        public event CalculateVolumeFigure onMakeFigure;
        /// <summary>
        /// инициализация конструктора и входных параметров
        /// </summary>
        /// <param name="ModifyOrCreate"></param>
        /// <param name="ModifyFigure"></param>
        public AddOrModify(bool ModifyOrCreate, IVolumeFigure ModifyFigure)
        {
            InitializeComponent();
            objectControlForFigure.ReadOnly = ModifyOrCreate;
            objectControlForFigure.ObjectFigur = ModifyFigure;
            objectControlForFigure.onCalculateVolume += InPut;
        }
        /// <summary>
        /// метод для передачи параметров фигуры в основное окно
        /// (вызов событи и передача ему параметров)
        /// </summary>
        /// <param name="volumefigure"></param>
        private void InPut(IVolumeFigure volumefigure)
        {
            onMakeFigure(volumefigure);
        }
        /// <summary>
        /// Закрытие ормы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
