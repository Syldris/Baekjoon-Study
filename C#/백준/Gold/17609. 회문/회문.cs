using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int tastcaset = int.Parse(sr.ReadLine());
        for (int t = 0; t < tastcaset; t++)
        {
            string line = sr.ReadLine();

            int start = 0, end = line.Length - 1;
            int num = 0;

            while (start < end)
            {
                if (line[start] == line[end])
                {
                    start++;
                    end--;
                }
                else if (Palindrome(line, start + 1, end) || Palindrome(line, start, end - 1))
                {
                    num = 1;
                    break;
                }
                else
                {
                    num = 2;
                    break;
                }
            }
            sw.WriteLine(num);
        }
        bool Palindrome(string line, int start, int end)
        {
            while (start < end)
            {
                if (line[start] == line[end])
                {
                    start++;
                    end--;
                }
                else
                    return false;
            }
            return true;
        }
    }
}
