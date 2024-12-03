using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Proyect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEstrella_Click(object sender, EventArgs e)
        {
            WidthLineBTN.Enabled = true;
        }

        private void SquardToolsBTN_Click(object sender, EventArgs e)
        {
            WidthLineBTN.Enabled = true;
        }

        private void ElipseToolsBTN_Click(object sender, EventArgs e)
        {
           WidthLineBTN.Enabled = true;
        }

        private void LineToolsBTN_Click(object sender, EventArgs e)
        {
            WidthLineBTN.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void WidthLineBTN_Click(object sender, EventArgs e)
        {
            groupTamanioOpcion.Visible = !groupTamanioOpcion.Visible;
        }
    }
}
