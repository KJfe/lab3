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
    enum Figures : int
    {
        Box = 0,
        Sphear = 1,
        Pyramid = 2
    };
    public partial class AddObject : Form
    {
        /// <summary>
        /// Деликат на объект фигуру
        /// </summary>
        public IAddObjectDelegate Delegate { get; set; }

        public AddObject()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch((Figures)comboBox1.SelectedIndex)
            {
                case Figures.Box:
                    {
                        labelWidth.Visible = true;
                        Width.Visible = true;
                        labelWidth.Text = "Width";
                        labelHeight.Visible = true;
                        Height.Visible = true;
                        labelDeep.Visible = true;
                        Deep.Visible = true;
                        break;
                    }
                case Figures.Sphear:
                    {
                        labelWidth.Visible = true;
                        Width.Visible = true;
                        labelWidth.Text = "Radius";
                        labelHeight.Visible = false;
                        Height.Visible = false;
                        labelDeep.Visible = false;
                        Deep.Visible = false;
                        break;
                    }
                case Figures.Pyramid:
                    {
                        labelWidth.Visible = true;
                        Width.Visible = true;
                        labelWidth.Text = "Area";
                        labelHeight.Visible = true;
                        Height.Visible = true;
                        labelDeep.Visible = false;
                        Deep.Visible = false;
                        break;
                    }
                default:
                    break;
            }

            lableValume.Visible = true;
            tbValume.Visible = true;
        }

        private void SelectionFigyre()
        {
            IValumeFigyre VolumeFigure=null;
            switch ((Figures)comboBox1.SelectedIndex)
            {           
                case Figures.Box:
                    {
                        double heightBox = InspectionParametr.Parametr(Height.Text, Height.Name);
                        double widthBox = InspectionParametr.Parametr(Width.Text, Width.Name);
                        double deepBox = InspectionParametr.Parametr(Deep.Text, Deep.Name);
                        VolumeFigure = new Box(height: heightBox, width: widthBox, deep: deepBox);
                        break;
                    }
                case Figures.Sphear:
                    {
                        double radiusSphear = InspectionParametr.Parametr(Width.Text, "Radius");
                        VolumeFigure = new Sphear(radius: radiusSphear);
                        break;
                    }
                
                case Figures.Pyramid:
                    {
                        double heightPyramid = InspectionParametr.Parametr(Height.Text, Height.Name);
                        double areaPyramid = InspectionParametr.Parametr(Width.Text, "Area");
                        VolumeFigure = new Pyramid(height: heightPyramid, area: areaPyramid);
                        break;
                    }
            }
            if (VolumeFigure != null)
            {
                tbValume.Text = Convert.ToString(VolumeFigure.Valume);
                Delegate.DidFinish(VolumeFigure);
            }
        }

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
        }
    }
}
 