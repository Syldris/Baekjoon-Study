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
        for (int i = 0; i < n; i++)
        {
            string[] input = sr.ReadLine().Split(' ');
            long a = long.Parse(input[0]);
            string oper = input[1];
            long b = long.Parse(input[2]);
            long result = long.Parse(input[4]);

            if (oper == "+")
            {
                sw.WriteLine(a + b == result ? "correct" : "wrong answer");
            }
            else if (oper == "-")
            {
                sw.WriteLine(a - b == result ? "correct" : "wrong answer");
            }
            else if (oper == "*")
            {
                sw.WriteLine(a * b == result ? "correct" : "wrong answer");
            }
            else
            {
                sw.WriteLine(a / b == result ? "correct" : "wrong answer");
            }
        }
    }
}