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
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }
        Array.Sort(arr);
        Array.Reverse(arr);
        int count = 0;
        long result = 0;
        
        for (int i = 0; i < n; i++)
        {
            count++;
            if(count == 3)
                count = 0;
            else 
                result += arr[i];
        }
        sw.Write(result);
    }
}
