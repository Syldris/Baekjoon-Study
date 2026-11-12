using System;
using System.Collections.Generic;
using static System.Math;
public class Solution
{
    int[] dr = { -1, 1, 0, 0 };
    int[] dc = { 0, 0, -1, 1 };

    int rowSize;
    int colSize;
    int panelSize;
    int answer = int.MaxValue;

    public int solution(int h, string[] grid, int[,] panels, int[,] seqs)
    {
        rowSize = grid.Length;
        colSize = grid[0].Length;
        panelSize = panels.GetLength(0);

        int[] indegree = new int[panelSize];
        List<int>[] nextNodes = new List<int>[panelSize];
        for (int i = 0; i < panelSize; i++)
            nextNodes[i] = new();

        for (int i = 0; i < seqs.GetLength(0); i++)
        {
            // 1-index => 0-index
            int a = seqs[i, 0] - 1;
            int b = seqs[i, 1] - 1;

            nextNodes[a].Add(b); // a 활성화시 b진입차수 감소되게끔 미리 기록.
            indegree[b]++; // b 진입차수 기록.
        }

        int[,] elevatorDist = new int[rowSize, colSize]; // 엘레베이터와의 거리.

        (int r, int c) elevatorPos = (-1, -1);
        for (int i = 0; i < rowSize; i++)
        {
            for (int j = 0; j < colSize; j++)
            {
                elevatorDist[i, j] = int.MaxValue;
                if (grid[i][j] == '@')
                    elevatorPos = (i, j);
            }
        }

        Queue<(int r, int c)> queue = new();
        queue.Enqueue((elevatorPos.r, elevatorPos.c));
        elevatorDist[elevatorPos.r, elevatorPos.c] = 0;

        while (queue.Count > 0)
        {
            (int r, int c) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int pr = r + dr[i];
                int pc = c + dc[i];

                if (pr < 0 || pc < 0 || pr >= rowSize || pc >= colSize) continue;

                if (grid[pr][pc] == '#') continue; // 벽이면 못지나감.

                int curDist = elevatorDist[r, c] + 1;
                if (curDist < elevatorDist[pr, pc])
                {
                    queue.Enqueue((pr, pc));
                    elevatorDist[pr, pc] = curDist;
                }
            }
        }

        // 패널끼리의 거리길이.
        int[,] panelDist = new int[panelSize, panelSize];

        for (int i = 0; i < panelSize; i++)
        {
            for (int j = 0; j < panelSize; j++)
            {
                if (i == j) continue; // 서로 같은 패널이면 스킵.

                // r,c 는 0-index로 변환.
                int startFloor = panels[i, 0];
                int startR = panels[i, 1] - 1;
                int startC = panels[i, 2] - 1;

                int endFloor = panels[j, 0];
                int endR = panels[j, 1] - 1;
                int endC = panels[j, 2] - 1;

                if (startFloor != endFloor)
                {
                    // 층이 다르면, (시작위치 => 엘레베이터) + 높이차 + (엘레베이터 => 도착위치) 합.
                    panelDist[i, j] = elevatorDist[startR, startC] + Math.Abs(startFloor - endFloor) + elevatorDist[endR, endC];
                }
                else
                {
                    // 층이 같으면 엘레베이터를 경유하지않으니, BFS로 거리구함.
                    panelDist[i, j] = BFS(startR, startC, endR, endC, grid);
                }
            }
        }

        // [비트, 현재위치] 최소비용.
        int[,] bestCost = new int[1 << panelSize, panelSize];
        for (int i = 0; i < 1 << panelSize; i++)
            for (int j = 0; j < panelSize; j++)
                bestCost[i, j] = int.MaxValue;

        DFS(0, 0, 0, indegree, nextNodes, panelDist, bestCost); // 항상 1번패널부터 시작. 0-index 따라 0으로 변환.

        return answer;
    }

    // 인자: 현재패널번호, 방문 비트마스크, 비용, 진입차수, 위성정렬 다음노드, 패널간의 거리, 비트마스킹경로별 비용
    void DFS(int curPanel, int bitMask, int cost, int[] indegree, List<int>[] nextNodes, int[,] panelDist, int[,] bestCost)
    {
        if (cost >= bestCost[bitMask, curPanel]) return; // 가지치기.
        if (cost >= answer) return;

        bestCost[bitMask, curPanel] = cost;

        if (bitMask == (1 << panelSize) - 1) // 전부 방문시.
        {
            answer = Min(answer, cost);
            return;
        }

        for (int i = 0; i < panelSize; i++)
        {
            if ((bitMask & (1 << i)) == 0 && indegree[i] == 0) // i번 패널이 안켜져있는 상태고, 미리 켜야하는 패널을 다켯거나 없는경우 활성화.
            {
                foreach (var item in nextNodes[i])
                    indegree[item]--; // i번 패널과 연결되어있는 item들 진입차수 -1.

                // curPanel => i 비용 추가하고 i로 전환. 비트마스킹 기록.
                DFS(i, bitMask | (1 << i), cost + panelDist[curPanel, i], indegree, nextNodes, panelDist, bestCost);

                foreach (var item in nextNodes[i])
                    indegree[item]++;
            }
        }

    }

    int BFS(int startR, int startC, int endR, int endC, string[] grid)
    {
        bool[,] visited = new bool[rowSize, colSize];
        Queue<(int r, int c, int cost)> queue = new();
        queue.Enqueue((startR, startC, 0));
        visited[startR, startC] = true;

        while (queue.Count > 0)
        {
            (int r, int c, int cost) = queue.Dequeue();

            if (r == endR && c == endC)
                return cost;

            for (int i = 0; i < 4; i++)
            {
                int pr = r + dr[i];
                int pc = c + dc[i];

                if (pr < 0 || pc < 0 || pr >= rowSize || pc >= colSize) continue;

                if (grid[pr][pc] == '#') continue; // 벽이면 못지나감.

                if (!visited[pr, pc])
                {
                    queue.Enqueue((pr, pc, cost + 1));
                    visited[pr, pc] = true;
                }
            }
        }
        return 0;
    }
}