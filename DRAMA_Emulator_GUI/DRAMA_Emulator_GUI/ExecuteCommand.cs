using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRAMA_Emulator_GUI
{
    class ExecuteCommand
    {
        internal static void Execute(List<Command> CommandList)
        {
            //Check variables

           foreach(var list in CommandList)
            {
                if (!list.Variable.Equals(""))
                {
                    ProcessVars(CommandList.IndexOf(list));
                }
            }
        }


        private static void ProcessVars(int index)
        {
            //lijst voor variabelen
            
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



    }
}
