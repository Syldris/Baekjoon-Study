#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int index = n * 2;
        string firstspace = new string(' ', n - 1);
        string firststar = new string('*', 1);
        sw.WriteLine(firstspace + firststar);

        for (int i = 1; i < n-1 ; i++)
        {
            string space = new string(' ', n - i - 1);
            string star = new string('*', 1);
            string space2 = new string(' ', i * 2 - 1);
            sw.WriteLine(space + star + space2 + star);
        }

        if (n != 1)
        {
            sw.WriteLine(new string('*', 2 * n - 1));
        }
    }
}