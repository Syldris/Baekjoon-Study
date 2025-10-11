#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(),int.Parse);

        HashSet<int> hash = new HashSet<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            hash.Add(arr[i]);
        }
        sw.Write(hash.Count);
    }
}