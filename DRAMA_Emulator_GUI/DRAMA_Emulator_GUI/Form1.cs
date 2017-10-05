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
        public List<Command> CommandList = new List<Command>();
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
            int i = 1;
            foreach(string line in textLines)
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Lijn is leeg");
                    
                }
                else
                {
                    Console.WriteLine("niet leeg");
                    //verwerkfunctie
                    CommandList.Add(new Command
                    {
                        LijnNummer = i,
                        

                    });
                }
                i++;
            }
        }

        private void VerwerkLijn(string lijn)
        {
            char[] charSeperators = new char[] { ' ', '.', ',' };
            string[] s = lijn.Split(default(Char[]), StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in s)
            {
                Console.WriteLine(element);
                switch (element)
                {
                    case "HIA":
                        break;
                    case "BIG":
                        break;
                    case "":
                        break;
                }
            }
        }
    }
}
