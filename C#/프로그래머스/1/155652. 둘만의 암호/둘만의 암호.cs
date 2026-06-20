using System;
using System.Text;
public class Solution
{
    public string solution(string s, string skip, int index)
    {
        bool[] skipAlphabet = new bool[26];

        for (int i = 0; i < skip.Length; i++)
        {
            int c = skip[i] - 'a';
            skipAlphabet[c] = true;
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            int num = index;
            char c = s[i];
            while (num > 0)
            {
                if (c == 'z') c = 'a'; // z => a 로 다시 이동.
                else c++;

                if (skipAlphabet[c - 'a']) continue;
                num--;
            }

            sb.Append(c);
        }


        return sb.ToString();
    }
}