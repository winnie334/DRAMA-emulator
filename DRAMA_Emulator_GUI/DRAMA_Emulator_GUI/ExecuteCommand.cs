using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRAMA_Emulator_GUI
{
    class ExecuteCommand
    {

        public List<VarStorage> varStorage = new List<VarStorage>();
        internal void Execute()
        {
            ProcessVars();
            
        }


        private void ProcessVars()
        {
            foreach (var row in Form1.commandList)
            {
                if (!row.Variable.Equals(""))
                {
                    int rowIndex = Form1.commandList.IndexOf(row);
                    string varName = Form1.commandList[rowIndex].Variable;
                    int jumpIndex = Form1.commandList.FindIndex(x => x.LineJump == varName);
                    if (jumpIndex == -1)
                    {
                        //Check
                        //Probably memory 'pointer'
                    }
                    else
                    {
                        varStorage.Add(new VarStorage
                        {
                            VarName = varName,
                            Target = Form1.commandList[jumpIndex].LineNumber
                        });
                    }
                }
            }
        }

        /*
        private void ProcessHIA(string[] s, string l)
        { //klopt niets van

            
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
        }*/
    }
}
