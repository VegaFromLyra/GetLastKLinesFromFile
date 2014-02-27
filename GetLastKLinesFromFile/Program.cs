using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GetLastKLinesFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "Input.txt";

            int k = 3;

            PrintLastKLinesFromFile(filename, k);
        }

        static void PrintLastKLinesFromFile(string filename, int k)
        {
            string[] strings = new string[k];

            string line = null;
            int count = 0;
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    strings[count % k] = line;
                    count++;
                }
            }

            // Now strings will have the last 3 lines but
            // not necessarily in order

            // Figure out start and size
            int start = count > k ? count % k : 0;

            int size = Math.Min(k, count);

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("{0}", strings[(start + i) % k]);
            }
        }
    }
}
