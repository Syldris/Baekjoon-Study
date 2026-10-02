using System;
using static System.Math;
public class Solution
{
    public int[] solution(int m, int n, int startX, int startY, int[,] balls)
    {
        int len = balls.GetLength(0);
        int[] answer = new int[len];

        for (int i = 0; i < len; i++)
        {
            int x = balls[i, 0];
            int y = balls[i, 1];

            answer[i] = int.MaxValue;

            if (!(x == startX && y > startY)) // 윗벽. x 좌표 같고 공이 시작점위에 있으면 부딫힘.
            {
                int width = Abs(x - startX);
                int height = n - startY + n - y;

                answer[i] = Min(answer[i], width * width + height * height);
            }
            if (!(x == startX && y < startY)) // 아랫벽. x 좌표 같고 공이 시작점아래에 있으면 부딫힘.
            {
                int width = Abs(x - startX);
                int height = y + startY;

                answer[i] = Min(answer[i], width * width + height * height);
            }
            if (!(y == startY && x < startX)) // 왼쪽벽. y좌표 같고 공이 시작점 왼쪽에 있으면 부딫힘.
            {
                int width = startX + x;
                int height = Abs(y - startY);

                answer[i] = Min(answer[i], width * width + height * height);
            }
            if (!(y == startY && x > startX)) // 오른쪽벽. y좌표 같고 공이 시작점 오른쪽에 있으면 부딫힘.
            {
                int width = m - startX + m - x;
                int height = Abs(y - startY);

                answer[i] = Min(answer[i], width * width + height * height);
            }
        }

        return answer;
    }
}