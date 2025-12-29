#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(), 65535));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput(), 65535));

        string text = sr.ReadLine();
        char c = text[0];
        bool find = false;
        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] != c)
            {
                find = true;
            }
        }

        if (!find)
        {
            sw.Write(-1);
            return;
        }
        int half = text.Length / 2;
        int odd = text.Length % 2;

        if (text[..half] == new string(text[(half + odd)..].Reverse().ToArray()))
        {
            sw.Write(text.Length - 1);
        }
        else
        {
            sw.Write(text.Length);
        }
    }
}