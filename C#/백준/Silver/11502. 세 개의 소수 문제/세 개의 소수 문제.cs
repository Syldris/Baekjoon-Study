#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        bool[] notPrime = new bool[1001];
        for (int i = 2; i * i <= 1000; i++)
        {
            for (int j = i * i; j <= 1000; j += i)
            {
                if (!notPrime[j])
                {
                    notPrime[j] = true;
                }
            }
        }

        List<int> prime = new List<int>();
        for (int i = 2; i < 1000; i++)
        {
            if (!notPrime[i])
            {
                prime.Add(i);
            }
        }

        for (int testcase = 0; testcase < n; testcase++)
        {
            int value = int.Parse(sr.ReadLine());
            bool find = false;
            for (int a = 0; a < prime.Count; a++)
            {
                if (find) break;
                for (int b = 0; b < prime.Count; b++)
                {
                    if (find) break;
                    for (int c = 0; c < prime.Count; c++)
                    {
                        int num = prime[a] + prime[b] + prime[c];

                        if (num == value)
                        {
                            sw.WriteLine($"{prime[a]} {prime[b]} {prime[c]}");
                            find = true;
                            break;
                        }
                    }
                }
            }

            if (!find)
            {
                sw.WriteLine(0);
            }
        }
    }
}