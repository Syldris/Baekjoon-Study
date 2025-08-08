#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[10001];

        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(sr.ReadLine());
            arr[num]++;
        }

        int[] result = arr.Select((value, index) => (value, index)).Where(x => x.value == arr.Max()).Select(x=>x.index).ToArray();
        sw.Write(result[0]);
    }
}
