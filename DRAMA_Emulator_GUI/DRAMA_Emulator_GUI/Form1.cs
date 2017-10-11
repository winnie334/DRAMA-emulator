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
                    var zooi = ProcessLine(line); //to change variable name

                    CommandList.Add(new Command
                    {
                        LineNumber = i,
                        FunctionCode = zooi.functionCode,
                        
                    });
                }
                i++;
            }
        }

        private (string functionCode, char interpretationField, string leftAccumulator, string rightAccumulator, string lineJump) ProcessLine(string line)
        {
            string functionCode = "";
            char interpretationField = '\0';
            string leftAccumulator = "";
            string rightAccumulator = "";
            string lineJump = "";

            //Seperate 
            if (line.Contains(':'))
            {
                int v = line.IndexOf(':');
                lineJump = line.Substring(0, v++);
                line = line.Substring(v);
            }

            //Seperate accumulators from line
            if (line.Contains(','))
            {
                int v = line.IndexOf(',');
                string leftPart = line.Substring(0, v);
                int leftSpacePosition = leftPart.LastIndexOf(" ");
                leftAccumulator = leftPart.Substring(++leftSpacePosition);
                string rightPart = line.Substring(++v);
                int rightSpacePosition = rightPart.IndexOf(" ");
                rightAccumulator = rightPart.Substring(0, rightSpacePosition);
            }

            char[] charSeperators = new char[] { ' ', '.', ',' };
            string[] splitLine = line.Split(default(Char[]), StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in splitLine)
            {
                Console.WriteLine(element);
                switch (element)
                {
                    case "HIA":
                        functionCode = "HIA";
                        break;
                    case "BIG":
                        functionCode = "BIG";
                        break;
                    case "OPT":
                        functionCode = "OPT";
                        break;
                    case "AFT":
                        functionCode = "AFT";
                        break;
                    case "VER":
                        functionCode = "VER";
                        break;
                    case "DEL":
                        functionCode = "DEL";
                        break;
                    case "MOD":
                        functionCode = "MOD";
                        break;
                    case "LEZ":
                        functionCode = "LEZ";
                        break;
                    case "DRU":
                        functionCode = "DRU";
                        break;
                    case "NWL":
                        functionCode = "NWL";
                        break;
                    case "DRS":
                        functionCode = "DRS";
                        break;
                    case "VGL":
                        functionCode = "VGL";
                        break;
                    case "VSP":
                        functionCode = "VSP";
                        break;
                    case "SPR":
                        functionCode = "SPR";
                        break;
                    case "i":
                        interpretationField = 'i';
                        break;
                    case "w":
                        interpretationField = 'w';
                        break;
                    case "d":
                        interpretationField = 'd';
                        break;
                    case "a":
                        interpretationField = 'a';
                        break;
                    case "":
                        break;
                    default:
                        //throw error
                        break;
                }
            }
            return (functionCode, interpretationField, leftAccumulator, rightAccumulator, lineJump);
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
