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
        int a = int.Parse(input[0]);
        int result = int.Parse(input[1]);

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        Array.Sort(arr);
        foreach (var item in arr)
        {
            if (result >= item)
            {
                result++;
            }
            else
            {
                break;
            }
        }
        sw.Write(result);
    }
}
