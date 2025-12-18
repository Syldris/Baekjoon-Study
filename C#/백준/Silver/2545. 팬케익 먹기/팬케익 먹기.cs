#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            sr.ReadLine();
            string[] input = sr.ReadLine().Split();
            long a = long.Parse(input[0]);
            long b = long.Parse(input[1]);
            long c = long.Parse(input[2]);
            long d = long.Parse(input[3]);

            if (a < b)  (a, b) = (b, a);
            if (b < c)  (b, c) = (c, b);
            if (a < b)  (a, b) = (b, a);

            long diff = 0;
            diff += a - c;
            diff += b - c;

            if (diff > d)
            {
                long diffab = a - b;
                if (d > diffab)
                {
                    a = b;
                    d -= diffab;
                    long value = a + b - d;
                    a = value / 2;
                    b = value / 2;
                    if (value % 2 == 1)
                    {
                        a++;
                    }
                    sw.WriteLine(a * b * c);
                }
                else
                {
                    a -= d;
                    sw.WriteLine(a * b * c);
                }
            }
            else
            {
                long total = a + b + c - d;
                a = total / 3;
                b = total / 3;
                c = total / 3;

                if (total % 3 > 0)
                {
                    a++;
                }
                if (total % 3 > 1)
                {
                    b++;
                }
                sw.WriteLine(a * b * c);
            }
        }
    }
}