#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        sw.AutoFlush = true;

        int n = int.Parse(sr.ReadLine());

        while (true)
        {
            sw.WriteLine($"? {n}");
            string text = sr.ReadLine();
            if (text == "Y")
            {
                sw.Write($"! {n}");
                return;
            }
        }
    }
}