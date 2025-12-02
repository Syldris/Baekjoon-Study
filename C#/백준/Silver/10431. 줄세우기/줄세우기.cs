#nullable disable
using System.Runtime.ConstrainedExecution;
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());

        for (int t = 0; t < testcase; t++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int value = 0;

            for (int i = 1; i < line.Length; i++)
            {
                for (int j = i + 1; j < line.Length; j++)
                {
                    if (line[i] > line[j])
                    {
                        value++;
                    }
                }
            }
            sw.WriteLine($"{line[0]} {value}");
        }
    }
}