using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Solution
{
    int answer = 0;
    int n = 0;

    int open = 0; // 여는 괄호 갯수.
    int close = 0; // 닫는 괄호 갯수.

    public int solution(int n)
    {
        this.n = n;

        BackTrack(0);

        return answer;
    }

    void BackTrack(int depth)
    {
        if (close > open) // 어느 순간에도 닫는 괄호가 여는 괄호보다 많으면 안됨.
        {
            return;
        }

        if (depth == n * 2)
        {
            if (open == close) // 여는 괄호와 닫는 괄호 갯수가 같아야 괄호 문자열.
                answer++;
            return;
        }

        // 여는 괄호
        open++;
        BackTrack(depth + 1);
        open--; // 다시 회수

        // 닫는 괄호
        close++;
        BackTrack(depth + 1);
        close--; // 백트래킹이니 다시 회수하기.
    }
}