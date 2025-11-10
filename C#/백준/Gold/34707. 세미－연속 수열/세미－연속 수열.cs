#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        
        SortedSet<int> hash = new SortedSet<int>();

        int start = 0; int end = k;

        for (int i = start; i < end; i++)
        {
            hash.Add(arr[i]);
        }

        if (hash.Max - hash.Min + 1 == k)
        {
            sw.WriteLine("YES");
            sw.WriteLine(string.Join(' ', arr[start..end]));
            return;
        }

        while (end != n)
        {
            hash.Remove(arr[start++]);
            hash.Add(arr[end++]);
            if (hash.Max - hash.Min + 1 == k)
            {
                sw.WriteLine("YES");
                sw.WriteLine(string.Join(' ', arr[start..end]));
                return;
            }
        }
        sw.WriteLine("NO");
    }
}