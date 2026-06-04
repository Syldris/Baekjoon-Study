using System;
using System.Collections.Generic;
public class Solution
{
    List<(int x, int y)> emptyList = new List<(int x, int y)>();

    int n = 0;
    int m = 0;

    int[] dx = new int[4] { -1, 1, 0, 0 };
    int[] dy = new int[4] { 0, 0, -1, 1 };

    public int solution(string[] storage, string[] requests)
    {
        n = storage.Length;
        m = storage[0].Length;

        char[,] board = new char[m + 2, n + 2]; // +2 크기로 테두리를 0으로 설정해서 빈공간 테두리를 만들자.
        bool[,] visited = new bool[m + 2, n + 2];

        for (int y = 1; y <= n; y++)
        {
            for (int x = 1; x <= m; x++)
            {
                board[x, y] = storage[y - 1][x - 1]; // 1-index => 0-index
            }
        }

        for (int i = 0; i <= m + 1; i++) // 가로 테두리
        {
            board[i, 0] = '0';
            board[i, n + 1] = '0';

            emptyList.Add((i, 0));
            emptyList.Add((i, n + 1));
        }

        for (int i = 1; i <= n; i++) // 세로 테두리 (가로에서 모서리 부분 해결 완.)
        {
            board[0, i] = '0';
            board[m + 1, i] = '0';

            emptyList.Add((0, i));
            emptyList.Add((m + 1, i));
        }

        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();

        for (int i = 0; i < requests.Length; i++)
        {
            if (requests[i].Length == 1) // 1글자면 지게차.
            {
                Forklift(requests[i][0], board);
            }
            else // 2글자면 크레인.
            {
                Crane(requests[i][0], board, visited);
            }

            for (int j = 0; j < emptyList.Count; j++)
            {
                int x = emptyList[j].x;
                int y = emptyList[j].y;

                queue.Enqueue((x, y));
                visited[x, y] = true;
            }

            OutSideCheck(board, visited, queue); // 바깥공간 재확인.
            Array.Clear(visited, 0, visited.Length);
        }

        int answer = 0;
        for (int y = 1; y <= n; y++)
        {
            for (int x = 1; x <= m; x++)
            {
                if (board[x, y] != '0')
                {
                    answer++;
                }
            }
        }
        return answer;

    }

    void Forklift(char c, char[,] board)
    {
        List<(int x, int y)> select = new List<(int x, int y)>();

        foreach (var item in emptyList)
        {
            for (int i = 0; i < 4; i++)
            {
                int px = item.x + dx[i];
                int py = item.y + dy[i];

                if (px <= 0 || py <= 0 || px > m || py > n) // 테두리 바깥쪽은 검사 X
                    continue;

                if (board[px, py] == c)
                {
                    select.Add((px, py));
                    board[px, py] = '0';
                }
            }
        }

        foreach (var item in select) // 바깥공간과 연결되어 있으니 제거시 바깥공간으로 추가.
        {
            emptyList.Add((item.x, item.y));
        }
    }

    void Crane(char c, char[,] board, bool[,] visited)
    {
        for (int y = 1; y <= n; y++)
        {
            for (int x = 1; x <= m; x++)
            {
                if (board[x, y] == c)
                {
                    board[x, y] = '0'; // 제거
                }
            }
        }
    }

    void OutSideCheck(char[,] board, bool[,] visited, Queue<(int, int)> queue)
    {
        while (queue.Count > 0)
        {
            (int x, int y) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px > m + 1 || py > n + 1)
                    continue;

                if (board[px, py] == '0' && !visited[px, py])
                {
                    emptyList.Add((px, py));
                    visited[px, py] = true;
                    queue.Enqueue((px, py));
                }
            }
        }
    }
}