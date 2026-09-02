using System;
using System.Text;
public class Solution
{
    public string solution(string s)
    {
        StringBuilder sb = new StringBuilder();
        bool upper = true; // 시작시 대문자.

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (upper)
            {
                c = Char.ToUpper(c);
                upper = false;
            }
            else c = Char.ToLower(c);

            if (c == ' ') upper = true; // 공백이면 다음글자 대문자로.

            sb.Append(c);
        }

        return sb.ToString();
    }
}