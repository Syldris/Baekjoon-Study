using System;

public class Solution
{
    public int[] solution(int[] sequence, int k)
    {
        int[] answer = new int[2] { 0, 1000000 };

        int n = sequence.Length;

        int start = 0, end = 0; // 투포인터. 편의상 start ~ end-1 까지 구간을 나타내자

        int value = 0;

        while (start < n)
        {
            if (value == k) // k와 같을때 비교
            {
                int len = end - 1 - start;
                if (len < answer[1] - answer[0]) // 기존 길이보다 짧다면 변경
                {
                    // start ~ end-1까지의 구간임
                    answer[0] = start;
                    answer[1] = end - 1;
                }

                value -= sequence[start];
                start++;
            }
            else if (value < k && end < n) // k보다 작으면 늘려야함 && end = n 으로 끝을 가르키면 더이상 전진불가.
            {
                value += sequence[end];
                end++;
            }
            else // k보다 크면 줄여야함
            {
                value -= sequence[start];
                start++;
            }
        }

        return answer;
    }
}