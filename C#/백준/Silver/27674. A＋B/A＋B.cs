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
            string line = sr.ReadLine();
            char[] arr = sr.ReadLine().ToCharArray();
            Array.Sort(arr);
            Array.Reverse(arr);

            long num = long.Parse(new string(arr));
            sw.WriteLine(num / 10 + num % 10);
        }
    }
}