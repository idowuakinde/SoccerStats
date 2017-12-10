using System;
using System.Collections.Generic;
using System.IO;

namespace SoccerStats
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);

            var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            var file = new FileInfo(fileName);

            if (file.Exists)
            {
                var fileRows = ReadSoccerResults(fileName);
                foreach (var row in fileRows)
                {
                    Console.WriteLine("The name of the Soccer Club is: " + row[1]);
                }

                //var fileContents = ReadFile(fileName);
                //string[] fileLines = fileContents.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                //foreach (var line in fileLines)
                //{
                //    Console.WriteLine(line);
                //}
            }
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<string[]> ReadSoccerResults(string fileName)
        {
            var soccerResults = new List<string[]>();

            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    soccerResults.Add(values);
                }

                //while (reader.Peek() > -1)
                //{
                //    string soccerResultRow = reader.ReadLine();
                //    soccerResults.Add(soccerResultRow);
                //}

                ////var fileRows = ReadFile(fileName).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                ////foreach (var soccerResultRow in fileRows)
                ////{
                ////    soccerResults.Add(soccerResultRow);
                ////}
            }

            return soccerResults;
        }
    }
}
