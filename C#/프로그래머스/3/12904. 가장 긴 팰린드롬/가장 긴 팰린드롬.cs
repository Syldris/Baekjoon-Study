using static System.Math;
public class Solution
{
    public int solution(string s)
    {
        int answer = 0;

        for (int i = 0; i < s.Length; i++) // 홀수길이 팰린드롬
        {
            int len = 1;
            int start = i, end = i; // i를 중간으로 잡고 start end 범위를 늘려가기

            while (--start >= 0 && ++end < s.Length)
            {
                if (s[start] != s[end])
                {
                    break;
                }
                len += 2;
            }

            answer = Max(answer, len);
        }

        for (int i = 1; i < s.Length; i++) // 짝수길이 팰린드롬
        {
            if (s[i - 1] != s[i]) continue; // i-1과 i를 기준으로 잡으니 둘이 같아야함.

            int len = 2;
            int start = i - 1, end = i; // i-1 ~ i를 중간으로 잡고 start end 범위를 늘려가기

            while (--start >= 0 && ++end < s.Length)
            {
                if (s[start] != s[end])
                {
                    break;
                }
                len += 2;
            }

            answer = Max(answer, len);
        }

        return answer;
    }
}