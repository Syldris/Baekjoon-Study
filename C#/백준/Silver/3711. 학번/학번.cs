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
            int n = int.Parse(sr.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sr.ReadLine());
            }

            int result = -1;
            for (int i = 1; i <= 1000000; i++)
            {
                HashSet<int> hash = new HashSet<int>();
                bool loop = false;
                foreach (var item in arr)
                {
                    int value = item % i;
                    if (hash.Contains(value))
                    {
                        loop = true;
                        break;
                    }
                    hash.Add(value);
                }
                if (!loop)
                {
                    result = i;
                    break;
                }
            }
            sw.WriteLine(result);
        }
    }
}