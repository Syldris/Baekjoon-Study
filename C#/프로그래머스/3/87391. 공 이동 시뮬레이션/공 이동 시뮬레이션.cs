using System;
using static System.Math;
public class Solution
{
    public long solution(int n, int m, int x, int y, int[,] queries)
    {
        // 도착점에 도달하는 x1~x2 | y1~y2 사각형
        // 이상하게 문제가 행을 x, 열을 y로 주길래 편한대로 변환함.
        int x1 = y;
        int x2 = y;
        int y1 = x;
        int y2 = x;

        for (int i = queries.GetLength(0) - 1; i >= 0; i--) // 온 순서를 역방향으로 추적.
        {
            int command = queries[i, 0];
            int move = queries[i, 1];

            if (command == 0) // <= 정방향
            {
                if (x1 == 0) // x1 = 0일떄 <= 라면 오른쪽에 있는 점에서도 0으로 도착할수있음.
                {
                    x2 = Min(x2 + move, m - 1);
                }
                else // 아니라면 무브. 도착지점을 <= 방향으로 왔었음을 나타내니 시작지점은 =>방향에 있다.
                {
                    x1 += move;
                    x2 += move;
                }
            }
            else if (command == 1) // => 방향
            {
                if (x2 == m - 1) // x2 == m-1 일때 => 방향으로 오는점을 역추적. 왼쪽에 있는점도 추가로 올수있음
                {
                    x1 = Max(x1 - move, 0);
                }
                else // 역시나 도착치점기준 => 방향이므로 시작지점은 <= 방향.
                {
                    x1 -= move;
                    x2 -= move;
                }
            }
            else if (command == 2) // 윗 방향
            {
                if (y1 == 0) // y1 = 0 이라면 아래에있는점도 올라오면서 0쪽으로 합쳐지기 가능.
                {
                    y2 = Min(y2 + move, n - 1);
                }
                else // 도착치점기준 윗 방향이므로 시작지점은 아랫 방향.
                {
                    y1 += move;
                    y2 += move;
                }
            }
            else if (command == 3) // 아랫 방향
            {
                if (y2 == n - 1) // y = n 일떄 아래로 내려오면 위에있던 점들도 아래로 내려오기 가능.
                {
                    y1 = Max(y1 - move, 0);
                }
                else // 역시나 도착치점기준 아랫 방향이므로 시작지점은 윗 방향.
                {
                    y1 -= move;
                    y2 -= move;
                }
            }
            x1 = Max(x1, 0); // <=으로 밀어도 왼쪽끝 0이상은 보장.
            x2 = Min(x2, m - 1); // => 으로 밀어도 오른쪽 끝 m-1이하임을 보장.
            if (x1 > x2) return 0; // [1,3] 일떄 =>4 로 왼쪽 4칸 밀리면 [0,-1].=>4로 3이되려면 -1이여야하는데 불가. 실구간이 존재하지않을 때 0 반환.

            y1 = Max(y1, 0); 
            y2 = Min(y2, n - 1);
            if (y1 > y2) return 0;
        }

        return (long)(x2 - x1 + 1) * (y2 - y1 + 1);
    }
}