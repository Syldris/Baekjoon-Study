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
        string text = sr.ReadLine();
        int result = 0;
        foreach (var item in text)
        {
            if (item == 'O')
            {
                result++;
            }
        }
        sw.WriteLine(result >= n / 2 + n % 2 ? "Yes" : "No");
    }
}