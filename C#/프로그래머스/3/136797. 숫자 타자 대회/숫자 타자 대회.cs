using System;
using System.Collections.Generic;
using static System.Math;
public class Solution
{
    public int solution(string numbers)
    {
        const int MAX = 100000000;

        int[,] map = new int[4, 3];
        /* 1 2 3
         * 4 5 6
         * 7 8 9
         * * 0 # */

        for (int r = 0; r < 3; r++)
            for (int c = 0; c < 3; c++)
                map[r, c] = r * 3 + c + 1;

        map[3, 0] = -1; // *표. 진입불가
        map[3, 1] = 0; // 0번 위치.
        map[3, 2] = -1; // #표. 진입불가.

        int[] visited = new int[10]; // 현재노드에서 [n]노드이동 비용
        int[,] move = new int[10, 10]; // [from, to]의 비용.

        Queue<(int row, int col, int cost)> queue = new Queue<(int row, int col, int cost)>();

        for (int i = 0; i < 10; i++)
        {
            Array.Fill(visited, MAX);

            int x = i == 0 ? 11 : i; // 0위치가 11번째니 예외처리.

            int r = (x - 1) / 3;
            int c = (x - 1) % 3;

            queue.Enqueue((r, c, 0));
            visited[i] = 1;

            while (queue.Count > 0)
            {
                (int row, int col, int cost) = queue.Dequeue();

                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx == 0 && dy == 0) continue;

                        int nextRow = row + dy;
                        int nextCol = col + dx;

                        // 위치 밖인 경우 거르기.
                        if (nextRow < 0 || nextRow >= 4 || nextCol < 0 || nextCol >= 3 || map[nextRow, nextCol] == -1)
                            continue;

                        int number = map[nextRow, nextCol]; // r,c 위치 숫자.
                        int nextCost = cost;

                        if (dx == 0 || dy == 0) // 4각이동 
                            nextCost = nextCost + 2;
                        else
                            nextCost = nextCost + 3; // 대각선이동

                        if (nextCost < visited[number]) // 이득이면 사용.
                        {
                            queue.Enqueue((nextRow, nextCol, nextCost));
                            visited[number] = nextCost;
                        }
                    }
                }
            }

            for (int j = 0; j < 10; j++) // i노드에서 시작해 j노드까지 가는 비용을 구했으니 기록.
                move[i, j] = visited[j];
        }


        // 진행도, 왼쪽손가락위치, 오른쪽손가락위치
        int[,,] dp = new int[numbers.Length + 1, 10, 10];

        for (int i = 0; i < dp.GetLength(0); i++)
            for (int j = 0; j < dp.GetLength(1); j++)
                for (int k = 0; k < dp.GetLength(2); k++)
                    dp[i, j, k] = MAX;

        dp[0, 4, 6] = 0; // 4,6 위치로 시작

        for (int i = 1; i <= numbers.Length; i++)
        {
            int pos = numbers[i - 1] - '0'; // 현재 눌러야 할 숫자

            for (int left = 0; left < 10; left++)
            {
                for (int right = 0; right < 10; right++)
                {
                    if (left == right) continue; //(같은 숫자에 2개 손가락 금지.)
                    if (dp[i - 1, left, right] == MAX) continue; // i-1 진행도에서 손가락을 [left, right] 위치에 두는 경우가 없으면 스킵.

                    // 왼쪽 손가락을 pos로.
                    dp[i, pos, right] = Min(dp[i - 1, left, right] + move[left, pos], dp[i, pos, right]);

                    // 오른쪽 손가락을 pos로.
                    dp[i, left, pos] = Min(dp[i - 1, left, right] + move[right, pos], dp[i, left, pos]);
                }
            }
        }

        int answer = MAX;

        for (int left = 0; left < 10; left++)
            for (int right = 0; right < 10; right++)
                answer = Min(dp[numbers.Length, left, right], answer);


        return answer;
    }
}