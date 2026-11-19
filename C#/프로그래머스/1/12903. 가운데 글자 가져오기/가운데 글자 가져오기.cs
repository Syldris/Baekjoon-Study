public class Solution
{
    public string solution(string s)
    {
        int half = s.Length / 2;

        if (s.Length % 2 == 1) // 홀수인 경우 
            return s.Substring(half, 1);
        else
            return s.Substring(half - 1, 2);
    }
}