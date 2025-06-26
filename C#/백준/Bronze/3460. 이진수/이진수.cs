#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        List<int> list = new List<int>();
        int num = 1;
        while (num <= 1000000)
        {
            list.Add(num);
            num *= 2;
        }


        for (int i = 0; i < n; i++)
        {
            int value = int.Parse(sr.ReadLine());
            List<int> outputs = new List<int>();
            for (int j = list.Count - 1; j >= 0; j--)
            {
                if (value - list[j] >= 0)
                {
                    value -= list[j];
                    outputs.Add(j);
                }
            }
            outputs.Sort();
            sw.WriteLine(String.Join(' ', outputs));
        }
    }
}
