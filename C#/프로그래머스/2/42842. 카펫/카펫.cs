using System;

public class Solution
{
    public int[] solution(int brown, int yellow)
    {
        for (int y = 1; y <= 2000000; y++) // y가 작은 순부터.
        {
            // yellow = x*y 곱이여야 함.
            if (yellow % y != 0) continue;
            
            int boardX = yellow / y;
            int boardY = y;

            boardX += 2; // 테두리 보정
            boardY += 2;


            int value = boardX * 2 + boardY * 2; // 가로길이*2 + 세로길이*2로 테두리 격자 갯수 구함. 

            value -= 4; // 모서리 두번 더해진거 빼기. (증가한 부분끼리 겹침)

            if (value == brown)
            {
                return new int[2] { boardX, boardY };
            }
        }

        return new int[2] { -1, -1 };
    }
}