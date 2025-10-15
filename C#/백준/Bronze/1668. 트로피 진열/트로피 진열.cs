#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];

        int left = 0;
        int right = 0;

        int cur = 0;
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
            if (arr[i] > cur)
            {
                cur = arr[i];
                left++;
            }
        }
        cur = 0;
        for (int i = n-1; i >= 0; i--)
        {
            if (arr[i] > cur)
            {
                cur = arr[i];
                right++;
            }
        }
        sw.WriteLine(left);
        sw.WriteLine(right);
    }
}