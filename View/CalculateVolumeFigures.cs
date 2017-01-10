using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValumeFigyre;

namespace View
{
    class CalculateVolumeFigures
    {
        private IValumeFigyre VolumeFigure = null;
        /// <summary>
        /// Объявление делегата
        /// </summary>
        private Dictionary<string, Func<BindingList<TextBox>, IValumeFigyre>> _calculateVolume;
        private Dictionary<string, Func<BindingList<TextBox>, IValumeFigyre, int>> _writeTextBox;
        public CalculateVolumeFigures()
        {
            _calculateVolume =
                new Dictionary<string, Func<BindingList<TextBox>, IValumeFigyre>>
                {
                    { "Box", this.CalculateForBox},
                    { "Sphear", this.CalculateForSphear},
                    { "Pyramid", this.CalculateForPyramid},
                };
            _writeTextBox =
                new Dictionary<string, Func<BindingList<TextBox>, IValumeFigyre, int>>
                {
                    { "Box", this.WriteForBox},
                    { "Sphear", this.WriteForSphear},
                    { "Pyramid", this.WriteForPyramid},
                };
        }
        /// <summary>
        /// вызов делегата для расчета данных
        /// </summary>
        /// <param name="op"></param>
        /// <param name="ss"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public IValumeFigyre CalculateOperaion(string op, BindingList<TextBox> TextBoxList)
        {
            if (!_calculateVolume.ContainsKey(op))
                throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
            return _calculateVolume[op](TextBoxList);
        }
        /// <summary>
        /// вызов делегата для вывода данных на TextBox
        /// </summary>
        /// <param name="op"></param>
        /// <param name="ss"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public int WriteOperation(string op, BindingList<TextBox> TextBoxList, IValumeFigyre Parametrs)
        {
            if (!_writeTextBox.ContainsKey(op))
                throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
            return _writeTextBox[op](TextBoxList, Parametrs);
        }
        /// <summary>
        /// Расчет объема параллепипеда
        /// </summary>
        /// <param name="TextBoxList"></param>
        /// <returns></returns>
        private IValumeFigyre CalculateForBox(BindingList<TextBox> TextBoxList)
        {
            double heightBox = InspectionParametr.Parametr(TextBoxList[0].Text, TextBoxList[0].Name);
            double widthBox = InspectionParametr.Parametr(TextBoxList[1].Text, TextBoxList[1].Name);
            double deepBox = InspectionParametr.Parametr(TextBoxList[2].Text, TextBoxList[2].Name);
            VolumeFigure = new Box(height: heightBox, width: widthBox, deep: deepBox);
            return VolumeFigure;
        }
        /// <summary>
        /// Расчет объема шара
        /// </summary>
        /// <param name="TextBoxList"></param>
        /// <returns></returns>
        private IValumeFigyre CalculateForSphear(BindingList<TextBox> TextBoxList)
        {
            double radiusSphear = InspectionParametr.Parametr(TextBoxList[0].Text, TextBoxList[0].Name);
            VolumeFigure = new Sphear(radius: radiusSphear);
            return VolumeFigure;
        }
        /// <summary>
        /// Расчет объема пирамиды
        /// </summary>
        /// <param name="TextBoxList"></param>
        /// <returns></returns>
        private IValumeFigyre CalculateForPyramid(BindingList<TextBox> TextBoxList)
        {
            double areaPyramid = InspectionParametr.Parametr(TextBoxList[0].Text, TextBoxList[0].Name);
            double heightPyramid = InspectionParametr.Parametr(TextBoxList[1].Text, TextBoxList[1].Name);
            VolumeFigure = new Pyramid(area: areaPyramid, height: heightPyramid);
            return VolumeFigure;
        }

        /// <summary>
        /// ввод данных в TextBox для параллепипеда
        /// </summary>
        /// <param name="TextBoxList"></param>
        /// <returns></returns>
        private int WriteForBox(BindingList<TextBox> TextBoxList, IValumeFigyre Parametrs)
        {
            TextBoxList[0].Text = Parametrs.Parametr[0].ToString();
            TextBoxList[1].Text = Parametrs.Parametr[1].ToString();
            TextBoxList[2].Text = Parametrs.Parametr[2].ToString();
            return 0;
        }
        /// <summary>
        /// ввод данных в TextBox для шара
        /// </summary>
        /// <param name="TextBoxList"></param>
        /// <returns></returns>
        private int WriteForSphear(BindingList<TextBox> TextBoxList, IValumeFigyre Parametrs)
        {
            TextBoxList[0].Text = Parametrs.Parametr[0].ToString();
            return 1;
        }
        /// <summary>
        /// ввод данных в TextBox для пирамиды
        /// </summary>
        /// <param name="TextBoxList"></param>
        /// <returns></returns>
        private int WriteForPyramid(BindingList<TextBox> TextBoxList, IValumeFigyre Parametrs)
        {
            TextBoxList[0].Text = Parametrs.Parametr[0].ToString();
            TextBoxList[1].Text = Parametrs.Parametr[1].ToString();
            return 2;
        }

    }
}
