using System;

public class Solution
{
    int[] answer = new int[2];
    int[] sale;
    int n = 0;
    public int[] solution(int[,] users, int[] emoticons)
    {
        n = emoticons.Length;
        sale = new int[n];

        BackTrack(0, users, emoticons);

        return answer;
    }

    void BackTrack(int depth, int[,] users, int[] emoticons)
    {
        if (depth == n)
        {
            int plusPeople = 0; // 이모티콘 플러스 가입자 수(1순위)
            int value = 0; // 이모티콘 판매액(2순위)

            for (int i = 0; i < users.GetLength(0); i++)
            {
                int ratio = users[i, 0]; // 세일이 ratio 비율 이상이면 이모티콘 전부 구입.
                int money = users[i, 1]; // 총합 가격이 money 이상이라면 이모티콘 플러스에 가입.

                int totalCost = 0; // 현재 구입 비용.

                for (int j = 0; j < n; j++)
                {
                    if (sale[j] >= ratio)
                    {
                        // 이모티콘은 100원 단위.
                        totalCost += (emoticons[j] / 100) * (100 - sale[j]); 
                    }
                }

                if (totalCost >= money)
                    plusPeople++;
                else
                    value += totalCost;
            }

            if (plusPeople > answer[0]) // 가입자 늘리기 가능한 경우.
            {
                answer[0] = plusPeople;
                answer[1] = value;
            }
            else if (plusPeople == answer[0] && value > answer[1]) // 가입자는 같은데 수익을 더올릴수 있는 경우.
            {
                answer[1] = value;
            }
            return;
        }

        for (int i = 10; i <= 40; i += 10) // 해당 이모지의 할인률.
        {
            sale[depth] = i;
            BackTrack(depth + 1, users, emoticons);
        }
    }
}