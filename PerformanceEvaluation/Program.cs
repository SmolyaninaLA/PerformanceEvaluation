using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace PerformanceEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> textList = new List<string>();

            
            string pathText = @"C:\TaskDir\Text1.txt";

            char[] delimiterChars = { ' ', ',', '.', ':', '\r', '\n', '«', '»','?','(',')','!',';','-' };

            using (StreamReader sr = new StreamReader(pathText))
            {
                var text = sr.ReadToEnd();
                var words = text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                var watchList = Stopwatch.StartNew();
                textList.AddRange(words);
                watchList.Stop();

                var wathLinkedlist = Stopwatch.StartNew();
                LinkedList<string> testLinked = new LinkedList<string>(words);
                wathLinkedlist.Stop();

               
                Console.WriteLine("время производительности List: {0}  LinkedList: {1}", watchList.Elapsed.TotalMilliseconds,wathLinkedlist.Elapsed.TotalMilliseconds);

               
                sr.Close();
            }
            
            Console.ReadLine();

        }
    }
}
