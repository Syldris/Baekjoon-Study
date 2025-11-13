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
        int u = int.Parse(input[0]);
        int n = int.Parse(input[1]);

        int[] freq = new int[u + 1];
        string[] names = new string[u + 1];

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            string name = line[0];
            int money = int.Parse(line[1]);

            if (names[money] == null)
            {
                names[money] = name;
            }
            freq[money]++;
        }

        int min = int.MaxValue;
        int index = 0;
        for (int i = 1; i <= u; i++)
        {
            if (freq[i] != 0 && freq[i] < min)
            {
                min = freq[i];
                index = i;
            }
        }
        sw.Write($"{names[index]} {index}");
    }
}