#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int a = n-1;
        int b = 1;
        bool reverse = false;

        for (int i = 1; i < n * 2; i++)
        {
            string space = new string(' ', a);
            string star = new string('*', b);
            sw.WriteLine(space + star);

            if(i == n)
                reverse = true;

            a = reverse ? a += 1 : a -= 1;
            b = reverse ? b -= 2 : b += 2;
        }
    }
}