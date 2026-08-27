using System;
using System.Collections.Generic;
public class Solution
{
    int answer = 0;
    int n;
    long l, r;

    List<(int number, long index)> list = new List<(int number, long index)>();

    public int solution(int n, long l, long r)
    {
        this.n = n;
        this.l = l;
        this.r = r;

        // 번호, 인덱스
        list.Add((1, 1));

        // 각 칸토어 비트열마다 필요한 구간만 펼쳐 최적화.
        long[,] interval = new long[n + 1, 2];
        interval[n, 0] = l;
        interval[n, 1] = r;

        for (int i = n - 1; i >= 0; i--)
        {
            interval[i, 0] = (interval[i + 1, 0] + 4) / 5;
            interval[i, 1] = (interval[i + 1, 1] + 4) / 5;
        }

        DFS(0, interval);

        return answer;
    }

    // 번호마다 변환되는 수
    int[] zero = new int[5];
    int[] one = new int[5] { 1, 1, 0, 1, 1 };

    void DFS(int depth, long[,] interval)
    {
        if (depth == n)
        {
            foreach ((int number, long index) in list)
            {
                if (index < l) continue; // 왼쪽구간보다 작으면 스킵.
                if (index > r) break; // 오른쪽 구간보다 크면 끝.

                if (number == 1) answer++;
            }
            return;
        }

        List<(int number, long index)> nextList = new List<(int number, long index)>();

        foreach ((int number, long index) in list)
        {
            if (index < interval[depth, 0]) continue; // 왼쪽구간보다 작으면 스킵.
            if (index > interval[depth, 1]) break; // 오른쪽 구간보다 크면 끝.

            long nextIndex = (index - 1) * 5 + 1;

            if (number == 0)
                for (int i = 0; i < 5; i++)
                    nextList.Add((zero[i], nextIndex + i));
            else
                for (int i = 0; i < 5; i++)
                    nextList.Add((one[i], nextIndex + i));
        }

        list.Clear();
        list = nextList;

        DFS(depth + 1, interval);
    }
}