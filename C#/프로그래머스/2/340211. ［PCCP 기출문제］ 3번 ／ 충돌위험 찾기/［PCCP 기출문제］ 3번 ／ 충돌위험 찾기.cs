using System;
using System.Collections.Generic;

public struct Node
{
    public bool visited;
    public bool crash;

    public Node(bool visited, bool crash)
    {
        this.visited = visited;
        this.crash = crash;
    }
}

public class Solution
{
    int answer = 0;
    Node[,,] board = new Node[101, 101, 20000]; // x, y, 노드에 대한 방문시점.

    public int solution(int[,] points, int[,] routes)
    {
        int n = routes.GetLength(0); // 로봇갯수
        int len = routes.GetLength(1); // 로봇 운송길이.

        for (int i = 0; i < n; i++)
        {
            // i = 로봇번호. j = i번 로봇이 j번째로 향할 노드.
            // points[node,1] = x, 0은 y.
            // 1-index => 0-index

            int x = points[routes[i, 0] - 1, 1];
            int y = points[routes[i, 0] - 1, 0];

            int visitedTime = 0;

            Visited(x, y, visitedTime);

            for (int j = 1; j < len; j++)
            {
                int px = points[routes[i, j] - 1, 1];
                int py = points[routes[i, j] - 1, 0];

                while (y < py)
                {
                    y++;
                    visitedTime++;
                    Visited(x, y, visitedTime);
                }
                while (y > py)
                {
                    y--;
                    visitedTime++;
                    Visited(x, y, visitedTime);
                }
                while (x < px)
                {
                    x++;
                    visitedTime++;
                    Visited(x, y, visitedTime);
                }
                while (x > px)
                {
                    x--;
                    visitedTime++;
                    Visited(x, y, visitedTime);
                }
            }
        }
        return answer;
    }

    public void Visited(int x, int y, int visitedTime)
    {
        if (board[x, y, visitedTime].visited && !board[x, y, visitedTime].crash) // 방문한 상태 + 충돌 X일때 충돌판정.
        {
            board[x, y, visitedTime].crash = true;
            answer++;
        }
        else if (!board[x, y, visitedTime].visited) // 미방문 상태면 방문체크.
        {
            board[x, y, visitedTime].visited = true;
        }
    }
}