#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = sr.ReadLine();
        int index = -1;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '-')
            {
                index = i;
                break;
            }
        }

        int result = 0;

        if (index == -1)
        {
            int[] add = text.Split('+').Select(int.Parse).ToArray();
            foreach (var item in add)
            {
                result += item;
            }
            sw.Write(result);
            return;
        }
        else if (index > 0)
        {
            int[] plus = text[..index].Split('+', '-').Select(int.Parse).ToArray();
            foreach (var item in plus)
            {
                result += item;
            }
        }

        int[] minus = text[(index+1)..].Split('+', '-').Select(int.Parse).ToArray();

        foreach (var item in minus)
        {
            result -= item;
        }

        sw.Write(result);
    }
}