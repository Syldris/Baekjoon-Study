#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        char[] arr = new char[] { 'q', 'a', 'z', 'w', 's', 'x', 'e', 'd', 'c', 'r', 'f', 'v', 't', 'g', 'b', 'y' };

        string text = sr.ReadLine();
        int value = 0;
        foreach (var item in text)
        {
            if (item == ' ')
            {
                value++;
            }
            else if('A' <= item && item <= 'Z')
            {
                value++;
            }
        }
        text = text.ToLower().Replace(" ", "");
        int left = 0;
        int right = 0;
        foreach (var item in text)
        {
            if (arr.Contains(item))
            {
                left++;
            }
            else
            {
                right++;
            }
        }
        while (value != 0)
        {
            value--;
            if (left <= right)
            {
                left++;
            }
            else
            {
                right++;
            }
        }
        sw.Write($"{left} {right}");
    }
}
