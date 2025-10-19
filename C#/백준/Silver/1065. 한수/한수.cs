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
        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            int value = i;

            if (value < 100)
            {
                result++;
                continue;
            }

            List<int> list = new List<int>();

            while (value >= 10)
            {
                list.Add(value % 10);
                value /= 10;
            }
            list.Add(value);

            int k = list[1] - list[0];
            bool plus = true;
            for (int j = 2; j < list.Count; j++)
            {
                if (list[j] != list[j - 1] + k)
                {
                    plus = false;
                    break;
                }

            }
            if (plus)
            {
                result++;
            }
        }
        sw.Write(result);
    }
}