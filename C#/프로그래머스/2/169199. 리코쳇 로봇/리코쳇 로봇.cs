using System;
using System.Collections.Generic;
public struct Node // 각 노드에서 얼음길처럼 움직였을때 멈추는 위치.
{
    public (int, int) leftMovePos;
    public (int, int) rightMovePos;
    public (int, int) upMovePos;
    public (int, int) downMovePos;

    public Node((int, int) left, (int, int) right, (int, int) up, (int, int) down)
    {
        leftMovePos = left;
        rightMovePos = right;
        upMovePos = up;
        downMovePos = down;
    }
}

public class Solution
{
    public int solution(string[] board)
    {
        int lenX = board[0].Length;
        int lenY = board.Length;

        Node[,] nodeList = new Node[lenX, lenY];

        int[,] visited = new int[lenX, lenY];

        int[] dx = new int[4] { -1, 1, 0, 0 };
        int[] dy = new int[4] { 0, 0, -1, 1 };

        (int x, int y) startPos = (0, 0);
        (int x, int y) endPos = (0, 0);

        // 매번 위치에서 탐색하는 대신 그냥 1번씩 미리 이동위치 기록.
        for (int y = 0; y < lenY; y++)
        {
            for (int x = 0; x < lenX; x++)
            {
                if (board[y][x] == 'R')
                    startPos = (x, y);

                else if (board[y][x] == 'G')
                    endPos = (x, y);

                else if (board[y][x] == 'D') // 벽이면 계산 안해도 됨.
                    continue;

                visited[x, y] = int.MaxValue;

                for (int i = 0; i < 4; i++) // l r u d 순서로
                {
                    int px = x;
                    int py = y;

                    // 0 미만 이거나 x y 이상이면 종료. 해당위치가 D여도 종료.
                    while (true)
                    {
                        px += dx[i];
                        py += dy[i];

                        if (px < 0 || px >= lenX || py < 0 || py >= lenY || board[py][px] == 'D')
                        {
                            // 범위를 벗어나거나 벽에 다다르면 1칸 되돌리고 종료.
                            px -= dx[i];
                            py -= dy[i];
                            break;
                        }

                    }

                    //  이동할수 있는 상하좌우 위치기록.
                    if (i == 0)
                        nodeList[x, y].leftMovePos = (px, py);
                    else if (i == 1)
                        nodeList[x, y].rightMovePos = (px, py);
                    else if (i == 2)
                        nodeList[x, y].upMovePos = (px, py);
                    else
                        nodeList[x, y].downMovePos = (px, py);
                }
            }
        }

        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();

        // 시작점 넣기
        queue.Enqueue((startPos));
        visited[startPos.x, startPos.y] = 0;

        while (queue.Count > 0)
        {
            (int x, int y) = queue.Dequeue();

            if (x == endPos.x && y == endPos.y)
            {
                return visited[x, y];
            }

            (int x, int y) leftPos = nodeList[x, y].leftMovePos;
            (int x, int y) rightPos = nodeList[x, y].rightMovePos;
            (int x, int y) upPos = nodeList[x, y].upMovePos;
            (int x, int y) downPos = nodeList[x, y].downMovePos;

            if (visited[x, y] + 1 < visited[leftPos.x, leftPos.y]) // 좌
            {
                queue.Enqueue(leftPos);
                visited[leftPos.x, leftPos.y] = visited[x, y] + 1;
            }

            if (visited[x, y] + 1 < visited[rightPos.x, rightPos.y]) // 우
            {
                queue.Enqueue(rightPos);
                visited[rightPos.x, rightPos.y] = visited[x, y] + 1;
            }

            if (visited[x, y] + 1 < visited[upPos.x, upPos.y]) // 상
            {
                queue.Enqueue(upPos);
                visited[upPos.x, upPos.y] = visited[x, y] + 1;
            }

            if (visited[x, y] + 1 < visited[downPos.x, downPos.y]) // 하
            {
                queue.Enqueue(downPos);
                visited[downPos.x, downPos.y] = visited[x, y] + 1;
            }
        }

        return -1;
    }
}