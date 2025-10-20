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
        for (int i = n; i >= 4; i--)
        {
            int value = i;

            bool answer = true;

            while (value >= 10)
            {
                if (!(value % 10 == 4 || value % 10 == 7))
                {
                    answer = false;
                    break;
                }
                value /= 10;
            }

            if (!(value % 10 == 4 || value % 10 == 7))
            {
                answer = false;
            }

            if (answer)
            {
                sw.Write(i);
                return;
            }
        }
    }
}