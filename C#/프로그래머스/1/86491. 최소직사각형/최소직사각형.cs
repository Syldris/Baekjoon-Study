using System;

public class Solution
{
    public int solution(int[,] sizes)
    {
        // 그리디 관찰.
        // 큰값은 큰값끼리, 작은값은 작은값끼리 분리하면 항상 최적이다.
        // 제일 큰값 쪽에 다른 큰값들을 넣고 작은값을 반대쪽으로 몰아넣어 최적화.

        // 제일 큰값을 X라고 할때, 어떻게 조정하더라도 최종값은 X * max(y) 가 되니. y를 최적화 하는것.

        int maxX = 0, maxY = 0;
        for (int i = 0; i < sizes.GetLength(0); i++)
        {
            int x = sizes[i, 0];
            int y = sizes[i, 1];

            if (x < y) (x, y) = (y, x); // x가 더크게 회전

            maxX = Math.Max(maxX, x);
            maxY = Math.Max(maxY, y);
        }

        return maxX * maxY;
    }
}