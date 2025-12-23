#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string[] input = sr.ReadLine().Split();
        int result = 0;
        (int start, int end) = (int.Parse(input[0]), int.Parse(input[1]));

        for (int i = 1; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            if (a > end)
            {
                result += Math.Abs(end - start);
                (start, end) = (a, b);
            }
            else if (b > end)
            {
                end = b;
            }
        }
        result += Math.Abs(end - start);
        sw.Write(result);
    }
}