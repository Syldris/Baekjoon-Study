#nullable disable
using System;
using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            string[] line = sr.ReadLine().Split();
            string text1 = line[0];
            string text2 = line[1];
            StringBuilder sb = new StringBuilder();
            foreach (var item in text1)
            {
                if (item >= 'a' && item <= 'z')
                {
                    sb.Append(char.ToUpper(item));
                }
                else if (item >= 'A' && item <= 'Z')
                {
                    sb.Append(char.ToLower(item));
                }
                else
                {
                    sb.Append(item);
                }
            }
            
            string text3 = sb.ToString();

            if (text1 == text2)
            {
                sw.WriteLine($"Case {i}: Login successful.");
            }
            else if (text2 == text3)
            {
                sw.WriteLine($"Case {i}: Wrong password. Please, check your caps lock key.");
            }
            else if (text2 == Regex.Replace(text1, @"\d", ""))
            {
                sw.WriteLine($"Case {i}: Wrong password. Please, check your num lock key.");
            }
            else if (text2 == Regex.Replace(text3, @"\d", ""))
            {
                sw.WriteLine($"Case {i}: Wrong password. Please, check your caps lock and num lock keys.");
            }
            else
            {
                sw.WriteLine($"Case {i}: Wrong password.");
            }
        }
    }
}
