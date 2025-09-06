#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            int n = int.Parse(sr.ReadLine());

            if (n == 0)
            {
                break;
            }

            (string name, float len)[] info = new (string name, float len)[n];
            for (int i = 0; i < n; i++)
            {
                string[] line = sr.ReadLine().Split();
                info[i] = (line[0], float.Parse(line[1]));
            }

            float maxlen = info.Select(x => x.len).Max();
            string[] output = info.Where(x => x.len == maxlen).Select(x => x.name).ToArray();

            sw.WriteLine(String.Join(' ', output));
        }
    }
}
