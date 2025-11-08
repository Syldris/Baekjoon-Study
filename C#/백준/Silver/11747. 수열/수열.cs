#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        HashSet<int> hash = new HashSet<int>();

        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        int index = 0;
        while (true)
        {
            string line = sr.ReadLine();
            if (line == null)
            {
                break;
            }
            string[] text = line.Split();
            foreach (var item in text)
            {
                arr[index++] = int.Parse(item);
            }
        }

        hash.Add(arr[0]);
        if (n >= 2)
        {
            hash.Add(arr[1]);
            hash.Add(arr[0] * 10 + arr[1]);
        }

        for (int i = 2; i < n; i++)
        {
            hash.Add(arr[i]);
            hash.Add(arr[i - 1] * 10 + arr[i]);
            hash.Add(arr[i - 2] * 100 + arr[i - 1] * 10 + arr[i]);
        }

        int result = 0;
        while (true)
        {
            if (!hash.Contains(result))
            {
                break;
            }
            result++;
        }
        sw.Write(result);
    }
}