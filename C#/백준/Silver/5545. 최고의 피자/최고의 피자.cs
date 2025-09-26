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

        int n = int.Parse(sr.ReadLine());
        string[] input = sr.ReadLine().Split(' ');
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);

        int c = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }
        Array.Sort(arr);
        Array.Reverse(arr);

        int price = a;
        int calori = c;
        int result = calori / price;

        for (int i = 0; i < n; i++)
        {
            price += b;
            calori += arr[i];
            result = Math.Max(result, calori/price);
        }
        sw.Write(result);
    }
}
