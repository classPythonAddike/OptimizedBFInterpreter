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

		public void Execute(string code)
		{
			//Initialise the memory blocks
			memory_blocks.Add(0);

			ParseBF(code);
		}

		public void ParseBF(string code)
		{
			int CurrentChar = 0, NumLoops, CharCopy;
			//    Current Command, Stack, Command to start with in case of a loop
			char chr; // Input char for ','

			while (CurrentChar != code.Length)
			{
				if (code[CurrentChar] == '+')
				{
					memory_blocks[pointer] += 1;
				}
				else if (code[CurrentChar] == '-')
				{
					memory_blocks[pointer] -= 1;
				}
				else if (code[CurrentChar] == '>')
				{
					pointer += 1;
				}
				else if (code[CurrentChar] == '<')
				{
					pointer -= 1;
				}
				else if (code[CurrentChar] == '.')
				{
					Console.Write((char)memory_blocks[pointer]);
				}
				else if (code[CurrentChar] == ',')
				{
					chr = Console.ReadKey().ToString().ToCharArray()[0];
					memory_blocks[pointer] = (int)chr;
				}
				else if (code[CurrentChar] == '/')
				{
					CurrentChar++;
					while (code[CurrentChar] != '/')
					{
						CurrentChar++;
					}
				}
				else if (code[CurrentChar] == '[')
				{
					NumLoops = 1;
					CharCopy = CurrentChar + 1;

					while (NumLoops != 0)
					{
						CurrentChar += 1;
						if (code[CurrentChar] == '[')
						{
							NumLoops += 1;
						}
						else if (code[CurrentChar] == ']')
						{
							NumLoops -= 1;
						}
					}

					while (memory_blocks[pointer] != 0)
					{
						ParseBF(code.Substring(CharCopy, CurrentChar - CharCopy));
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
