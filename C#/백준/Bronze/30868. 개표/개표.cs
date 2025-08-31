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
            int value = int.Parse(sr.ReadLine());
            StringBuilder sb = new StringBuilder();
            while (value > 0)
            {
                if (value >= 5)
                {
                    value -= 5;
                    sb.Append("++++ ");
                }
                else
                {
                    value--;
                    sb.Append("|");
                }
            }
            sw.WriteLine(sb);
        }
    }
}
