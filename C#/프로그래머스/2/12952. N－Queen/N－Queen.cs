using System;

public class Solution
{
    int answer = 0;
    int n;

    bool[] col; // 같은 세로줄에 퀸이 있는지?
    bool[] diag1; // '/' 모양 대각선에 퀸이 있는지?
    bool[] diag2;  // '\' 모양 대각선에 퀸이 있는지?

    public int solution(int n)
    {
        this.n = n;
        col = new bool[n]; // 체스판에 세로줄은 N개 존재.
        diag1 = new bool[n * 2 - 1]; // N*N 체스판에서 대각선 갯수는 N*2 -1 개.
        diag2 = new bool[n * 2 - 1];

        NQueen(0);

        return answer;
    }

    void NQueen(int row) // N길이 가로줄마다 1개씩 둬서 퀸 N 개를 두자.
    {
        if (row == n) // N개의 퀸을 놓았다면 조건만족 성공이니 경우수+1
        {
            answer++;
            return;
        }

        for (int i = 0; i < n; i++) // r,c 기준 [row,i] 위치에 퀸 배치.
        {
            int diagIndex1 = row + i; // 좌상단을 0으로 / 모양대각선 행 증가 +1 열 증가 +1.
            int diagIndex2 = n - 1 - row + i; // 좌하단을 0으로 \ 모양대각선 행 증가 -1 열 증가 +1

            if (col[i] || diag1[diagIndex1] || diag2[diagIndex2]) // 이미 이전 퀸과 서로 공격위치가 겹치면 못둠.
                continue;

            col[i] = true; // row 행 i열에 퀸 배치
            diag1[diagIndex1] = true; // 각대각선에 퀸 공격위치 기록.
            diag2[diagIndex2] = true;

            NQueen(row + 1); // 둘수있다면 두자.

            // 백트래킹 회수. [row,i] 퀸을 다시 빼자. 

            col[i] = false;
            diag1[diagIndex1] = false;
            diag2[diagIndex2] = false;
        }
    }

}