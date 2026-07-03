using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int coin, int[] cards)
    {
        int pairCard = 0; // 2장으로 맞춘 카드짝 갯수

        // 카드 2장을 써서 N+1이 되도록 내고 진행하는데,
        // 각 원소가 중복되지않는 수열 1~n이니 
        // 항상 원소 x에 대해서 n+1이 되게끔 하는 수는 1개일것이다. (n = 13 일때 x = 6 이면 만족하는수 오로지 7뿐.)
        // 고로 코인을 적게쓰면서 넘어가게끔 하려면 0개짜리 카드부터 소모하면서 진행하면 된다.

        // 0 + 0 코인 카드는 처음에 미리 받아 제출하고
        // 0 + 1 카드는 조합 가능하면 항상 조합.
        // 1 + 1 카드는 위에서 전부 불가능할때 1번 만들고 다음라운드로 넘어가 추가 2장까지 보면서 0+1카드부터 만드려고 하자.

        int n = cards.Length;

        bool[] freeCard = new bool[n + 1]; // 처음 주는 무료 카드 기록.
        bool[] hoding = new bool[n + 1]; // 들고있는 카드.

        for (int i = 0; i < n / 3; i++) // 카드 1/3를 무료 소지.
        {
            int num = cards[i];
            freeCard[num] = true;

            if (freeCard[n + 1 - num]) // num과 합해서 n+1 이 되게끔 하는 카드가 앞에 있었다면 2장을 미리 제출하자.
            {
                freeCard[n + 1 - num] = false;
                freeCard[num] = false;
                pairCard++;
            }
        }

        // 1코인 2장짜리 카드 페어.
        Queue<(int, int)> twoCoinCardPair = new Queue<(int, int)>();

        // 1라운드 부터 시작.
        int answer = 1;

        for (int i = n / 3; i < n; i += 2)
        {
            int card1 = cards[i];
            int card2 = cards[i + 1];

            hoding[card1] = true;
            hoding[card2] = true;

            if (freeCard[n + 1 - card1] && coin >= 1) // 무료카드랑 해서 0+1 코인으로 카드페어 완성. (언제든지 만들어도 이득)
            {
                freeCard[n + 1 - card1] = false;
                hoding[card1] = false;

                pairCard++;
                coin--;
            }

            if (freeCard[n + 1 - card2] && coin >= 1)
            {
                freeCard[n + 1 - card2] = false;
                hoding[card2] = false;

                pairCard++;
                coin--;
            }

            if (hoding[n + 1 - card1]) // 1+1 코인 쌍 카드페어 큐에 미리 기록.(먼저 만들기 X. 1번 쓰고 다음 카드쌍 체크.)
            {
                twoCoinCardPair.Enqueue((card1, n + 1 - card1));
            }
            if (hoding[n + 1 - card2])
            {
                twoCoinCardPair.Enqueue((card2, n + 1 - card2));
            }

            if (pairCard == 0 && twoCoinCardPair.Count > 0 && coin >= 2) // 남은 카드쌍이 없고 1+1 카드쌍만 가능할때 코인2장을 써서 1쌍 완성.
            {
                (int a, int b) = twoCoinCardPair.Dequeue();
                hoding[a] = false;
                hoding[b] = false;

                pairCard++;
                coin -= 2;
            }

            if (pairCard > 0) // 카드 짝이 있다면 제출 후 진행 가능.
            {
                pairCard--;
                answer++;
            }
            else
                break;
        }

        return answer;
    }
}