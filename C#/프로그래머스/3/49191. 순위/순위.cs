using System;

public class Solution
{
    public int solution(int n, int[,] results)
    {
        int answer = 0;

        bool[,] graph = new bool[n, n];

        for (int i = 0; i < results.GetLength(0); i++)
        {
            int a = results[i, 0] - 1;
            int b = results[i, 1] - 1;

            // a랑 b랑 결과가 나옴.
            graph[a, b] = true;
        }


        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue;

                    // i > k 며 k > j 라면 i > j 
                    if (graph[i, k] && graph[k, j])
                    {
                        graph[i, j] = true;
                    }
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            int value = 0;
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;

                // i가 j를 이기거나 j가 i를 이겨 i가 이김/패배 결과가 나온다면
                if (graph[i, j] || graph[j, i])
                {
                    // 상대적 결과를 알수잇음
                    value++;
                }
            }

            // 본인 제외하고 모두와 승부 결과를 알수있다면 순위 측정가능.
            if (value == n - 1)
                answer++;
        }


        return answer;
    }
}