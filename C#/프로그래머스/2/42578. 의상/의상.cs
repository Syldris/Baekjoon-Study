using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(string[,] clothes)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>(); // [종류] = 갯수

        int n = clothes.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            string name = clothes[i, 0];
            string set = clothes[i, 1];

            if (!dict.ContainsKey(set))
                dict.Add(set, 1);
            else
                dict[set]++;
        }

        int answer = 1; // 곱셈 항등원으로 시작.

        foreach (var item in dict)
        {
            // 한 종류에 2가지 옷이 있다면
            // 안입는경우, 1번옷, 2번옷 총3개의 경우가 있다.
            // 즉 n개옷일때 안입음(1) + 각 옷 하나씩 착용(n)개 만큼 선택지가 있다.

            // 종류마다 선택지 갯수만큼 곱해주면 경우의 수가 나온다.
            answer *= item.Value + 1;
        }

        answer--; // 모든 종류에서 아무것도 안입는 경우는 빼야함.

        return answer;
    }
}