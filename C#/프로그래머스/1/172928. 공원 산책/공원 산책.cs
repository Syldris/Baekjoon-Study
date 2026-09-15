using System;

public class Solution
{
    public int[] solution(string[] park, string[] routes)
    {
        int n = park.Length; // 행길이 r
        int m = park[0].Length; // 열길이 c 
        
        bool[,] board = new bool[n, m]; // [r,c] = 장애물 여부.

        int r = 0, c = 0;

        for (int i = 0; i < n; i++)
        {
            string text = park[i];

            for (int j = 0; j < m; j++)
            {
                board[i, j] = text[j] == 'X';

                if (text[j] == 'S')
                {
                    r = i;
                    c = j;
                }
            }
        }

        int[] dr = new int[4] { -1, 1, 0, 0 };
        int[] dc = new int[4] { 0, 0, -1, 1 };

        for (int i = 0; i < routes.Length; i++)
        {
            string[] split = routes[i].Split(' ');

            int move = int.Parse(split[1]);

            int dir = split[0] switch
            {
                "N" => 0,
                "S" => 1,
                "W" => 2,
                "E" => 3,
            };

            for (int j = 1; j <= move; j++)
            {
                int pr = r + dr[dir] * j;
                int pc = c + dc[dir] * j;

                if (pr >= n || pc >= m || pr < 0 || pc < 0) // 범위 밖
                    break;

                if (board[pr,pc]) // 장애물
                    break;

                if (j == move) // 마지막 루프까지 성공한다면 이동
                {
                    r = pr;
                    c = pc;
                }
            }
        }

        return new int[2] { r, c };
    }
}