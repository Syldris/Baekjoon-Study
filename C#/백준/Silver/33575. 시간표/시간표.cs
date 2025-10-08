#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0];
        int m = input[1];
        int a = input[2];
        int b = input[3];

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] input2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] input3 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        HashSet<int> good = new HashSet<int>();
        HashSet<int> bad = new HashSet<int>();
        for (int i = 0; i < a; i++)
        {
            good.Add(input2[i]);
        }
        for (int i = 0; i < b; i++)
        {
            bad.Add(input3[i]);
        }

        int result = 0;
        int plus = 0;
        int minus = 0;
        for(int i = 0; i < n; i++)
        {
            if (good.Contains(arr[i]))
            {
                if (minus >= 3)
                {
                    result -= minus;
                }
                minus = 0;
                plus++;
            }
            else if (bad.Contains(arr[i]))
            {
                if (plus >= 3)
                {
                    result += plus;
                }
                plus = 0;
                minus++;
            }
            else
            {
                if (plus >= 3)
                {
                    result += plus;
                }
                if (minus >= 3)
                {
                    result -= minus;
                }
                plus = 0;
                minus = 0;
            }
        }
        if (plus >= 3)
        {
            result += plus;
        }
        if (minus >= 3)
        {
            result -= minus;
        }
        sw.Write(result);
    }
}