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
		public string GetCode(string arg)
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

				return BFCode;
			}
		}

		public string Shorten(string code)
		{
			return "";
		}
	}
}
