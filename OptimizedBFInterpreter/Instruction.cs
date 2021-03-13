using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizedBFInterpreter
{
	class Instruction
	{
        public char command;
        public int magnitude;

        public Instruction(char cmd, int count)
        {
            command = cmd;
            magnitude = count;
        }
	}
}