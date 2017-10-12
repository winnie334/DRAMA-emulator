using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                    var processedLine = ProcessLine(line); //to change variable name

                    CommandList.Add(new Command
                    {
                        LineNumber = i,
                        FunctionCode = processedLine.functionCode,
                        InterpretationField = processedLine.interpretationField,
                        FirstParam = processedLine.leftAccumulator,
                        SecondParam = processedLine.rightAccumulator,
                        LineJump = processedLine.lineJump,
                        Variable = processedLine.variable
                        
                    });
                }
                i++;
            }
            ExecuteCommand.Execute(CommandList);
        }

        private (string functionCode, char interpretationField, string leftAccumulator, string rightAccumulator, string lineJump, string variable) ProcessLine(string line)
        {
            string functionCode = "";
            char interpretationField = '\0';
            string leftAccumulator = "";
            string rightAccumulator = "";
            string lineJump = "";
            string variable = "";

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

                int rightPartEnd = 0;
                if(rightPart.Contains(" "))
                    rightPartEnd = rightPart.IndexOf(" ");
                
                else
                    rightPartEnd = rightPart.Length - 1;
                
                
                rightAccumulator = rightPart.Substring(0, rightPartEnd);
                if (!rightAccumulator.IsNumeric())
                {
                    variable = rightAccumulator;
                }

                line = line.Substring(0, leftSpacePosition);
            }

            if (line.Contains('.'))
            {
                int dot = line.IndexOf('.');
                int interpretationFieldLocation = dot + 1;
                interpretationField = line[interpretationFieldLocation];
                line = String.Concat(line.Substring(0, dot), line.Substring(++interpretationFieldLocation));
            }

            char[] charSeperators = new char[] { ' ', '.', ',' };
            string[] splitLine = line.Split(charSeperators, StringSplitOptions.RemoveEmptyEntries);

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
                        lineJump = rightAccumulator;
                        break;
                    case "SPR":
                        functionCode = "SPR";
                        lineJump = rightAccumulator;
                        break;
                    case "STP":
                        functionCode = "STP";
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
            return (functionCode, interpretationField, leftAccumulator, rightAccumulator, lineJump, variable);
        }

        
        private void ProcessBIG(string[] s)
        {

        }
    }

    public static class StringExtensions
    {
        public static bool IsNumeric(this string input)
        {
            int number;
            return int.TryParse(input, out number);
        }
    }
}
