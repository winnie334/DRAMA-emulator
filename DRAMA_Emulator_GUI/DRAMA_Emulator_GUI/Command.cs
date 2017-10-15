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
        public string Register { get; set; }
    }
    public class VarStorage
    {
        public string VarName { get; set; }
        public int Target { get; set; }
    }

    public class Registers
    {
        public string RegisterNumber { get; set; }
        public int Value { get; set; }
    }
    public class Memory
    {
        public int MemoryAddress { get; set; }
        public int Value { get; set; }
    }

}
