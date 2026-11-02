using System;
public class Solution
{
    public string solution(string s)
    {
        char[] arr = new char[s.Length];

        int order = 0; // 단어내에서 몇번째인지 기록. (첫번째는 0으로 시작함)

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                arr[i] = ' ';
                order = 0;
                continue;
            }

            if(order % 2 == 0)
                arr[i] = Char.ToUpper(s[i]);
            else
                arr[i] = Char.ToLower(s[i]);
            
            order++;
        }

        return new string(arr);
    }
}