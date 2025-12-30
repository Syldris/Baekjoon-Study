#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput());
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

        sw.AutoFlush = true;
        int n = int.Parse(sr.ReadLine());
        string[] name = new string[n];

        for (int i = 0; i < n; i++)
        {
            name[i] = sr.ReadLine();
        }

        for (int i = 0; i < n; i++)
        {
            sw.WriteLine($"? {name[i]}");
            int a = int.Parse(sr.ReadLine());

            sw.WriteLine($"? {name[i]}");
            int b = int.Parse(sr.ReadLine());

            if (a != b)
            {
                sw.WriteLine($"! {name[i]}");
                return;
            }
        }
    }
}