#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = sr.ReadLine();

        int count = (text.Length - 1) * 9 + 1;

        char num = text[0];
        bool minus = false;
        foreach (var item in text)
        {
            if (num < item)
            {
                break;
            }
            if (num > item)
            {
                minus = true;
                break;
            }
        }

        count += num - '0';
        if (minus)
        {
            count--;
        }

        sw.WriteLine(count);
    }
}