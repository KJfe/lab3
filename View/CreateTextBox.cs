using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    class CreateTextBox:Form
    {
        private Dictionary<string, Func<int,int, BindingList<TextBox>>> _create;
        CreateTextBox()
        {
            _create =
                new Dictionary<string, Func<int, int, BindingList<TextBox>>>
                {
                    { "Box", this.TextBoxForBox},
                };
        }
        private BindingList<TextBox> TEST = new BindingList<TextBox>();
        private BindingList<TextBox> TextBoxForBox(int LocationX,int LocationY)
        {
            TEST.Add(CreatingTextBox("Width", 6, 60));
            TEST.Add(CreatingTextBox("Height", 6, 100));
            TEST.Add(CreatingTextBox("Deep", 6, 140));
            return TEST;
        }
        private TextBox CreatingTextBox(string Name, int LocationX, int LocationY)
        {
            TextBox txb = new TextBox();
            txb.Name = Name;
            txb.Location = new System.Drawing.Point(LocationX, LocationY);
            txb.Size = new System.Drawing.Size(100, 20);
            txb.Visible = true;
            //Controls.Add(txb);
            //groupBox1.Controls.Add(txb);
            return (txb);
        }
    }
}
