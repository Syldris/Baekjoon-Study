#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] line = sr.ReadLine().Split();
        int n = int.Parse(line[0]);
        int k = int.Parse(line[1]);
        int[] arr = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int value = 0;
        int result = -1;

        int max = arr[0];
        for (int i = 1; i < n; i++)
        {
            int item = arr[i];
            int prev = i - 1;
            while (prev >= 0 && item < arr[prev])
            {
                arr[prev + 1] = arr[prev];
                value++;
                if (value == k)
                    result = arr[prev];
                prev--;
            }
            if (prev + 1 != i)
            {
                arr[prev + 1] = item;
                value++;
                if (value == k)
                    result = item;
            }
        }
        sw.Write(result);
    }
}
