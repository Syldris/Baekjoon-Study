#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        if (n >= 620)
        {
            sw.Write("Red");
        }
        else if (n >= 590 && n <= 620)
        {
            sw.Write("Orange");
        }
        else if (n >= 570 && n <= 590)
        {
            sw.Write("Yellow");
        }
        else if (n >= 495 && n <= 570)
        {
            sw.Write("Green");
        }
        else if (n >= 450 && n <= 495)
        {
            sw.Write("Blue");
        }
        else if (n >= 425 && n <= 450)
        {
            sw.Write("Indigo");
        }
        else
        {
            sw.Write("Violet");
        }
    }
}