using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRAMA_Emulator_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            //Do stuff
            ReadTextBox();
        }


        private void ReadTextBox()
        {
            string[] textLines = CodeText.Text.Split('\n');
            foreach(var line in textLines)
            {

            }
        }
    }
}
