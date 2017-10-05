using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;

namespace DRAMA_Emulator_GUI
{
    
    public partial class Form1 : Form
    {
        public List<string> textLines = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            //Do stuff
            textLines.Clear();
            textLines.Add("");
            ReadTextBox();
        }


        private void ReadTextBox()
        {
            /*textLines.Add(textEditor.Text.Split('\n'));
            foreach(var line in textLines)
            {

            }*/
        }
        
    }
}
