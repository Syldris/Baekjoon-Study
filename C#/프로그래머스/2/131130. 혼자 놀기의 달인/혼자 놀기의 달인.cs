using System;
using System.Collections.Generic;

public class Solution
{
    public int solution(int[] cards)
    {
        int n = cards.Length;
        int[] score = new int[n]; // i번째 상자의 상자그룹속 상자 갯수. 

        List<int> group = new List<int>(); // 상자그룹 리스트 저장.
        List<int> scoreList = new List<int>(); // 상자그룹의 상자 갯수를 등록.

        // 사실상 생각해보면 상자그룹끼리 겹칠일은 없다.
        // 그래프 관계로 생각해봐도 상자 안 원소가 중복되지않는 제한이 있다면 ([3,3,1] 같은 경우가 없음) 
        // 진입/탈출 간선이 1개씩 있는 싸이클 간선이다.
        // 상자그룹을 처음 만들때 자기 자신까지 돌아올때까지 반복하는데,
        // 자기 자신을 제외하곤 이미 열린 상자를 만날수 없다는 소리다.

        for (int i = 0; i < n; i++)
        {
            cards[i]--; // 1-index => 0-index
        }

        for (int i = 0; i < n; i++)
        {
            if (score[i] == 0) // 0개면 이상자는 상자그룹에 아직 안속해졌으니 이제부터 구함.
            {
                int value = 1;

                group.Add(i);
                int index = cards[i];
                while (index != i) // 본인 상자까지 찾아감 
                {
                    group.Add(index);
                    index = cards[index];
                    value++;
                }

                foreach (var item in group)
                {
                    score[item] = value;
                }

                scoreList.Add(value);
                group.Clear();

            }
        }

        if (scoreList.Count == 1) return 0; // 그룹 1개면 0점 

        scoreList.Sort((a,b) => b.CompareTo(a)); // 내림차순. 음수나 같으면 냅두고 양수면 바꾸는데 2 5면 원래 2-5로 음수로 2가 앞인데
        // 5-2로 양수로 만들어서 5가 앞으로 오게한다. 반대같은 경우에도 5-2 로 3이라 양수로 바꿔야하는데 2-5로 음수라 냅둔다.

        return scoreList[0] * scoreList[1];
    }
}