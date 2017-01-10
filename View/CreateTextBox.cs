using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace View
{
    public class CreateTextBox
    {
        /// <summary>
        /// Объявление делегата
        /// </summary>
        private Dictionary<string, Func< BindingList<TextBox>, List<ControlCollection>, BindingList<TextBox>>> _create;
        public CreateTextBox()
        {
            _create =
                new Dictionary<string, Func<BindingList<TextBox>, List<ControlCollection>, BindingList<TextBox>>>
                {
                    { "Box", this.TextBoxForBox},
                    { "Sphear", this.TextBoxForSphear},
                    { "Pyramid", this.TextBoxForPyramid},
                };
        }
        /// <summary>
        /// вызов делегата
        /// </summary>
        /// <param name="op"></param>
        /// <param name="ss"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public BindingList<TextBox> PerformOperation(string op, BindingList<TextBox> ss, List<ControlCollection> control)
        {
            if (!_create.ContainsKey(op))
                throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
            return _create[op](ss, control);
        }
        /// <summary>
        /// Очистка формы перед созданием TextBox
        /// </summary>
        /// <param name="TEST"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<TextBox> ClearBindingList(BindingList<TextBox> TEST, List<ControlCollection> control)
        {
            if (TEST != null)
            {
                foreach (var t in TEST)
                {
                    control[0].Remove(t);
                    t.Dispose();
                }
                TEST.Clear();
            }
            return TEST;

        }
        /// <summary>
        /// Построка TextBox для параллепипеда
        /// </summary>
        /// <param name="TEST"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<TextBox> TextBoxForBox(BindingList<TextBox> TEST, List<ControlCollection> control)
        {
            ClearBindingList(TEST,control);
            TEST.Add(CreatingTextBox("Width", 6, 60, control));
            TEST.Add(CreatingTextBox("Height", 6, 100, control));
            TEST.Add(CreatingTextBox("Deep", 6, 140, control));
            return TEST;
        }
        /// <summary>
        /// Построка TextBox для шара
        /// </summary>
        /// <param name="TEST"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<TextBox> TextBoxForSphear(BindingList<TextBox> TEST, List<ControlCollection> control)
        {
            ClearBindingList(TEST, control);
            TEST.Add(CreatingTextBox("Radius", 6, 60, control));
            return TEST;
        }
        /// <summary>
        /// Построка TextBox для пирамиды
        /// </summary>
        /// <param name="TEST"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<TextBox> TextBoxForPyramid(BindingList<TextBox> TEST, List<ControlCollection> control)
        {
            ClearBindingList(TEST, control);
            TEST.Add(CreatingTextBox("Area", 6, 60, control));
            TEST.Add(CreatingTextBox("Height", 6, 100, control));
            return TEST;
        }
        /// <summary>
        /// Создание TextBox
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="LocationX"></param>
        /// <param name="LocationY"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private TextBox CreatingTextBox(string Name, int LocationX, int LocationY, List<ControlCollection> control)
        {
            TextBox txb = new TextBox();
            txb.Name = Name;
            txb.Location = new System.Drawing.Point(LocationX, LocationY);
            txb.Size = new System.Drawing.Size(100, 20);
            txb.Visible = true;
            control[0].Add(txb);
            control[1].Add(txb);
            return (txb);
        }
    }
}
