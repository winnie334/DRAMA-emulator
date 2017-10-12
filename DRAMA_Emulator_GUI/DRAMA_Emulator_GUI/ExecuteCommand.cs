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
        internal void Execute(List<Command> CommandList)
        {
            //Check variables
            foreach (var list in CommandList)
            {
                if (!list.Variable.Equals(""))
                {
                    int index = CommandList.IndexOf(list);
                    string varName = CommandList[index].Variable;
                    int jumpIndex = CommandList.FindIndex(x => x.LineJump == varName);
                    if (jumpIndex == -1)
                    {
                        //Check
                    }
                    else
                    {
                        varStorage.Add(new VarStorage
                        {
                            VarName = varName,
                            Target = CommandList[jumpIndex].LineNumber
                        });
                    }
                }
            }
        }


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
        }
    }
}
