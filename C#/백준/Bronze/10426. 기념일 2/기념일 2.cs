#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] yearDay = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        int[] leapYearDay = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        string[] input = sr.ReadLine().Split();
        int[] date = input[0].Split('-').Select(int.Parse).ToArray();
        int value = int.Parse(input[1]) - 1;

        int year = date[0];
        int month = date[1];
        int day = date[2];
        while (true)
        {
            bool leap = year % 4 == 0 && !(year % 100 == 0) || year % 400 == 0;

            if (leap)
            {
                if (day + value > leapYearDay[month - 1])
                {
                    value -= leapYearDay[month - 1] - day + 1;
                    month++;
                    day = 1;
                }
                else
                    break;
            }
            else
            {
                if (day + value > yearDay[month - 1])
                {
                    value -= yearDay[month - 1] - day + 1;
                    month++;
                    day = 1;
                }
                else
                    break;
            }

            if (month > 12)
            {
                year++;
                month = 1;
            }
        }
        day += value;

        sw.WriteLine($"{year}-{month:D2}-{day:D2}");
    }
}