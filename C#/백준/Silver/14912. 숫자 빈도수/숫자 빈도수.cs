#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int d = int.Parse(input[1]);
        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            string s = i.ToString();
            foreach (var item in s)
            {
                if (d == item - '0')
                {
                    result++;
                }
            }
        }
        sw.Write(result);
    }
}
