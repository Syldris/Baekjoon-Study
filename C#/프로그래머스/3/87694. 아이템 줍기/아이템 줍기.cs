using System;
using System.Collections.Generic;
using static System.Math;
public class Solution
{
    const int SIZE = 50;
    public int solution(int[,] rectangle, int characterX, int characterY, int itemX, int itemY)
    {
        bool[,] board = new bool[SIZE + 1, SIZE + 1]; // 사각형 체크.

        // 사각형의 테두리가 다른 사각형의 내부일수있으니 둘다체크해 진짜 외부 테두리로만 이동.

        // 점 대신 공간으로 생각해서. x,x+1 사이 공간을 공간 x라고 두자.
        // 좌하단(2,2) 우상단(3,4) 인 경우 공간 (2,2), (2,3) 를 가지게끔.
        // 예시 1,1 점이 가운데 있을때
        // ㅁㅁ  0,1 1,1   x-1,y   x,y
        // ㅁㅁ  0,0 1,0  x-1,y-1 x,y-1 

        for (int i = 0; i < rectangle.GetLength(0); i++)
        {
            int x1 = rectangle[i, 0];
            int y1 = rectangle[i, 1];
            int x2 = rectangle[i, 2];
            int y2 = rectangle[i, 3];

            for (int x = x1; x < x2; x++)
            {
                for (int y = y1; y < y2; y++)
                {
                    board[x, y] = true; // 사각형 내부공간 체크.
                }
            }
        }

        int[] dx = new int[4] { -1, 1, 0, 0 };
        int[] dy = new int[4] { 0, 0, 1, -1 };

        bool[,] visited = new bool[SIZE + 1, SIZE + 1];
        Queue<(int x, int y, int time)> queue = new Queue<(int x, int y, int time)>();

        queue.Enqueue((characterX, characterY, 0)); // 시작위치.
        visited[characterX, characterY] = true;

        while (queue.Count > 0)
        {
            (int x, int y, int time) = queue.Dequeue();

            if (x == itemX && y == itemY)
                return time;

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px <= 0 || py <= 0 || px > SIZE || py > SIZE)
                    continue;

                // 테두리인지 체크할땐 해당 방향 기준 선분 좌우로
                // □ | ■  이렇게 2개중 1개만 칠해졌을때 테두리임
                //  위      아래     좌     우
                // ■ | □   □ | □   □ | □  □ | □ 
                // □ | □   ■ | □   ■ | □  □ | ■ 

                //  (x-1,y)   (x,y)
                // (x-1,y-1) (x,y-1) 

                bool chack = i switch
                {
                    0 when board[x - 1, y] != board[x - 1, y - 1] => true, // 좌
                    1 when board[x, y] != board[x, y - 1] => true, // 우
                    2 when board[x - 1, y] != board[x, y] => true, // 상
                    3 when board[x - 1, y - 1] != board[x, y - 1] => true, // 하
                    _ => false
                };

                // 방문하지않은 사각형 테두리 좌표일떄 방문
                if (!visited[px, py] && chack)
                {
                    visited[px, py] = true;

                    queue.Enqueue((px, py, time + 1));
                }
            }
        }

        return -1;
    }
}