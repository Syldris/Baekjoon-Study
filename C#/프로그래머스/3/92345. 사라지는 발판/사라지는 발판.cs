using System;
using System.Collections.Generic;
using static System.Math;
public class Solution
{
    (int r, int c) aPos;
    (int r, int c) bPos;

    public int solution(int[,] board, int[] aloc, int[] bloc)
    {
        int answer = 0;

        aPos = (aloc[0], aloc[1]);
        bPos = (bloc[0], bloc[1]);

        answer = DFS(true, board);

        return answer;
    }

    int[] dr = { -1, 1, 0, 0 };
    int[] dc = { 0, 0, -1, 1 };

    int DFS(bool aMoveTurn, int[,] board)
    {
        int turn = 0;

        int r = aMoveTurn ? aPos.r : bPos.r;
        int c = aMoveTurn ? aPos.c : bPos.c;

        if (board[r, c] == 0) // 내 아래 발판이 무너져있으면 바로 종료.
            return 0;

        List<int> moveTurn = new();

        for (int i = 0; i < 4; i++)
        {
            int pr = r + dr[i];
            int pc = c + dc[i];

            if (pr < 0 || pc < 0 || pr >= board.GetLength(0) || pc >= board.GetLength(1)) continue;

            if (board[pr, pc] == 0) continue; // 발판없으면 이동불가. 

            board[r, c] = 0; // 이동하면 이동전 발판은 사라짐.

            if (aMoveTurn) aPos = (pr, pc);
            else bPos = (pr, pc);

            turn = DFS(!aMoveTurn, board) + 1;

            board[r, c] = 1; // 이동전 상황 발판으로 되돌림.
            if (aMoveTurn) aPos = (r, c);
            else bPos = (r, c);

            moveTurn.Add(turn);
        }

        int winTurn = int.MaxValue;
        int loseTurn = 0;

        for (int i = 0; i < moveTurn.Count; i++)
        {
            if (moveTurn[i] % 2 == 0) // 진 경우 최대한 턴을 끌면서 패배하는게 최선.
                loseTurn = Max(loseTurn, moveTurn[i]);
            else                     // 이기는 경우 최대한 빠르게 턴을 끝내는게 최선.
                winTurn = Min(winTurn, moveTurn[i]);
        }

        return winTurn != int.MaxValue ? winTurn : loseTurn; // 이길수있으면 이기는턴, 지면 지는턴 반환
    }
}