using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValumeFigyre;

namespace View
{
    public partial class AddOrModify : Form
    {
        /// <summary>
        /// объявление делегата
        /// </summary>
        public IAddObjectDelegate Delegate { get; set; }

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
        }

        /// <summary>
        /// Закрытие ормы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, EventArgs e)
        {
            Delegate.DidFinish(objectControlForFigure.ObjectFigur);
            Close();
        }
    }
}
