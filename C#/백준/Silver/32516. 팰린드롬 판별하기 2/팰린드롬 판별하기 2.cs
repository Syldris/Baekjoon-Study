#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        string text = sr.ReadLine();

        int range = n / 2;
        int value = 0;
        for (int i = 0; i < range; i++)
        {
            char left = text[i];
            char right = text[^(i + 1)];

            if (left != '?' && right != '?')
            {
                if (left != right)
                {
                    sw.Write(0);
                    return;
                }
            }
            else if (left == '?' && right == '?')
            {
                value += 26;
            }
            else
            {
                value++;
            }
        }
        sw.Write(value);
    }
}