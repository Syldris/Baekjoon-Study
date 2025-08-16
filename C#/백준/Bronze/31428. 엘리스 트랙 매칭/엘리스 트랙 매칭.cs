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
        string[] line = sr.ReadLine().Split();
        string text = sr.ReadLine();
        int result = 0;
        foreach (var item in line)
        {
            if (item == text)
            {
                result++;
            }
        }
        sw.WriteLine(result);
    }
}
