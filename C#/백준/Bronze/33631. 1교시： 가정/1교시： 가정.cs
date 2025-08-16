#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] ingred = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int[] waste = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int query = int.Parse(sr.ReadLine());
        int value = 0;
        for (int i = 0; i < query; i++)
        {
            string[] line = sr.ReadLine().Split();
            int v = int.Parse(line[0]) - 1;
            int k = int.Parse(line[1]);
            if (v == 0)
            {
                bool cook = true;
                for (int j = 0; j < 4; j++)
                {
                    if (ingred[j] < waste[j] * k)
                    {
                        cook = false;
                        break;
                    }
                }
                if (cook)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        ingred[j] -= waste[j] * k;
                    }
                    value += k;
                    sw.WriteLine(value);
                }
                else
                    sw.WriteLine("Hello, siumii");
            }
            else
            {
                ingred[v-1] += k;
                sw.WriteLine(ingred[v-1]);
            }
        }
    }
}
