#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        double value = 0;
        int sum = 0;
        for (int i = 0; i < 20; i++)
        {
            string[] line = sr.ReadLine().Split();

            double a = double.Parse(line[1]);
            string rank = line[2];

            double rating = rank switch
            {
                "A+" => 4.5,
                "A0" => 4.0,
                "B+" => 3.5,
                "B0" => 3.0,
                "C+" => 2.5,
                "C0" => 2.0,
                "D+" => 1.5,
                "D0" => 1.0,
                _ => 0.0,
            };

            value += a * rating;
            if (rank != "P")
                sum += (int)a;
        }
        sw.Write(value / sum);
    }
}