#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        bool[] arr = new bool[100];
        int n = int.Parse(sr.ReadLine());
        int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int result = 0;

        foreach (var item in line)
        {
            if (!arr[item-1])
            {
                arr[item-1] = true;
            }
            else
            {
                result++;
            }
        }
        sw.WriteLine(result);

    }
}