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
        int b = int.Parse(input[1]);
        long result = (long)a * a;
        
        string[] input2 = sr.ReadLine().Split();
        int[] arr1 = new int[a];
        int[] arr2 = new int[b + 1];
        for (int i = 0; i < a; i++)
        {
            arr1[i] = int.Parse(input2[i]);
        }
        for (int i = a; i < 2 * a; i++)
        {
            arr2[int.Parse(input2[i])]++;
        }

        foreach (var x in arr1)
        {
            result -= arr2[x];
        }
        sw.Write(result);
    }
}
