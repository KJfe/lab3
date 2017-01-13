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
    public class CreateElementForm
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
        public CreateElementForm()
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
        public BindingList<TextBox> CreatingTextBox(string nameOperation, BindingList<TextBox> textBoxList, List<ControlCollection> control)
        {
            if (!_createTextBox.ContainsKey(nameOperation))
                throw new ArgumentException(string.Format("Operation {0} is invalid", nameOperation), "op");
            return _createTextBox[nameOperation](textBoxList, control);
        }
        /// <summary>
        /// вызов делегата для построения label
        /// </summary>
        /// <param name="op"></param>
        /// <param name="ss"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public BindingList<Label> CreateLabel(string nameOperation, BindingList<Label> labelList, List<ControlCollection> control)
        {
            if (!_createLabel.ContainsKey(nameOperation))
                throw new ArgumentException(string.Format("Operation {0} is invalid", nameOperation), "op");
            return _createLabel[nameOperation](labelList, control);
        }

        /// <summary>
        /// Очистка TextBox
        /// </summary>
        /// <param name="TEST"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<TextBox> ClearBindingListTextBox(BindingList<TextBox> textBoxList, List<ControlCollection> control)
        {
            if (textBoxList != null)
            {
                foreach (var t in textBoxList)
                {
                    control[0].Remove(t);
                    t.Dispose();
                }
                textBoxList.Clear();
            }
            return textBoxList;

        }
        /// <summary>
        /// Очистка Label
        /// </summary>
        /// <param name="labelList"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<Label> ClearBindingListLabel(BindingList<Label> labelList, List<ControlCollection> control)
        {
            if (labelList != null)
            {
                foreach (var lable in labelList)
                {
                    control[0].Remove(lable);
                    lable.Dispose();
                }
                labelList.Clear();
            }
            return labelList;
        }

        /// <summary>
        /// Построка TextBox для параллепипеда
        /// </summary>
        /// <param name="TextBoxList"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<TextBox> TextBoxForBox(BindingList<TextBox> textBoxList, List<ControlCollection> control)
        {
            ClearBindingListTextBox(textBoxList, control);
            textBoxList.Add(CreatingTextBox("Width", 6, 60, control));
            textBoxList.Add(CreatingTextBox("Height", 6, 100, control));
            textBoxList.Add(CreatingTextBox("Deep", 6, 140, control));
            return textBoxList;
        }
        /// <summary>
        /// Построка TextBox для шара
        /// </summary>
        /// <param name="textBoxList"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<TextBox> TextBoxForSphear(BindingList<TextBox> textBoxList, List<ControlCollection> control)
        {
            ClearBindingListTextBox(textBoxList, control);
            textBoxList.Add(CreatingTextBox("Radius", 6, 60, control));
            return textBoxList;
        }
        /// <summary>
        /// Построка TextBox для пирамиды
        /// </summary>
        /// <param name="textBoxList"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<TextBox> TextBoxForPyramid(BindingList<TextBox> textBoxList, List<ControlCollection> control)
        {
            ClearBindingListTextBox(textBoxList, control);
            textBoxList.Add(CreatingTextBox("Area", 6, 60, control));
            textBoxList.Add(CreatingTextBox("Height", 6, 100, control));
            return textBoxList;
        }

        /// <summary>
        /// Создание Label для Box
        /// </summary>
        /// <param name="labelList"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<Label> LabelForBox(BindingList<Label> labelList, List<ControlCollection> control)
        {
            ClearBindingListLabel(labelList, control);
            labelList.Add(CreatingLabel("Width", 6, 45, control));
            labelList.Add(CreatingLabel("Height", 6, 85, control));
            labelList.Add(CreatingLabel("Deep", 6, 125, control));
            return labelList;
        }
        /// <summary>
        /// Создание Label для шара
        /// </summary>
        /// <param name="TEST"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<Label> LabelForSphear(BindingList<Label> labelList, List<ControlCollection> control)
        {
            ClearBindingListLabel(labelList, control);
            labelList.Add(CreatingLabel("Radius", 6, 45, control));
            return labelList;
        }
        /// <summary>
        /// Создание Label для пирамиды
        /// </summary>
        /// <param name="TEST"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BindingList<Label> LabelForPyramid(BindingList<Label> labelList, List<ControlCollection> control)
        {
            ClearBindingListLabel(labelList, control);
            labelList.Add(CreatingLabel("Area", 6, 45, control));
            labelList.Add(CreatingLabel("Height", 6, 85, control));
            return labelList;
        }
        
        /// <summary>
        /// Создание TextBox
        /// </summary>
        /// <param name="name"></param>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private TextBox CreatingTextBox(string name, int locationX, int locationY, List<ControlCollection> control)
        {
            TextBox textBox = new TextBox();
            textBox.Name = name;
            textBox.Location = new System.Drawing.Point(locationX, locationY);
            textBox.Size = new System.Drawing.Size(100, 20);
            textBox.Visible = true;
            //не обязательно передавать в обычнх контрол можно сразу передедать через groupBox
            //control[0].Add(textBox);
            control[1].Add(textBox);
            return (textBox);
        }
        /// <summary>
        /// Создание Label
        /// </summary>
        /// <param name="name"></param>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private Label CreatingLabel(string name, int locationX, int locationY, List<ControlCollection> control)
        {
            Label label = new Label();
            label.Name = "Label" + name;
            label.Text = name;
            label.Location = new System.Drawing.Point(locationX, locationY);
            //не обязательно передавать в обычнх контрол можно сразу передедать через groupBox
            //control[0].Add(label);
            control[1].Add(label);
            return (label);
        }
    }
}
