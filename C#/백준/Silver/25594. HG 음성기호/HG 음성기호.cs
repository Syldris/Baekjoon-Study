#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] arr = new string[] { "aespa", "baekjoon", "cau", "debug", "edge", "firefox", "golang", "haegang", "iu", "java", "kotlin", "lol", "mips", "null", "os", "python", "query", "roka", "solvedac", "tod", "unix", "virus", "whale", "xcode", "yahoo", "zebra" };
        StringBuilder sb = new();
        string text = sr.ReadLine();

        int index = 0;
        while (true)
        {
            if (index == text.Length)
                break;

            char c = ' ';
            c = Check(text[index],index);
            if(c == '?')
            {
                sw.Write("ERROR!");
                return;
            }

            sb.Append(c);
            index += arr[c - 'a'].Length;
        }
        sw.WriteLine("It's HG!");
        sw.WriteLine(sb);

        char Check(char c, int index)
        {
            int len = arr[c - 'a'].Length;
            for (int i = 0; i < len; i++)
            {
                int pos = index + i;
                if (pos >= text.Length)
                    return '?';

                if (text[pos] != arr[c - 'a'][i])
                    return '?';

            }

            return c;
        }
    }
}