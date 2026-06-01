using System;

public class Solution
{
    public int solution(int[,] signals)
    {
        int n = signals.GetLength(0);

        int lcm = signals[0, 0] + signals[0, 1] + signals[0, 2];

        for (int i = 1; i < n; i++)
        {
            int size = signals[i, 0] + signals[i, 1] + signals[i, 2];
            lcm = (lcm / GCD(lcm, size)) * size; // 최대 공배수 = 두 수의 곱 / 최대 공약수
        }

        for (int i = 1; i <= lcm; i++)
        {
            bool find = true;
            for (int j = 0; j < n; j++)
            {
                int g = signals[j, 0];
                int y = signals[j, 1];
                int r = signals[j, 2];

                int total = g + y + r;

                int pos = i % total;

                if (pos <= g)
                {
                    find = false;
                    break;
                }
                else if (pos > g + y)
                {
                    find = false;
                    break;
                }
            }

            if (find) return i;
        }

        return -1;
    }

    int GCD(int a, int b)
    {
        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }
        return a;
    }
}