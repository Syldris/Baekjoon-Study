#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int l = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int n = int.Parse(sr.ReadLine());
        int result = 0;

        for (int i = 1; i <= n; i++)
        {
            for (int j = n; j <= 1000; j++)
            {
                if (i == j) continue;

                bool find = true;
                foreach (var item in arr)
                {
                    if (i <= item && item <= j)
                    {
                        find = false;
                        break;
                    }
                }
                if (find) result++;
                else break;
            }
        }

        sw.Write(result);

    }
}