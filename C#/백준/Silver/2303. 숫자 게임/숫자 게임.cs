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
        int index = 0;
        int max = 0;
        for (int t = 1; t <= n; t++)
        {
            int[] line = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int start = 0; start < 5; start++)
            {
                for (int mid = start+1; mid < 5; mid++)
                {
                    for (int end = mid+1; end < 5; end++)
                    {
                        int value = (line[start] + line[mid] + line[end]) % 10;
                        if (value >= max)
                        {
                            max = value;
                            index = t;
                        }
                    }
                }
            }
        }
        sw.Write(index);
    }
}