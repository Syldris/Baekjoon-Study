using System;
class Solution
{
    public int solution(int n)
    {
        int value = 0; // n의 1 갯수.
        for (int i = 0; i < 20; i++)
        {
            value += (n >> i) & 1;
        }

        for (int i = n + 1; i <= 1000000; i++)
        {
            int num = 0;
            for (int k = 0; k < 20; k++)
            {
                num += (i >> k) & 1;
            }

            if (num == value)
                return i;
        }

        return 0;
    }
}