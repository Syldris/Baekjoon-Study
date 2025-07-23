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
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        bool[] bools = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (i % 10 == 0 || i % 10 == 3 || i % 10 == 6)
            {
                bools[i] = true;
            }
        }
        for (int i = 0; i < m; i++)
        {
            int value = int.Parse(sr.ReadLine());
            --value;
            bools[value] = !bools[value];

            int result = 0;
            foreach (var item in bools)
            {
                if (item)
                    result++;
            }
            sw.WriteLine(result);
        }
    }
}
