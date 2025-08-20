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
        string[] arr = new string[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = sr.ReadLine();
        }
        int k = int.Parse(sr.ReadLine());
        if (k == 1)
        {
            foreach (var item in arr)
            {
                sw.WriteLine(item);
            }
        }
        if (k == 2)
        {
            foreach (var item in arr)
            {
                string str = new string(item.Reverse().ToArray());
                sw.WriteLine(str);
            }
        }
        if (k == 3)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                sw.WriteLine(arr[i]);
            }
        }
    }
}
