#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string text = sr.ReadLine();
        int len = text.Length;

        int n = int.Parse(sr.ReadLine());
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();

            if (line.Contains(text))
            {
                result++;
                continue;
            }

            if (len > 1)
            {
                string line2 = line[^(len - 1)..] + line[..(len - 1)];
                if (line2.Contains(text))
                    result++;
            }
        }

        sw.Write(result);
    }
}