using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(string[] friends, string[] gifts)
    {
        int answer = 0;
        int n = friends.Length;

        // [이름] => 번호 매핑
        Dictionary<string, int> dict = new Dictionary<string, int>();
        for (int i = 0; i < n; i++)
        {
            dict[friends[i]] = i;
        }

        int[,] gift = new int[n, n]; // [a, b] = a가 b에게 준 선물 갯수. 
        int[] giftPoint = new int[n]; // 해당 인원의 선물 점수

        for (int i = 0; i < gifts.Length; i++)
        {
            string[] split = gifts[i].Split();

            int from = dict[split[0]];
            int to = dict[split[1]];

            gift[from, to] += 1; // from이 to에게 1개 선물.

            giftPoint[from]++;
            giftPoint[to]--;
        }

        int maxGift = 0;

        for (int i = 0; i < n; i++)
        {
            int value = 0;
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;

                if (gift[i, j] > gift[j, i]) // 내가 준게 더 많다면 하나 받음
                    value++;
                else if (gift[i, j] == gift[j, i] && giftPoint[i] > giftPoint[j]) // 서로 주고받은 선물갯수가 같을때, 선물 점수가 더 높다면 하나 받음.
                    value++;

            }

            if (value > answer)
                answer = value;
        }

        return answer;
    }
}