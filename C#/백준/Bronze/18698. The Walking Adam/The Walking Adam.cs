#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int result = 0;
            string line = sr.ReadLine();
            foreach (var item in line)
            {
                if (item == 'U')
                {
                    result++;
                }
                else
                {
                    break;
                }
            }
            sw.WriteLine(result);
        }
    }
}