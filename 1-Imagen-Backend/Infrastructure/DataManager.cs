using System;
using System.Collections.Generic;
using System.IO;

namespace Ms_istio.Infrastructure
{
    public static class DataManager
    {

        const string fileName = @"./data/data.txt";

        public static void SaveData(TimeDto time)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{time.Date.Ticks},{time.Number}");
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        public static List<TimeDto> GetData()
        {

            string line;
            List<TimeDto> timeList = new List<TimeDto>();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                timeList.Add(new TimeDto{
                    Date = new DateTime(long.Parse(words[0])), 
                    Number = Int32.Parse(words[1])
                    });
            }

            file.Close();
            return timeList;
        }

    }
}
