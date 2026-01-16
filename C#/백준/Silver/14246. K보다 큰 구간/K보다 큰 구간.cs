#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int k = int.Parse(sr.ReadLine());

        long result = 0;

        int start = 0, end = 1;
        int value = arr[0];

        while (end <= n)
        {
            if (value > k)
            {
                result += n - end + 1;

                value -= arr[start];
                start++;
                if (start > end)
                {
                    if (n == end) break;
                    value += arr[end];
                    end++;
                }
            }
            else
            {
                if (n == end) break;
                value += arr[end];
                end++;
            }
        }

        sw.Write(result);
    }
}