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
        int j = int.Parse(input[0]);
        int n = int.Parse(input[1]);
        int result = 0;

        for (int i = 0; i < n; i++)
        {
            string text = sr.ReadLine();
            int value = 0;
            foreach (var item in text)
            {
                if ('A' <= item && item <= 'Z')
                {
                    value += 4;
                }
                else if (item == ' ')
                {
                    value++;
                }
                else
                {
                    value += 2;
                }
            }
            if (j >= value)
            {
                result++;
            }
        }
        sw.Write(result);
    }
}
