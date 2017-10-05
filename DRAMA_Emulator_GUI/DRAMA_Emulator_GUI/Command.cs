using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRAMA_Emulator_GUI
{
    public class Command
    {
        public int LijnNummer { get; set; }
        public string FunctieCode { get; set; }
        public string LinkerDoel { get; set; }
        public string RechterDoel { get; set; }
        public string SprongLijn { get; set; } //kan lijnnummer of variabele zijn, nodig bij VSP/SPR
        public string Variabele { get; set; }
    }
}
