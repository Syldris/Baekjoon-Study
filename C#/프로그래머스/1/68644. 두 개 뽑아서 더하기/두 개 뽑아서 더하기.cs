using System;
using System.Collections.Generic;
using System.Linq;
public class Solution
{
    public int[] solution(int[] numbers)
    {
        List<int> answer = new List<int>();

        int n = numbers.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;
                answer.Add(numbers[i] + numbers[j]);
            }
        }

        return answer.Distinct().OrderBy(x => x).ToArray(); // 중복 제거 & 오름차순 정렬
    }
}