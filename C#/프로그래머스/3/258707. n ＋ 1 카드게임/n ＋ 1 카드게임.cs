using System;
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

        // 1라운드 부터 시작.
        int answer = 1;

        for (int i = n / 3; i < n; i += 2)
        {
            int card1 = cards[i];
            int card2 = cards[i + 1];

            hoding[card1] = true;
            hoding[card2] = true;

            if (pairCard == 0) // 카드 쌍 0장 되면 보충.
            {
                for (int j = 1; j <= n; j++)
                {
                    if (coin == 0) break; // 코인 1개짜리는 코인0개될때까지 멈추지않고 사도 될거같다.(2개 짜리보다 항상 이득.)

                    if (freeCard[j] && hoding[n + 1 - j]) // 무료카드 + 지금까지 가져올수 있었던 1코인 카드 1장.
                    {
                        freeCard[j] = false;
                        hoding[n + 1 - j] = false;

                        coin--;
                        pairCard++;
                    }
                }

                if (pairCard == 0 && coin >= 2) // 위에서 무료 카드 1장 포함 카드쌍을 못채운상태. + 코인 2장짜리 카드쌍
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (hoding[j] && hoding[n + 1 - j]) // 지금까지 가져올수 있었던 1코인 카드 2장.
                        {
                            hoding[j] = false;
                            hoding[n + 1 - j] = false;

                            coin -= 2;
                            pairCard++;
                            break; // 코인 2장짜리는 1개만 사고 빨리 다음 카드 2장까지 보면서 무료카드1장 카드쌍이 생기지않나 넘겨본다.
                        }
                    }
                }
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