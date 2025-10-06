#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();

        int Reverse(string text) => int.Parse(new string(text.Reverse().ToArray()));

        int a = Reverse(input[0]);
        int b = Reverse(input[1]);

        sw.WriteLine(Reverse((a + b).ToString()));
    }
}