#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 17);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        (long a, long b, long c, long d)[] arr = new (long a, long b, long c, long d)[n];
        for (int i = 0; i < n; i++)
        {
            long[] line = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            arr[i] = (line[0], line[1], line[2], line[3]);
        }

        int size = n * n;
        long[] ab = new long[size];
        long[] cd = new long[size];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                ab[i * n + j] = arr[i].a + arr[j].b;
                cd[i * n + j] = arr[i].c + arr[j].d;
            }
        }

        Array.Sort(ab);
        Array.Sort(cd);

        int start = 0, end = size - 1;
        long count = 0;

        while (start < size && end >= 0)
        {
            long value = ab[start] + cd[end];
            if (value > 0)
            {
                end--;
            }
            else if (value < 0)
            {
                start++;
            }
            else
            {
                long leftlen = 1;
                long rightlen = 1;

                long startValue = ab[start++];
                long endValue = cd[end--];

                while (start < size && ab[start] == startValue)
                {
                    start++;
                    leftlen++;
                }
                while (end >= 0 && cd[end] == endValue)
                {
                    end--;
                    rightlen++;
                }

                count += leftlen * rightlen;
            }
        }

        sw.Write(count);
    }
}