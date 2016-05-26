using System;
using System.IO;
using System.Linq;
using System.Text;

namespace AchieveIT.Answer14
{
    public class Program
    {
        // Reference: https://msdn.microsoft.com/en-us/library/system.io.file.readalllines(v=vs.110).aspx
        private static void Main(string[] args)
        {
            if (args.Count() == 2)
            {
                try
                {
                    // Get filepath.
                    var filePath = args[0];
                    var nthLine = -1;
                    if (!int.TryParse(args[1], out nthLine))
                    {
                        throw new ArgumentException("Invalid Line number provided. Please enter a numeric value.");
                    }

                    var lines = File.ReadAllLines(filePath, Encoding.ASCII).ToList();
                    if (lines.Any() && (nthLine >= 0 && nthLine < lines.Count))
                    {
                        Console.WriteLine($"[Line: #{nthLine}] \"{lines[nthLine]}\"");
                    }
                    else
                    {
                        Console.WriteLine($"No available lines to print at position #{nthLine}.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.ReadLine();
            }
        }
    }
}