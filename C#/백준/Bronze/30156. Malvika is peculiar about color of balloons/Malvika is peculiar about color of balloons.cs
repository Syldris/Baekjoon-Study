#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            int a = 0;
            int b = 0;
            foreach (var item in line)
            {
                if (item == 'a')
                    a++;
                else
                    b++;
            }
            sw.WriteLine(Math.Min(a, b));
        }
    }
}