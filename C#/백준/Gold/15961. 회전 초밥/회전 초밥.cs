#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int d = int.Parse(input[1]);
        int k = int.Parse(input[2]);
        int c = int.Parse(input[3]);

        int[] arr = new int[n];
        int[] record = new int[d + 1];

        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }

        int result = 0;

        for (int i = 0; i < k; i++)
        {
            int value = arr[i];
            if (record[value] == 0)
            {
                result++;
            }
            record[value]++;
        }

        bool plus = false;

        if (record[c] == 0)
        {
            plus = true;
            result++;
        }

        int start = 0, end = k;
        int count = result;

        while (start != n)
        {
            int v1 = arr[start++];
            int v2 = arr[end++ % n];

            if (record[v1]-- == 1)
            {
                count--;
            }
            if (record[v2]++ == 0)
            {
                count++;
            }

            if (record[c] == 0 && !plus)
            {
                plus = true;
                count++;
            }
            else if (record[c] == 1 && plus)
            {
                plus = false;
                count--;
            }

            result = Math.Max(result, count);
        }

        sw.Write(result);
    }
}