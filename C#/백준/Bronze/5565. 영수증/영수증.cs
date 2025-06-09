#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int value = int.Parse(sr.ReadLine());
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(sr.ReadLine());
        }
        sw.Write(value - sum);
    }
}