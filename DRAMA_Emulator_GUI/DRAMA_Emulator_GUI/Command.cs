using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRAMA_Emulator_GUI
{
    public class Command
    {
        public int LineNumber { get; set; }
        public string FunctionCode { get; set; }
        public char InterpretationField { get; set; }
        public string FirstParam { get; set; }
        public string SecondParam { get; set; }
        public string LineJump { get; set; } //kan lijnnummer of variabele zijn, nodig bij VSP/SPR
        public string Variable { get; set; }
    }
}
