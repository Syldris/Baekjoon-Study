using System;
using System.Collections.Generic;
public class Solution
{
    int n;
    int[] choiceA;
    int[] choiceB;
    int[] answer;

    int maxWin = -1;

    List<int> diceA = new List<int>();
    List<int> diceB = new List<int>();

    public int[] solution(int[,] dice)
    {
        n = dice.GetLength(0);

        choiceA = new int[n / 2];
        choiceB = new int[n / 2];
        answer = new int[n / 2];

        // 풀이상 시간이 좀 아슬할거같다.
        // 주사위 10개 기준 5개 선택하면 주사위 수가 7776개 나오고.
        // 7776개를 b랑 비교해서 이탐으로 몇개 이기는지 확인하는데 정렬+ 이탐.
        // 이탐시간이 7776 x log2(7776) ~= 100000 쯤이다. 정렬도 nlogN으로 10만쯤.
        // 10개중에서 5개 고르는 조합은
        // 10개 9개 8개 7개 6개 중 1개 고르고 순서에 상관없으니 순서 5! 나눠주면 252개.
        // 5040만 정도 나올듯하다.

        DFS(0, 0, dice);

        return answer;
    }

    void DFS(int num, int depth, int[,] dice)
    {
        if (depth == n / 2) // n/2개 고르면 끝.
        {
            diceA.Clear();
            diceB.Clear();

            int index = 0;
            for (int i = 1; i <= n; i++)
            {
                if (!choiceA.Contains(i)) // A에 포함 안된 주사위라면
                {
                    choiceB[index] = i; // 자동으로 B가 가져가게 됨.
                    index++;
                }
            }

            Search(0, 0, choiceA, diceA, dice); // A 주사위 조합 리스트 생성.
            Search(0, 0, choiceB, diceB, dice); // B 주사위 조합 리스트 생성.

            diceB.Sort(); // B 주사위 정렬.

            int win = 0;
            for (int i = 0; i < diceA.Count; i++) // A가 더 큰 경우만 승리. (lower Bound). 
            {
                int value = diceA[i];

                int start = 0;
                int end = diceB.Count;

                while (start < end)
                {
                    int mid = (start + end) / 2;

                    if (value > diceB[mid]) // value가 더크면 오른쪽으로 이동.
                    {
                        start = mid + 1;
                    }
                    else // value == diceB 라면 기준선을 왼쪽으로
                    {
                        end = mid;
                    }
                }

                // start = value 값 이상인 첫 인덱스
                // start가 3번 인덱스라면 value가 0~2 3개보다 큼.

                win += start; // 이분탐색으로 B조합을 이긴 갯수 더해주기.
            }

            if (win > maxWin)
            {
                maxWin = win;
                answer = (int[])choiceA.Clone();
            }

            return;
        }

        // 이전 주사위는 num번일떄 현재 주사위는 num+1~N번까지 택하는 경우를 모두 탐색.
        // (1,2 1,3 1,4 2,3 2,4 3,4) 식으로 이전보다 높은 주사위를 골라 완탐.
        // ex) 2번 주사위라면 1번주사위 와 2번주사위 조합이 이미 있으니 중복을 막기위해 탐색 3번부터 시작.

        for (int i = num + 1; i <= n; i++)
        {
            choiceA[depth] = i; // depth번 주사위는 i번으로 결정.
            DFS(i, depth + 1, dice);
        }
    }

    void Search(int depth, int value, int[] choice, List<int> diceList, int[,] dice)
    {
        if (depth == n / 2)
        {
            diceList.Add(value);
            return;
        }

        for (int i = 0; i < 6; i++)
        {
            int index = choice[depth] - 1; // x번째 고른 주사위. ( 1-index => 0-index)

            // index번 주사위 에서 6개 눈 전부 완탐.
            Search(depth + 1, value + dice[index, i], choice, diceList, dice);
        }
    }
}