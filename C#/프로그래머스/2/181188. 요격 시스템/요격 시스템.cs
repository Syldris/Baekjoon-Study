using System;

public struct Node
{
    public int start;
    public int end;

    public Node(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}

public class Solution
{
    public int solution(int[,] targets)
    {
        int answer = 0;

        int n = targets.GetLength(0);
        Node[] node = new Node[n];
        
        for (int i = 0; i < n; i++)
        {
            node[i] = new Node(targets[i, 0], targets[i, 1]);
        }

        // 시작점 기준으로 정렬후 스와핑 사용하면 될듯
        Array.Sort(node, (a, b) => a.start.CompareTo(b.start));

        // 0번 폭격에서 시작.
        int start = node[0].start;
        int end = node[0].end;

        for (int i = 1; i < n; i++)
        {
            int curStart = node[i].start;
            int curEnd = node[i].end;

            if (curStart >= end) // 현재 시작점이 이전 끝점보다 뒤에있으면 전부 격추.
            {
                answer++;
                end = curEnd; // 다시 새 end로 시작.
            }
            else
                end = Math.Min(end, curEnd); // 폭격 집합중에서 가장 빨리끝나는것을 골라 놓치지 않고 격추해야함.
        }

        answer++; // 마지막 남은 1개 집합도 전부 격추.

        return answer;
    }
}