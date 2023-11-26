using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    internal class FindText
    {
        public void findTextFromFile(string filePath, string extension, string text)
        {
         
            var dirs = Directory.EnumerateDirectories(filePath);
            string[] files = Directory.GetFiles(filePath, extension);

            foreach (var dir in dirs)
            {
                findTextFromFile(dir, extension, text);
                foreach (var file in files)
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while (!sr.EndOfStream)
                        {
                            string? value = sr.ReadLine();
                            if (value.Contains(text))
                            {
                                Console.WriteLine(file);
                                Console.WriteLine(value);
                                Console.WriteLine();
                            }
                        }
                    }
                }

            }


        }
    }
}
