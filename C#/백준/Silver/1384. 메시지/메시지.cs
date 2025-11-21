#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int group = 0;
        while (true)
        {
            int n = int.Parse(sr.ReadLine());
            if (n == 0)
                break;

            if (group != 0)
                sw.WriteLine();

            string[] name = new string[n];
            List<int>[] list = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = sr.ReadLine().Split();
                name[i] = input[0];
                list[i] = new List<int>();

                for (int j = 1; j < n; j++)
                {
                    if (input[j] == "N")
                    {
                        list[i].Add(n - j);
                    }
                }
            }

            sw.WriteLine($"Group {++group}");
            bool nothing = true;
            for (int i = 0; i < n; i++)
            {
                foreach (var item in list[i])
                {
                    sw.WriteLine($"{name[(item + i) % n]} was nasty about {name[i]}");
                    nothing = false;
                }
            }
            if (nothing)
            {
                sw.WriteLine("Nobody was nasty");
            }
        }
    }
}