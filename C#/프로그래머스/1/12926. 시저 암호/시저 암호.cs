public class Solution
{
    public string solution(string s, int n)
    {
        char[] arr = new char[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ') // 공백은 안밀림.
            {
                arr[i] = ' ';
                continue;
            }

            int order; // 알파벳 순서

            if ('a' <= s[i] && s[i] <= 'z') // 소문자
            {
                order = (s[i] - 'a' + n) % 26;
                arr[i] = (char)(order + 'a');
            }
            else // 대문자
            {
                order = (s[i] - 'A' + n) % 26;
                arr[i] = (char)(order + 'A');
            }
        }

        return new string(arr);
    }
}