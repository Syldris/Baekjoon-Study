#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = sr.ReadLine();
        string word = sr.ReadLine();
        int index = 0;
        int result = 0;
        for (int i = 1; i <= text.Length; i++)
        {
            string line = text[index..i];
            if (line.Contains(word))
            {
                index = i;
                result++;
            }
        }
        sw.Write(result);
    }
}
