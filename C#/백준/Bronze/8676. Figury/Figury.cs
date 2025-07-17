#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        for (int i = 0; i <= n-3 ; i++)
        {
            bool[] bools = new bool[3];
            bools[arr[i]] = true;
            bools[arr[i + 1]] = true;
            bools[arr[i+2]] = true;
            if (bools[0] && bools[1] && bools[2])
            {
                sw.WriteLine("TAK");
                return;
            }
        }
        sw.WriteLine("NIE");
    }
}
