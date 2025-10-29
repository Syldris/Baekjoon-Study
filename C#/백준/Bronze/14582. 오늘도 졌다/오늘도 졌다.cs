#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] arr1 = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int[] arr2 = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int value1 = 0;
        int value2 = 0;
        bool reversal = false;

        for (int i = 0; i < arr1.Length; i++)
        {
            value1 += arr1[i];
            if (value1 > value2)
            {
                reversal = true;
                break;
            }
            value2 += arr2[i];
        }

        sw.Write(reversal ? "Yes" : "No");
    }
}