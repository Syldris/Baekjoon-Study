#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        string text = sr.ReadLine();
        long cur = 0;
        long result = 0;

        for (int i = 0; i < n; i++)
        {
            if (text[i] == '1')
                cur++;
            else
            {
                result += cur * (cur + 1) / 2;
                cur = 0;
            }
        }

        result += cur * (cur + 1) / 2;

        sw.Write(result);
    }
}