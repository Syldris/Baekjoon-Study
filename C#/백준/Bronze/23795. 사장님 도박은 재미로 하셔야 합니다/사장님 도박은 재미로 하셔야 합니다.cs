#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int sum = 0;
        while (true)
        {
            int n = int.Parse(sr.ReadLine());
            if (n == - 1)
                break;
            sum += n;
        }
        sw.Write(sum);
    }
}