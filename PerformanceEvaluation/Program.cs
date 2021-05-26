using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

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

                var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

                var words = noPunctuationText.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                textList.AddRange(words);
               
                var selectWords = textList.GroupBy(w => w)
                                          .Select(w => new {wText = w.Key, cRepeat = w.Count()} );

                var SortWords = selectWords.OrderByDescending(s => s.cRepeat);

                var result = SortWords.Take(10);

                foreach ( var word in result)
                {
                    Console.WriteLine("Слово '{0}', количество повторов = {1} ", word.wText, word.cRepeat);
                }
                
                sr.Close();
            }
            
            Console.ReadLine();

        }
    }
}
