using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OptimizedBFInterpreter
{
	class Program
	{
		static void Main(string[] args)
		{
            List<Instruction> BFCode;
			BFReader reader = new BFReader();

            //Start the timer
            DateTime start = DateTime.Now;

            try
            {
                BFCode = reader.GetCode(args[0]);
            }
            catch
            {
                BFCode = reader.GetCode("mandelbrot.bf");
            }
            
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