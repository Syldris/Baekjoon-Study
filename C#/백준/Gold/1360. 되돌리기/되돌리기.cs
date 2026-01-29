#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        (string text, string info, int time)[] query = new (string, string, int)[n];

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();

            query[i] = (line[0], line[1], int.Parse(line[2]));
        }

        List<char> list = new List<char>();
        int ignore = int.MaxValue;

        for (int i = n - 1; i >= 0; i--)
        {
            (string text, string info, int time) = query[i];

            if (time >= ignore) continue;

            if (text == "undo")
            {
                ignore = time - int.Parse(info);
            }
            else
            {
                list.Add(info[0]);
            }
        }

        StringBuilder sb = new StringBuilder();
        for (int i = list.Count - 1; i >= 0; i--)
        {
            sb.Append(list[i]);
        }

        sw.Write(sb);
    }
}