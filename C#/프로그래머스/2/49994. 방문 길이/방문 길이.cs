using System;

public class Solution
{
    public int solution(string dirs)
    {
        int answer = 0;

        int x = 5;
        int y = 5; // 시작 지점 기준으로 +5칸 보드로 11x11 이동가능.
        bool[,,] board = new bool[11, 11, 4]; // 칸마다 4개길을 가지고 있다. 이걸로 방문여부 체크.

        // U D L R | 0 1 2 3 순서로 생각하자.

        foreach (char c in dirs)
        {
            if (c == 'U' && y < 10)
            {
                if (!board[x, y, 0]) answer++; // 위로 가는길 가본적 없다면 안가본길 +1

                board[x, y, 0] = true; // 가기 전에 위쪽으로 가는길은 체크.
                y++;
                board[x, y, 1] = true; // 간 후에 아래쪽에서 왔으니 이거도 체크.
            }
            else if (c == 'D' && y > 0)
            {
                if (!board[x, y, 1]) answer++;

                board[x, y, 1] = true; // 아래로 이동 체크.
                y--;
                board[x, y, 0] = true; // 위쪽에서 왔으니 체크.
            }
            else if (c == 'L' && x > 0)
            {
                if (!board[x, y, 2]) answer++;

                board[x, y, 2] = true; // 왼쪽 이동 체크.
                x--;
                board[x, y, 3] = true; // 오른쪽에서 왔음 체크.
            }
            else if (c == 'R' && x < 10)
            {
                if (!board[x, y, 3]) answer++;

                board[x, y, 3] = true; // 오른쪽 이동 체크.
                x++;
                board[x, y, 2] = true; // 왼쪽에서 왔음 체크.
            }
        }

        return answer;
    }
}