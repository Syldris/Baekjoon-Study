#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        const int max = 1000001;

        int[] events = new int[max];

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int left = int.Parse(line[0]);
            int right = int.Parse(line[1]);
            events[left]++;
            events[right]--;
        }

        int[] diff = new int[max];
        diff[0] = events[0];
        for (int i = 1; i < max; i++)
        {
            diff[i] = diff[i - 1] + events[i];
        }

        int[] sum = new int[max];
        sum[0] = 0;
        for (int i = 1; i < max; i++)
        {
            sum[i] = sum[i - 1] + diff[i - 1];
        }

        int start = 0, end = 1;
        while (start < max)
        {
            int value = sum[end] - sum[start];
            if (value == k)
            {
                sw.Write($"{start} {end}");
                return;
            }
            if (value < k)
            {
                if (end < max - 1)
                    end++;
                else
                    break;
            }
            else if (value > k)
            {
                start++;
            }

        }
        sw.Write("0 0");
    }
}