using System;

public class Solution
{
    public bool solution(string s)
    {
        bool answer = true;

        int left = 0;
        int right = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
                left++;
            else
                right++;

            if (right > left) return false;
        }

        return left == right ? true : false;
    }
}