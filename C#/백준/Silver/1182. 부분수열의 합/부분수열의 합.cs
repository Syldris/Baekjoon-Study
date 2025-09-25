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

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int s = int.Parse(input[1]);
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();


        int result = DFS(0, 0);
        if (s == 0)
            result--;
        sw.Write(result);

        int DFS(int index, int value)
        {
            if (index == n)
            {
                if (value == s)
                {
                    return 1;
                }
                return 0;
            }
            return DFS(index + 1, value + arr[index]) + DFS(index + 1, value);
        }
    }
}
