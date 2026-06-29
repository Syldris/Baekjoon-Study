public class Solution
{
    public string solution(int n)
    {
        char[] chars = new char[n];
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
                chars[i] = '수';
            else
                chars[i] = '박';
        }
        return new string(chars);
    }
}