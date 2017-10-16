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
        public static List<Registers> registers = new List<Registers>();
        public static List<Memory> memory = new List<Memory>();
        internal void Execute()
        {
            for(int i = 0; i < 10; i++)
            {
                registers.Add(new Registers
                {
                    RegisterNumber = "R" + i,
                    Value = 0
                });
            }
            

            ProcessVars();
            foreach(var row in Form1.commandList)
            {
                switch (row.FunctionCode)
                {
                    case "HIA":
                        ProcessHIA(row);
                        break;
                    case "BIG":
                        ProcessBIG(row);
                        break;
                    case "OPT":
                        ProcessOpt(row);
                        break;
                    case "AFT":
                        ProcessAft(row);
                        break;
                    case "VER":
                        break;
                    case "DEL":
                        break;
                    case "MOD":
                        break;
                    case "LEZ":
                        break;
                    case "DRU":
                        break;
                    case "NWL":
                        break;
                    case "DRS":
                        break;
                    case "VGL":
                        break;
                    case "VSP":
                        break;
                    case "SPR":
                        break;
                    case "STP":
                        break;
                }
            }
            
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
                        throw new NotImplementedException();
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

        
        private void ProcessHIA(Command row)
        {
            int register = row.FirstParam[1];
            
            if(!row.SecondParam.IsNumeric()) //check if rightparameter is a number => variables are not yet supported
                throw new NotImplementedException();

            if (row.InterpretationField.Equals('\0') || row.InterpretationField.Equals('a'))
            {
                //Memory Address
                int value = row.SecondParam.GetMemoryValue(); //Get value of memory address
                registers[register].Value = value;

            }
            else if (row.InterpretationField.Equals('w'))
            {
                //Getal
                registers[register].Value = int.Parse(row.SecondParam);
            }

            else if (row.InterpretationField.Equals('i'))
                throw new NotImplementedException();
            else
            {
                throw new ArgumentException();
            }
        }



        private void ProcessBIG(Command row)
        {
            if (!int.TryParse(row.SecondParam, out int address))
            {
                throw new ArgumentException();
            }

            if(!int.TryParse(row.FirstParam, out int value))
            {
                //register
                value = row.FirstParam.GetRegisterValue();
                if(value == -1)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            int memoryIndex = memory.FindIndex(x => x.MemoryAddress == address);
            if (memoryIndex >= 0) //check if already in memory list
            {
                memory[memoryIndex].Value = int.Parse(row.FirstParam);
            }
            else
            {
                memory.Add(new Memory
                {
                    Value = int.Parse(row.FirstParam),
                    MemoryAddress = int.Parse(row.SecondParam)
                });
            }
        }

        private void ProcessOpt(Command row)
        {
            if (row.InterpretationField.Equals('\0'))
            {
                //adres
                int value = row.SecondParam.GetRegisterValue();
                int registerIndex = registers.FindIndex(x => x.RegisterNumber == row.FirstParam);
                registers[registerIndex].Value += value;
            }
            if (row.InterpretationField.Equals('w'))
            {
                //getal
                int value = int.Parse(row.SecondParam);
                int registerIndex = registers.FindIndex(x => x.RegisterNumber == row.FirstParam);
                registers[registerIndex].Value += value;
            }
        }


        private void ProcessAft(Command row)
        {
            if (row.InterpretationField.Equals('\0'))
            {
                //adres
                int value = row.SecondParam.GetRegisterValue();
                int registerIndex = registers.FindIndex(x => x.RegisterNumber == row.FirstParam);
                registers[registerIndex].Value -= value;
            }
            if (row.InterpretationField.Equals('w'))
            {
                //getal
                int value = int.Parse(row.SecondParam);
                int registerIndex = registers.FindIndex(x => x.RegisterNumber == row.FirstParam);
                registers[registerIndex].Value -= value;
            }
        }


        private void ProcessVer(Command row)
        {
            if (row.InterpretationField.Equals('\0'))
            {
                //adres
                int value = row.SecondParam.GetRegisterValue();
                int registerIndex = registers.FindIndex(x => x.RegisterNumber == row.FirstParam);
                registers[registerIndex].Value *= value;
            }
            if (row.InterpretationField.Equals('w'))
            {
                //getal
                int value = int.Parse(row.SecondParam);
                int registerIndex = registers.FindIndex(x => x.RegisterNumber == row.FirstParam);
                registers[registerIndex].Value *= value;
            }
        }
    }

    public static class DramaTools
    {
        public static int GetRegisterValue (this string input)
        {
            int value = ExecuteCommand.registers[ExecuteCommand.registers.FindIndex(x => x.RegisterNumber == input)].Value;
            return value;
        }

        public static int GetMemoryValue (this string input)
        {
            int value = ExecuteCommand.memory[ExecuteCommand.memory.FindIndex(x => x.MemoryAddress == int.Parse(input))].Value;
            return value;
        }
    }
}
