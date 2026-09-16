using System;
using static System.Math;
public class Solution
{
    public int[] solution(string[] wallpaper)
    {
        int[] answer = new int[] { };

        int leftRow = int.MaxValue, leftCol = int.MaxValue;
        int rightRow = -1, rightCol = -1;

        // 드래그로 완전히 칸을 포함해야하니 상하좌우 끝점을 구해서 모두 포함하자.
        // [r,c]칸의 왼쪽 위점이 r,c 오른쪽 아래점이 r+1,c+1 이다.
        // 왼쪽과 위는 r,c 오른쪽과 아래는 r+1,c+1 를 써서 점으로 파일공간을 감싸자.

        for (int i = 0; i < wallpaper.Length; i++)
        {
            for (int j = 0; j < wallpaper[i].Length; j++)
            {
                if (wallpaper[i][j] == '#')
                {
                    leftRow = Min(leftRow, i);
                    leftCol = Min(leftCol, j);

                    rightRow = Max(rightRow, i);
                    rightCol = Max(rightCol, j);
                }
            }
        }

        return new int[4] { leftRow, leftCol, rightRow + 1, rightCol + 1 };
    }
}