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
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        Array.Sort(arr);
        long result = 0;
        for (int i = 0; i < n; i++)
        {
            int cur = arr[i];
            int start = i+1, end = n-1;
            while (start < end)
            {
                int value = arr[start] + arr[end] + cur;
                if (value == 0)
                {
                    if (arr[start] == arr[end])
                    {
                        long count = end - start + 1;
                        result += count * (count - 1) / 2;
                        break;
                    }
                    int left = 1;
                    int right = 1;  
                    while (start + 1 < end && arr[start] == arr[start + 1])
                    {
                        left++;
                        start++;
                    }
                    while (end - 1 > start && arr[end] == arr[end - 1])
                    {
                        right++;
                        end--;
                    }
                    result += (long) left * right;
                    start++;
                    end--;
                }
                else if (value < 0)
                {
                    start++;
                }
                else 
                {
                    end--;
                }
            }
        }

        sw.Write(result);
    }
}
