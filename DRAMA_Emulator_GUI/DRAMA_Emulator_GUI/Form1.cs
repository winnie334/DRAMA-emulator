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
            string[] textLines = textEditor.Text.Split('\n');
            int i = 1;
            foreach (string line in textLines)
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
                        LineNumber = i,

                    });
                }
                i++;
            }
        }

        private (string, char) ProcessLine(string line)
        {
            string FunctionCode = "";
            char InterpretationField = '\0';
            string LeftAccumulator = "";
            string RightAcumulator = "";
            string LineJump = "";

            if (line.Contains(':'))
            {
                int v = line.IndexOf(':');
                LineJump = line.Substring(0, v++);
                line = line.Substring(v);
            }

            char[] charSeperators = new char[] { ' ', '.', ',' };
            string[] splitLine = line.Split(default(Char[]), StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in splitLine)
            {
                Console.WriteLine(element);
                switch (element)
                {
                    case "HIA":
                        FunctionCode = "HIA";
                        break;
                    case "BIG":
                        FunctionCode = "BIG";
                        break;
                    case "OPT":
                        FunctionCode = "OPT";
                        break;
                    case "AFT":
                        FunctionCode = "AFT";
                        break;
                    case "VER":
                        FunctionCode = "VER";
                        break;
                    case "DEL":
                        FunctionCode = "DEL";
                        break;
                    case "MOD":
                        FunctionCode = "MOD";
                        break;
                    case "LEZ":
                        FunctionCode = "LEZ";
                        break;
                    case "DRU":
                        FunctionCode = "DRU";
                        break;
                    case "NWL":
                        FunctionCode = "NWL";
                        break;
                    case "DRS":
                        FunctionCode = "DRS";
                        break;
                    case "VGL":
                        FunctionCode = "VGL";
                        break;
                    case "VSP":
                        FunctionCode = "VSP";
                        break;
                    case "SPR":
                        FunctionCode = "SPR";
                        break;
                    case "i":
                        InterpretationField = 'i';
                        break;
                    case "w":
                        InterpretationField = 'w';
                        break;
                    case "d":
                        InterpretationField = 'd';
                        break;
                    case "a":
                        InterpretationField = 'a';
                        break;
                    case "":
                        break;
                    default:
                        //throw error
                        break;
                }
            }
            return (FunctionCode, InterpretationField);
        }

        private void ProcessHIA(string[] s, string l)
        {
            if (l.Contains("."))
            {
                int i = l.IndexOf(".");
                char InterpretationField = l[9];
                switch (InterpretationField)
                {
                    case 'w':
                        break;
                    case 'a':
                        break;
                    case 'd':
                        break;
                    case 'i':
                        break;
                    default:
                        //throw error
                        break;
                }
            }
            foreach (string element in s)
            {
                switch (element)
                {
                    case "":
                        break;
                }
            }
        }
        private void ProcessBIG(string[] s)
        {

        }
    }
}
