using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int tastcaset = int.Parse(sr.ReadLine());
        string line;

        for (int t = 0; t < tastcaset; t++)
        {
            line = sr.ReadLine();

            int start = 0, end = line.Length - 1;
            sw.WriteLine(Palindrome(start,end,false));
        }

        int Palindrome(int start, int end, bool isPseudo)
        {
            int num = 0;
            while (start < end)
            {
                if (line[start] == line[end])
                {
                    start++;
                    end--;
                }
                else if (!isPseudo)
                {
                    int a = Palindrome(start + 1, end, true);
                    int b = Palindrome(start, end - 1, true);
                    return Math.Min(a, b);
                }
                else
                {
                    return 2;
                }
            }
            return isPseudo ? 1 : 0;
        }
    }
}
