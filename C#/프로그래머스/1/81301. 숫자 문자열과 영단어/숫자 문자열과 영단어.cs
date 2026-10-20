using System;
using System.Text;
public class Solution
{
    public int solution(string s)
    {
        int answer = 0;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            if('0' <= s[i] && s[i] <= '9') // 0~9사이라면 추가
            {
                answer *= 10;
                answer += s[i] - '0';
            }
            else
                sb.Append(s[i]);

            int number = Convert(sb.ToString());

            if (number != -1) // 문자 => 숫자 완성되면 추가.
            {
                answer *= 10;
                answer += number;
                sb.Clear(); // 사용후 초기화.
            }
        }

        return answer;
    }

    int Convert(string text) => text switch
    {
        "zero" => 0,
        "one" => 1,
        "two" => 2,
        "three" => 3,
        "four" => 4,
        "five" => 5,
        "six" => 6,
        "seven" => 7,
        "eight" => 8,
        "nine" => 9,
        _ => -1
    };
}