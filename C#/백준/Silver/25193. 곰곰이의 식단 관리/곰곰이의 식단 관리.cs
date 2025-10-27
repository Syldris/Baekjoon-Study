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
        int value = 0;
        int k = 0;
        foreach (var item in text)
        {
            if (item == 'C')
            {
                value++;
            }
            else
            {
                k++;
            }
        }

        int result = (value / (k + 1));

        if (value % (k + 1) != 0)
        {
            result++;
        }

        sw.Write(result);
    }
}