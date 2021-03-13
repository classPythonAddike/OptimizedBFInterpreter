using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizedBFInterpreter
{
	class BFReader
	{
		public List<Instruction> GetCode(string arg)
		{
			using (FileStream fs = File.Open(arg, FileMode.Open)) // Open the file, read bytes from it
			{
				string BFCode = "";
				byte[] b = new byte[1024];
				UTF8Encoding decoder = new UTF8Encoding(true);

				while (fs.Read(b, 0, b.Length) > 0)
				{
					BFCode += decoder.GetString(b); // Decode the string, and concatenate it to the code
				}

				return ShortenCode(BFCode);
			}
		}

        public List<Instruction> ShortenCode(string code)
        {
            var ShortCode = new List<Instruction>(); // Shortened Code
            var cmds = new List<char> { '[', ']', ',', '.', '+', '-', '<', '>' }; // Allowed Commands
            char current = code[0]; // The current character
            int count = 1; // The frequency of the current character
            Instruction instruct; // An intermediate instruction to add to the shortened code

            foreach (char i in code.Substring(1))
            {
                if (cmds.Contains(i))
                {
                    if (current == i && i != '[' && i != ']') // [ and ] cannot be condensed
                    {
                        count += 1;
                    }
                    else if (i == '[' || i == ']') // [ and ] become separate instructions
                    {
                        instruct = new Instruction(current, count);
                        ShortCode.Add(instruct);
                        instruct = new Instruction(i, 1);
                        ShortCode.Add(instruct);
                        count = 0;
                        current = i;
                    }
                    else // If the current streak of commands is broken, create a new one!
                    {
                        instruct = new Instruction(current, count);
                        ShortCode.Add(instruct);

                        current = i;
                        count = 1;
                    }
                }
            }

            instruct = new Instruction(current, count);
            ShortCode.Add(instruct);

            return ShortCode;
        }
	}
}
