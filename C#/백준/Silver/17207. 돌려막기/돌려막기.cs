#nullable disable
using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[,] a = new int[5, 5];
        int[,] b = new int[5, 5];

        for (int y = 0; y < 5; y++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int x = 0; x < 5; x++)
            {
                a[x,y] = line[x];
            }
        }
        for (int y = 0; y < 5; y++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int x = 0; x < 5; x++)
            {
                b[x, y] = line[x];
            }
        }

        int min = int.MaxValue;
        int index = -1;
        for (int x = 0; x < 5; x++)
        {
            int value = 0;
            for (int y = 0; y < 5; y++)
            {
                for (int i = 0; i < 5; i++)
                {
                    value += (a[i, x] * b[y, i]);
                }
            }
            if (value <= min)
            {
                min = value;
                index = x;
            }
        }
        string[] name = new string[] { "Inseo", "Junsuk", "Jungwoo", "Jinwoo", "Youngki" };

        sw.Write(name[index]);
    }
}