#nullable disable
using System;
using System.Numerics;
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
        int[] start = new int[n];

        for (int i = 1; i <= n; i++)
        {
            int num = int.Parse(sr.ReadLine());
            change(num - 1, i, start);
        }

        int[] result = new int[n];

        for (int i = m-1; i >= 0; i--)
        {
            int num = int.Parse(sr.ReadLine());
            change(num - 1, start[i], result);
        }

        for (int i = 0; i < 3; i++)
        {
            sw.WriteLine(result[i]);
        }

        void change(int index, int value, int[] array)
        {
            if (array[index] != 0)
            {
                change(index + 1, array[index], array);
                array[index] = value;
            }
            else
            {
                array[index] = value;
            }
        }
    }
}
