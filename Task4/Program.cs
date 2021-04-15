using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using Bogus;
using CsvHelper;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            List<string> locale = new List<string> { "ru_RU", "en_EN", "uk_UA" };
            if ((args.Length==2) &&(int.Parse(args[0])>0)&&(locale.Contains(args[1])))
            {
                var faker = new Faker(args[1].Substring(0, args[1].IndexOf('_')));
                stopwatch.Start();
                GenerateRecords(faker, args);
                stopwatch.Stop();
            }
            Console.WriteLine("Generation time (without output to the terminal): " + stopwatch.Elapsed);
        }

        private static void GenerateRecords(Faker faker, string[] args)
        {
            StreamWriter writer = new StreamWriter(new BufferedStream(new FileStream("f.csv", FileMode.Create)), Encoding.UTF8);
            using (CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.GetCultureInfo("ru_RU")))
            {
                for (int i = 0; i < int.Parse(args[0]); i++)
                {
                    var order = new Order(faker.Name.FullName(), faker.Address.FullAddress(), faker.Phone.PhoneNumber());
                    csvWriter.WriteRecord(order);
                    csvWriter.NextRecord();
                    order.outInf();
                }
            }
        }
    }
}


