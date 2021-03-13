using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizedBFInterpreter
{
	class Parser
	{
		public static int pointer = 0;
		public static List<int> memory_blocks = new List<int>();

		public void Execute(List<Instruction> code)
		{
			//Initialise the memory blocks
			memory_blocks.Add(0);

			ParseBF(code);
		}

		public void ParseBF(List<Instruction> code)
		{
			int CurrentChar = 0, NumLoops, CharCopy;
			//    Current Command, Stack, Command to start with in case of a loop
			char chr; // Input char for ','
            int code_length = 0;
            Instruction instruct;

            foreach (Instruction i in code)
            {
                code_length += 1;
            }

			while (CurrentChar != code_length)
			{
                instruct = code[CurrentChar];

                if (instruct.command == '+')
				{
					memory_blocks[pointer] += instruct.magnitude;
				}
				else if (instruct.command == '-')
				{
					memory_blocks[pointer] -= instruct.magnitude;
				}
				else if (instruct.command == '>')
				{
					pointer += instruct.magnitude;
				}
				else if (instruct.command == '<')
				{
					pointer -= instruct.magnitude;
				}
				else if (instruct.command == '.')
				{
                    for (int i = 0; i < instruct.magnitude; i++)
                    {
                        Console.Write((char)memory_blocks[pointer]);
                    }
				}
				else if (instruct.command == ',')
				{
                    chr = Console.ReadKey().ToString()[0];
                    memory_blocks[pointer] = (int)chr;
				}
				else if (instruct.command == '[')
				{
					NumLoops = 1;
					CharCopy = CurrentChar + 1;

					while (NumLoops != 0)
					{
						CurrentChar += 1;
						if (code[CurrentChar].command == '[')
						{
							NumLoops += 1;
						}
						else if (code[CurrentChar].command == ']')
						{
							NumLoops -= 1;
						}
					}

					while (memory_blocks[pointer] != 0)
					{
						ParseBF(code.GetRange(CharCopy, CurrentChar - CharCopy));
					}
				}

				CurrentChar += 1;
				while (memory_blocks.Count <= pointer)
				{
					memory_blocks.Add(0);
				}
			}
		}
	}
}
