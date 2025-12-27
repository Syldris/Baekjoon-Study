#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(),131072));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int start = 0, end = 1000000000;

        while (start + 1 < end)
        {
            int mid = (start + end) / 2;
            long value = 0;
            for (int i = 0; i < n; i++)
            {
                if (mid >= arr[i])
                {
                    continue;
                }
                value += arr[i] - mid;
                if (value > k)
                {
                    break;
                }
            }

            if (value == k)
            {
                sw.Write(mid);
                return;
            }
            else if (value > k)
            {
                start = mid;
            }
            else
            {
                end = mid;
            }
        }

        sw.Write(start);
    }
}