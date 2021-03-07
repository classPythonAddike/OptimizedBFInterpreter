using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OptimizedBFInterpreter;

namespace BFInterpreter
{
	class Program
	{
		static void Main(string[] args)
		{
			BFReader reader = new BFReader();
			string BFCode = reader.getCode(args[0]);

			//Start the timer
			DateTime start = DateTime.Now;

			try
			{
				Parser parser = new Parser();
				parser.Execute(BFCode); // Execute the code
			}
			catch (Exception e) // Raise errors, if any
			{
				Console.WriteLine("\nError:");
				Console.WriteLine(e.Message);
			}

			DateTime end = DateTime.Now;

			Console.WriteLine($"Time taken: {end.Subtract(start)}"); // Measure the time taken

			Console.Write("\nPress any key to exit . . . .\n");
			Console.ReadKey();
		}

		
	}
}