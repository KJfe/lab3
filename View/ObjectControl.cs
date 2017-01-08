using System;
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
    public partial class ObjectControl : UserControl
    {
        //public IAddObjectDelegate Delegate { get; set; }

        public ObjectControl()
        {
            InitializeComponent();
        }

        private IValumeFigyre _VolumeFigure;
        public IValumeFigyre Object
        {
            get
            {

                return _VolumeFigure;
            }
            set
            {
                _VolumeFigure = value;
                if (_VolumeFigure == null)
                    return;
                if (value.TypeFigyre == "Sphear")
                {
                    
                    Width.Text = value.Parametr[0].ToString();
                    Height.Text = "";
                    Deep.Text = "";
                    Width.Visible = true;
                    Height.Visible = false;
                    Deep.Visible = false;

                }
                else if (value.TypeFigyre == "Parallepiped")
                {
                    
                    Width.Text = value.Parametr[0].ToString();
                    Height.Text = value.Parametr[1].ToString();
                    Deep.Text = value.Parametr[2].ToString();
                    Width.Visible = true;
                    Height.Visible = true;
                    Deep.Visible = true;
                }
                else
                {
                    
                    Width.Text = value.Parametr[0].ToString();
                    Height.Text = value.Parametr[1].ToString();
                    Deep.Text = "";
                    Width.Visible = true;
                    Height.Visible = true;
                    Deep.Visible = false;
                }
            }
        }

        private bool _ReadOnly;
        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                _ReadOnly = value;
                /*if (_ReadOnly == null)
                    return;*/
                Width.Enabled = !value;
                Height.Enabled = !value;
                Deep.Enabled = !value;
            }
        }

        public void cbTypeFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((Figures)cbTypeFigure.SelectedIndex)
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
        }

        private void SelectionFigyre()
        {
            //IValumeFigyre VolumeFigure = null;
            _VolumeFigure = null;
            switch ((Figures)cbTypeFigure.SelectedIndex)
            {
                case Figures.Box:
                    {
                        double heightBox = InspectionParametr.Parametr(Height.Text, Height.Name);
                        double widthBox = InspectionParametr.Parametr(Width.Text, Width.Name);
                        double deepBox = InspectionParametr.Parametr(Deep.Text, Deep.Name);
                        _VolumeFigure = new Box(height: heightBox, width: widthBox, deep: deepBox);
                        break;
                    }
                case Figures.Sphear:
                    {
                        double radiusSphear = InspectionParametr.Parametr(Width.Text, "Radius");
                        _VolumeFigure = new Sphear(radius: radiusSphear);
                        break;
                    }

                case Figures.Pyramid:
                    {
                        double heightPyramid = InspectionParametr.Parametr(Height.Text, Height.Name);
                        double areaPyramid = InspectionParametr.Parametr(Width.Text, "Area");
                        _VolumeFigure = new Pyramid(height: heightPyramid, area: areaPyramid);
                        break;
                    }
            }
            if (_VolumeFigure != null)
            {
                VolumeFigureText.Text = Convert.ToString(_VolumeFigure.Valume);                
                Object=_VolumeFigure;
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
