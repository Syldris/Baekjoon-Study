using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(string begin, string target, string[] words)
    {
        int endPos = -1; // words에 있는 target 지점

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == target)
            {
                endPos = i + 1;
                break;
            }
        }

        // 시작과 끝이 같지않고 words에 있는단어로만 이동가능하니 target이 words에 있어야함.
        if (endPos == -1)
            return 0;

        // 0번이 시작begin. words부터 1~n
        List<int>[] graph = new List<int>[words.Length + 1];

        for (int i = 0; i <= words.Length; i++)
            graph[i] = new List<int>();

        int len = begin.Length; // 모든 문자열의 길이는 같으니 이거로 비교.

        for (int i = 0; i < words.Length; i++)
        {
            int diff = 0;

            for (int k = 0; k < len; k++)
            {
                if (begin[k] != words[i][k])
                {
                    diff++;
                    if (diff > 1) break; // 조기종료.
                }
            }

            // 차이가 1글자 이하일때만 begin => i로 변환 가능.
            // i => begin 은 무의미 하니 저장안해도 될듯.
            if (diff <= 1)
                graph[0].Add(i + 1);
        }


        // i <=> j 끼리 1번씩만 비교하면 되니 이전에 비교된 i와 비교할 필요 X
        for (int i = 0; i < words.Length - 1; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                int diff = 0;

                for (int k = 0; k < len; k++)
                {
                    if (words[i][k] != words[j][k])
                    {
                        diff++;
                        if (diff > 1) break;
                    }
                }

                if (diff <= 1) // 1글차 차이 이하니
                {
                    // i <=> j 양방향 연결. 
                    graph[i + 1].Add(j + 1);
                    graph[j + 1].Add(i + 1);
                }
            }
        }

        int[] visited = new int[words.Length + 1];
        Array.Fill(visited, int.MaxValue);

        visited[0] = 0;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();

            if (node == endPos)
            {
                return visited[node];
            }

            foreach (var next in graph[node])
            {
                if (visited[node] + 1 < visited[next])
                {
                    visited[next] = visited[node] + 1;
                    queue.Enqueue(next);
                }
            }
        }

        // 연결 못함.
        return 0;
    }
}