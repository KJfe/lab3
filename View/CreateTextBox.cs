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
        /// Объявление делегата, создание TextBox
        /// </summary>
        private Dictionary<string, Func< BindingList<TextBox>, List<ControlCollection>, BindingList<TextBox>>> _createTextBox;
        /// <summary>
        ///Объявление делегата, создание Label
        /// </summary>
        private Dictionary<string, Func<BindingList<Label>, List<ControlCollection>, BindingList<Label>>> _createLabel;

        /// <summary>
        /// Конструктор
        /// </summary>
        public CreateTextBox()
        {
            _createTextBox =
                new Dictionary<string, Func<BindingList<TextBox>, List<ControlCollection>, BindingList<TextBox>>>
                {
                    { "Box", this.TextBoxForBox},
                    { "Sphear", this.TextBoxForSphear},
                    { "Pyramid", this.TextBoxForPyramid},
                };
            _createLabel=
                new Dictionary<string, Func<BindingList<Label>, List<ControlCollection>, BindingList<Label>>>
                {
                    { "Box", this.LabelForBox},
                    { "Sphear", this.LabelForSphear},
                    { "Pyramid", this.LabelForPyramid},
                };
        }

        /// <summary>
        /// вызов делегата для построения TextBox
        /// </summary>
        /// <param name="op"></param>
        /// <param name="ss"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public BindingList<TextBox> CreatingTextBox(string op, BindingList<TextBox> ss, List<ControlCollection> control)
        {
            if (!_createTextBox.ContainsKey(op))
                throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
            return _createTextBox[op](ss, control);
        }
        /// <summary>
        /// вызов делегата для построения label
        /// </summary>
        /// <param name="op"></param>
        /// <param name="ss"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public BindingList<Label> CreateLabel(string op, BindingList<Label> ss, List<ControlCollection> control)
        {
            if (!_createLabel.ContainsKey(op))
                throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
            return _createLabel[op](ss, control);
        }

        /// <summary>
        /// Очистка TextBox
        /// </summary>
        /// <param name="TEST"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<TextBox> ClearBindingListTextBox(BindingList<TextBox> TEST, List<ControlCollection> control)
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
        /// Очистка Label
        /// </summary>
        /// <param name="LabelList"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<Label> ClearBindingListLabel(BindingList<Label> LabelList, List<ControlCollection> control)
        {
            if (LabelList != null)
            {
                foreach (var lable in LabelList)
                {
                    control[0].Remove(lable);
                    lable.Dispose();
                }
                LabelList.Clear();
            }
            return LabelList;
        }

        /// <summary>
        /// Построка TextBox для параллепипеда
        /// </summary>
        /// <param name="TEST"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<TextBox> TextBoxForBox(BindingList<TextBox> TEST, List<ControlCollection> control)
        {
            ClearBindingListTextBox(TEST,control);
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
            ClearBindingListTextBox(TEST, control);
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
            ClearBindingListTextBox(TEST, control);
            TEST.Add(CreatingTextBox("Area", 6, 60, control));
            TEST.Add(CreatingTextBox("Height", 6, 100, control));
            return TEST;
        }

        /// <summary>
        /// Создание Label для Box
        /// </summary>
        /// <param name="LabelList"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<Label> LabelForBox(BindingList<Label> LabelList, List<ControlCollection> control)
        {
            ClearBindingListLabel(LabelList, control);
            LabelList.Add(CreatingLabel("Width", 6, 45, control));
            LabelList.Add(CreatingLabel("Height", 6, 85, control));
            LabelList.Add(CreatingLabel("Deep", 6, 125, control));
            return LabelList;
        }
        /// <summary>
        /// Создание Label для шара
        /// </summary>
        /// <param name="TEST"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<Label> LabelForSphear(BindingList<Label> LabelList, List<ControlCollection> control)
        {
            ClearBindingListLabel(LabelList, control);
            LabelList.Add(CreatingLabel("Radius", 6, 45, control));
            return LabelList;
        }
        /// <summary>
        /// Создание Label для пирамиды
        /// </summary>
        /// <param name="TEST"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<Label> LabelForPyramid(BindingList<Label> LabelList, List<ControlCollection> control)
        {
            ClearBindingListLabel(LabelList, control);
            LabelList.Add(CreatingLabel("Area", 6, 45, control));
            LabelList.Add(CreatingLabel("Height", 6, 85, control));
            return LabelList;
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
        /// <summary>
        /// Создание Label
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="LocationX"></param>
        /// <param name="LocationY"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private Label CreatingLabel(string Name, int LocationX, int LocationY, List<ControlCollection> control)
        {
            Label lab = new Label();
            lab.Name = "Label" + Name;
            lab.Text = Name;
            lab.Location = new System.Drawing.Point(LocationX, LocationY);
            //lab.Visible = true;
            control[0].Add(lab);
            control[1].Add(lab);
            return (lab);
        }
    }
}
