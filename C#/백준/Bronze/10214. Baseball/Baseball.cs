#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 14);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 14);

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int y = 0, k = 0;
            for (int i = 0; i < 9; i++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                y += line[0];
                k += line[1];
            }

            if (y == k)
                sw.WriteLine("Draw");
            else
                sw.WriteLine(y > k ? "Yonsei" : "Korea");
        }
    }
}