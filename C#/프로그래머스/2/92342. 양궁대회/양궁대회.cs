using System;

public class Solution
{
    int[] answer = new int[11];
    int[] arr = new int[11]; // [점수] = 화살 과녁 맟춘갯수

    int maxDiff = 0; // 최대 점수차.
    int n = 0;

    public int[] solution(int n, int[] info)
    {
        this.n = n;

        BackTrcak(0, info);

        if (maxDiff == 0) // 이길 수 없음.
            return new int[1] { -1 };

        return answer;
    }

    void BackTrcak(int score, int[] info)
    {
        if (score > 10) return; // 10점 초과 스코어는 X.

        if (n == 0)
        {
            int value = 0; // 현재 점수.
            int apeachScore = 0;

            for (int i = 0; i <= 10; i++)
            {
                if (arr[i] > info[i]) // 맞춘 발수가 더 많을떄 점수 획득.
                    value += 10 - i;

                else if (info[i] > 0) // 어피치가 1발이상 쏴서 무승부 이상이면 획득.
                    apeachScore += 10 - i;
            }
            int diff = value - apeachScore; // 점수차

            if (diff > maxDiff) // 점수차이가 최대한 크게.
            {
                answer = (int[])arr.Clone();
                maxDiff = diff;
            }
            return;
        }

        arr[10 - score]++; // score에 한발. (배열상 10점부터 시작이라 10-score)
        n--;

        // 같은 점수라면 낮은쪽에 많이 쏜게 우선이므로,
        // 현재 점수부터 쏘는쪽부터 진행해서 갱신하자.

        // 현재 점수에 한발 쏜상태.
        BackTrcak(score, info); // score로 한발 더쏘는 경우.
        BackTrcak(score + 1, info); // 다음 점수쪽으로 이동.

        arr[10 - score]--; // 한발 쏜거 되돌리기.
        n++;

        // 안쏜 상태.
        BackTrcak(score + 1, info); // 다음 점수쪽으로 이동.
    }
}