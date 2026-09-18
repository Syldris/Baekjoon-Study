using System;

public class Solution
{
    public int solution(string s)
    {
        int answer = 0;

        char c = '-';
        int main = 0, sub = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (c == '-') // 분리하고 문자열 첫 문자를 저장.
            {
                c = s[i];
                answer++;
            }

            if (c == s[i])
                main++;
            else
                sub++;

            if (main == sub) // 첫문자 갯수와 나머지 다른 글자 나온 횟수가 같으면 분리.
                c = '-';
        }

        return answer;
    }
}