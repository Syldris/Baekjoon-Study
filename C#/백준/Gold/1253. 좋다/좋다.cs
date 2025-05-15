using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        Array.Sort(arr);

        int count = 0;
        for (int i = 0; i < n; i++)
        {
            int start = 0, end = n-1;
            while (start < end)
            {
                if(i == start)
                {
                    start++;
                    continue;
                }
                if(i == end)
                {
                    end--;
                    continue;
                }

                if (arr[i] == arr[start] + arr[end])
                {
                    count++;
                    break;
                }
                else if (arr[i] > arr[start] + arr[end])
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }
        }
        sw.Write(count);
    }
}
