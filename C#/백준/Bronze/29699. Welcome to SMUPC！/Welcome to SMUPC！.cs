#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = "WelcomeToSMUPC";
        int n = int.Parse(sr.ReadLine());

        n--;
        sw.Write(text[n%14]);

    }
}