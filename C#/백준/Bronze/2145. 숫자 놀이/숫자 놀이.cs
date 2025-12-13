#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            string text = sr.ReadLine();
            if (text == "0")
            {
                break;
            }

            while (text.Length != 1)
            {
                int value = 0;
                foreach (var item in text)
                {
                    value += item - '0';
                }
                text = value.ToString();
            }
            sw.WriteLine(text);
        }
    }
}