using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolumeFigyre;

namespace View
{
    class CalculateVolumeFigures
    {
        /// <summary>
        /// Объявление итерфейса
        /// </summary>
        private IVolumeFigure _volumeFigure = null;
        /// <summary>
        /// Объявление делегата, расчитывающий объем
        /// </summary>
        private Dictionary<string, Func<BindingList<TextBox>, IVolumeFigure>> _calculateVolume;
        /// <summary>
        /// Объявление делегата, записывающий имеющиеся данные в TextBox
        /// </summary>
        private Dictionary<string, Func<BindingList<TextBox>, IVolumeFigure, int>> _writeTextBox;

        /// <summary>
        /// Конструктор
        /// </summary>
        public CalculateVolumeFigures()
        {
            _calculateVolume =
                new Dictionary<string, Func<BindingList<TextBox>, IVolumeFigure>>
                {
                    { "Box", this.CalculateForBox},
                    { "Sphear", this.CalculateForSphear},
                    { "Pyramid", this.CalculateForPyramid},
                };
            _writeTextBox =
                new Dictionary<string, Func<BindingList<TextBox>, IVolumeFigure, int>>
                {
                    { "Box", this.WriteForBox},
                    { "Sphear", this.WriteForSphear},
                    { "Pyramid", this.WriteForPyramid},
                };
        }
        
        /// <summary>
        /// вызов делегата для расчета данных
        /// </summary>
        /// <param name="nameOperation"></param>
        /// <param name="ss"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public IVolumeFigure CalculateOperaion(string nameOperation, BindingList<TextBox> textBoxList)
        {
            if (!_calculateVolume.ContainsKey(nameOperation))
                throw new ArgumentException(string.Format("Operation {0} is invalid", nameOperation), "op");
            return _calculateVolume[nameOperation](textBoxList);
        }
        /// <summary>
        /// вызов делегата для вывода данных на TextBox
        /// </summary>
        /// <param name="nameOperation"></param>
        /// <param name="ss"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public int WriteOperation(string nameOperation, BindingList<TextBox> textBoxList, IVolumeFigure parametrs)
        {
            if (!_writeTextBox.ContainsKey(nameOperation))
                throw new ArgumentException(string.Format("Operation {0} is invalid", nameOperation), "op");
            return _writeTextBox[nameOperation](textBoxList, parametrs);
        }
        
        /// <summary>
        /// Расчет объема параллепипеда
        /// </summary>
        /// <param name="textBoxList"></param>
        /// <returns></returns>
        private IVolumeFigure CalculateForBox(BindingList<TextBox> textBoxList)
        {
            double heightBox = InspectionParametr.Parametr(textBoxList[0].Text, textBoxList[0].Name);
            double widthBox = InspectionParametr.Parametr(textBoxList[1].Text, textBoxList[1].Name);
            double deepBox = InspectionParametr.Parametr(textBoxList[2].Text, textBoxList[2].Name);
            _volumeFigure = new Box(height: heightBox, width: widthBox, deep: deepBox);
            return _volumeFigure;
        }
        /// <summary>
        /// Расчет объема шара
        /// </summary>
        /// <param name="TextBoxList"></param>
        /// <returns></returns>
        private IVolumeFigure CalculateForSphear(BindingList<TextBox> textoxBList)
        {
            double radiusSphear = InspectionParametr.Parametr(textoxBList[0].Text, textoxBList[0].Name);
            _volumeFigure = new Sphear(radius: radiusSphear);
            return _volumeFigure;
        }
        /// <summary>
        /// Расчет объема пирамиды
        /// </summary>
        /// <param name="textBoxList"></param>
        /// <returns></returns>
        private IVolumeFigure CalculateForPyramid(BindingList<TextBox> textBoxList)
        {
            double areaPyramid = InspectionParametr.Parametr(textBoxList[0].Text, textBoxList[0].Name);
            double heightPyramid = InspectionParametr.Parametr(textBoxList[1].Text, textBoxList[1].Name);
            _volumeFigure = new Pyramid(area: areaPyramid, height: heightPyramid);
            return _volumeFigure;
        }

        /// <summary>
        /// ввод данных в TextBox для параллепипеда
        /// </summary>
        /// <param name="textBoxList"></param>
        /// <returns></returns>
        private int WriteForBox(BindingList<TextBox> textBoxList, IVolumeFigure parametrs)
        {
            textBoxList[0].Text = parametrs.Parametr[0].ToString();
            textBoxList[1].Text = parametrs.Parametr[1].ToString();
            textBoxList[2].Text = parametrs.Parametr[2].ToString();
            return 0;
        }
        /// <summary>
        /// ввод данных в TextBox для шара
        /// </summary>
        /// <param name="textBoxList"></param>
        /// <returns></returns>
        private int WriteForSphear(BindingList<TextBox> textBoxList, IVolumeFigure parametrs)
        {
            textBoxList[0].Text = parametrs.Parametr[0].ToString();
            return 1;
        }
        /// <summary>
        /// ввод данных в TextBox для пирамиды
        /// </summary>
        /// <param name="textBoxList"></param>
        /// <returns></returns>
        private int WriteForPyramid(BindingList<TextBox> textBoxList, IVolumeFigure parametrs)
        {
            textBoxList[0].Text = parametrs.Parametr[0].ToString();
            textBoxList[1].Text = parametrs.Parametr[1].ToString();
            return 2;
        }

    }
}
