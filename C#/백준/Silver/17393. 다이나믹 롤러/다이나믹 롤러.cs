#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        long[] arrA = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
        long[] arrB = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

        int[] result = new int[n];

        for (int i = 0; i < n - 1; i++)
        {
            long target = arrA[i];

            int start = i;
            int end = n - 1;

            while (start < end)
            {
                int mid = (start + end) / 2;

                if (target >= arrB[mid + 1])
                    start = mid + 1;
                else
                    end = mid;

            }
            result[i] = start - i;
        }

        sw.Write(String.Join(' ', result));

    }
}