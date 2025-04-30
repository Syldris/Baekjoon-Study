using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        while (true)
        {
            string line = Console.ReadLine();
            if(line == "end")
                break;
            int consonantCount = 0;
            int vowelCount = 0;
            bool isVowel = false;

            char letter = '-';
            bool password = true;
            foreach (char c in line)
            {
                if(!password)
                    break;

                switch(c)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        isVowel = true;
                        consonantCount = 0;
                        vowelCount++;
                        break;
                    default:
                        vowelCount = 0;
                        consonantCount++;
                        break;
                }

                if (consonantCount >= 3 || vowelCount >= 3)
                    password = false;

                if (letter == c && c != 'e' && c != 'o')
                {
                    password = false;
                }
                letter = c;
            }

            if(!isVowel)
                password = false;

            if (password)
                sb.AppendLine($"<{line}> is acceptable.");
            else
                sb.AppendLine($"<{line}> is not acceptable.");
        }
        Console.WriteLine(sb);
    }
}