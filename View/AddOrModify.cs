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
        public IAddObjectDelegate Delegate { get; set; }
        public AddOrModify(bool ModifyOrCreate, IValumeFigyre ModifyFigure)
        {
            InitializeComponent();
            objectControl1.ReadOnly = ModifyOrCreate;
            objectControl1.Object = ModifyFigure;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Delegate.DidFinish(objectControl1.Object);
            Close();
        }
    }
}
