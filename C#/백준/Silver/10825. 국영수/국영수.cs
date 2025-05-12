using System.Text;

public class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        (string name, int korean, int english, int science)[] student = new (string, int, int, int)[n];

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            student[i] = (line[0], int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]));
        }

        student = student.OrderByDescending(x => x.korean).ThenBy(x => x.english).ThenByDescending(x => x.science).ThenBy(x => x.name).ToArray();

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.AppendLine(student[i].name);
        }
        sw.Write(sb);
    }
}
