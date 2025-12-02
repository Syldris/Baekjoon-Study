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
            string[] line = sr.ReadLine().Split();

            StringBuilder sb = new StringBuilder();

            string a = line[0];
            string b = line[1];

            (a, b) = a.Length < b.Length ? (b, a) : (a, b);

            int diff = a.Length - b.Length;
            for (int i = 0; i < diff; i++)
            {
                sb.Append(a[i]);
            }

            for (int i = 0; i < b.Length; i++)
            {
                int value = (a[i + diff] - '0') * (b[i] - '0'); 
                sb.Append(value);
            }

            long result = long.Parse(sb.ToString());
            long ab = long.Parse(line[0]) * long.Parse(line[1]);
            sw.WriteLine(result == ab ? '1' : '0');
        }
    }
}