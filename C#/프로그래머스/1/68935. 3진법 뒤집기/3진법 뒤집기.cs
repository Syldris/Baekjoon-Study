using System;
using System.Text;
public class Solution
{
    public int solution(int n)
    {
        int answer = 0;

        StringBuilder sb = new StringBuilder();

        while (n > 0) // 3진법으로 분해 x3^0 + x3^1 + x3^2
        {
            sb.Append(n % 3);
            n /= 3;
        }

        // 3진법으로 변환했을때 역순으로 저장됐으므로 바로 10진법으로 전환.
        int mul = 1;

        for (int i = sb.Length - 1; i >= 0; i--)
        {
            answer += (sb[i] - '0') * mul;
            mul *= 3;
        }

        return answer;
    }
}