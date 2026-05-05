using System;

public class Solution
{
    public int solution(string[] board)
    {
        int o = 0;
        int x = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i][j] == 'O')
                    o++;
                else if (board[i][j] == 'X')
                    x++;
            }
        }

        bool owin = false;
        bool xwin = false;

        for (int y = 0; y < 3; y++) // 가로
        {
            if (board[y] == "OOO")
                owin = true;

            else if (board[y] == "XXX")
                xwin = true;
        }

        int oNumber = 0;
        int xNumber = 0;

        for (int i = 0; i < 3; i++) // 세로
        {
            oNumber = 0;
            xNumber = 0;
            for (int y = 0; y < 3; y++)
            {
                if (board[y][i] == 'O')
                    oNumber++;

                if (board[y][i] == 'X')
                    xNumber++;
            }

            if (oNumber == 3) owin = true;
            else if (xNumber == 3) xwin = true;
        }

        oNumber = 0;
        xNumber = 0;

        for (int i = 0; i < 3; i++) // \ 모양 체크
        {
            if (board[i][i] == 'O')
                oNumber++;

            if (board[i][i] == 'X')
                xNumber++;

            if (oNumber == 3) owin = true;
            else if (xNumber == 3) xwin = true;
        }

        oNumber = 0;
        xNumber = 0;

        for (int i = 0; i < 3; i++) // /모양 체크
        {
            if (board[i][2 - i] == 'O')
                oNumber++;

            if (board[i][2 - i] == 'X')
                xNumber++;

            if (oNumber == 3) owin = true;
            else if (xNumber == 3) xwin = true;
        }


        if (o > x + 1) // 선공이 후공보다 2개이상 많은 경우 불가능.
            return 0;

        if (x > o) // 후공갯수가 더많은 상황은 불가능.
            return 0;

        if (owin && xwin) // 선공 후공 둘다 이기는 상황도 불가능. 한쪽이 이기면 게임이 끝남.
            return 0;

        if (owin && o - 1 != x) // o가 이겼으면 o가 x보다 딱 1개 많아야함. 그렇지 않으면 이상.
            return 0;

        if (xwin && o != x) // x가 이겼으면 o == x여야함. 다르면 이상.
            return 0;

        return 1;
    }
}