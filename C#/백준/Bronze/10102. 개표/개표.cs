#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        string text = sr.ReadLine();

        int a = 0;
        int b = 0;

        for (int i = 0; i < n; i++)
        {
            if (text[i] == 'A')
                a++;
            else
                b++;
        }

        if (a == b)
            sw.Write("Tie");
        else if (a > b)
            sw.Write('A');
        else
            sw.Write('B');
    }
}