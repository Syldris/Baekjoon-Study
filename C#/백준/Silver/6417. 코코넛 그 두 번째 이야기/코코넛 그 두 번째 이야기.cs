#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            int n = int.Parse(sr.ReadLine());

            if (n == -1)
            {
                return;
            }

            bool solution = false;

            for (int i = 500; i > 1; i--)
            {
                int count = 0;
                int cur = n;

                for (int j = 0; j < i; j++)
                {
                    --cur;
                    if (cur % i != 0)
                    {
                        break;
                    }
                    cur = cur - cur / i;
                    count++;
                }
                if (count == i)
                {
                    sw.WriteLine($"{n} coconuts, {i} people and 1 monkey");
                    solution = true;
                    break;
                }
            }
            if (!solution)
            {
                sw.WriteLine($"{n} coconuts, no solution");
            }
        }
    }
}