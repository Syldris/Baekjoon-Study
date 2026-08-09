using System;
using System.Collections.Generic;

public class Solution
{
    public int[] solution(string[] enroll, string[] referral, string[] seller, int[] amount)
    {
        int n = enroll.Length;
        int[] answer = new int[n];
        
        Dictionary<string, int> dict = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            dict.Add(enroll[i], i);
        }

        dict.Add("-", -1); // - 빈칸은 -1로 설정.

        int[] parent = new int[n]; // 추천인. 그래프상 부모 위치
        for (int i = 0; i < n; i++)
        {
            int parentIndex = dict[referral[i]];
            parent[i] = parentIndex;
        }

        for (int i = 0; i < seller.Length; i++)
        {
            int index = dict[seller[i]];
            int money = amount[i] * 100;

            DFS(index, money, parent, answer);
        }

        return answer;
    }

    void DFS(int index, int money, int[] parent, int[] answer)
    {
        int mlmMoney = money / 10;
        answer[index] += money - mlmMoney;

        if (parent[index] != -1)
        {
            DFS(parent[index], mlmMoney, parent, answer);
        }
    }
}