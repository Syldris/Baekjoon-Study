using System;
using System.Collections.Generic;
public class Solution
{
    bool[,] visited = new bool[5, 5];
    char[,] board = new char[5, 5];

    int[] dx = new int[4] { -1, 1, 0, 0 };
    int[] dy = new int[4] { 0, 0, -1, 1 };

    public int[] solution(string[,] places)
    {
        int[] answer = new int[5];

        for (int i = 0; i < places.GetLength(0); i++)
        {
            bool pass = true;

            List<(int x, int y)> peoples = new List<(int x, int y)>();

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    char c = places[i, y][x];
                    board[x, y] = c;

                    if (c == 'P')
                        peoples.Add((x, y));
                }
            }

            foreach ((int x, int y) in peoples)
            {
                if (!BFS(x, y))
                {
                    pass = false;
                    break;
                }
            }

            answer[i] = pass ? 1 : 0;
        }

        return answer;
    }

    bool BFS(int startX, int startY)
    {
        Queue<(int x, int y, int move)> queue = new Queue<(int x, int y, int move)>();
        queue.Enqueue((startX, startY, 0));

        for (int y = 0; y < 5; y++)
            for (int x = 0; x < 5; x++)
                visited[x, y] = false;

        visited[startX, startY] = true;

        while (queue.Count > 0)
        {
            (int x, int y, int move) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= 5 || py >= 5)
                    continue;

                if (!visited[px, py] && board[px, py] == 'P') // 다른 사람 만나면 거리두기 실패.
                    return false;

                int nextMove = move + 1;

                // 무브는 1번만 하고 주변 살펴보기로 총 거리 2까지 확인.
                if (nextMove <= 1 && board[px, py] != 'X' && !visited[px, py])
                {
                    queue.Enqueue((px, py, nextMove));
                    visited[px, py] = true;
                }
            }
        }

        return true;
    }
}