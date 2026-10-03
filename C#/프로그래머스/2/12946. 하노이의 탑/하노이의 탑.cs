using System;
using System.Collections.Generic;
using static System.Math;
public class Solution
{
    List<(int from, int to)> list = new List<(int, int)>();

    public int[,] solution(int n)
    {
        Solve(n, 1, 3);

        int[,] answer = new int[list.Count, 2];

        for (int i = 0; i < list.Count; i++)
        {
            answer[i, 0] = list[i].from;
            answer[i, 1] = list[i].to;
        }

        return answer;
    }

    void Solve(int n, int start, int target) // 현재 움직일 원판, 현재 위치, 도착 위치
    {
        int subTarget = 6 - (start + target); // n번 원판이 1 => 3번으로 간다면, 그 위에있는 1~n-1 원판은 2번으로 가야한다.

        if (n > 1) Solve(n - 1, start, subTarget); // 1~n-1번 원판을 목표위치 말고 다른 탑에 걸자.
        list.Add((start, target)); // n번 원판을 목표위치로.
        if (n > 1) Solve(n - 1, subTarget, target); // 다른 탑에 걸어둔 원판 목표위치로 이동.
    }
}