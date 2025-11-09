#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int n = int.Parse(sr.ReadLine());
        int result = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == n)
            {
                result = i + 1;
                break;
            }
        }


        switch (result)
        {
            case int x when x >= 1 && x <= 5:
                sw.Write("A+");
                break;
            case int x when x >= 6 && x <= 15:
                sw.Write("A0");
                break;
            case int x when x >= 16 && x <= 30:
                sw.Write("B+");
                break;
            case int x when x >= 31 && x <= 35:
                sw.Write("B0");
                break;
            case int x when x >= 36 && x <= 45:
                sw.Write("C+");
                break;
            case int x when x >= 46 && x <= 48:
                sw.Write("C0");
                break;
            case int x when x >= 49 && x <= 50:
                sw.Write("F");
                break;
        }
    }
}