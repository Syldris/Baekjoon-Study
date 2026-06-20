using System;
public class Solution
{
    public long solution(int[] sequence)
    {
        long answer = 0;

        int n = sequence.Length;

        int[] arr1 = new int[n]; // 1 -1 로 반복되는 펄스수열을 곱한 배열.
        int[] arr2 = new int[n]; // -1 1 로 반복하는 펄스수열을 곱한 배열.

        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                arr1[i] = sequence[i];
                arr2[i] = -sequence[i];
            }
            else
            {
                arr1[i] = -sequence[i];
                arr2[i] = sequence[i];
            }
        }

        long[] dp1 = new long[n + 1]; // 펄스1를 이용해서 ~index 까지의 최댓값을 저장.
        long[] dp2 = new long[n + 1]; // 펄스2를 이용해서 ~index 까지의 최댓값을 저장.

        for (int i = 1; i <= n; i++)
        {
            // 비교. 현재값부터 시작해서 쓴다 / 이전까지의 값을 쓴다
            dp1[i] = Math.Max(arr1[i - 1], dp1[i - 1] + arr1[i - 1]);
            dp2[i] = Math.Max(arr2[i - 1], dp2[i - 1] + arr2[i - 1]);

            answer = Math.Max(answer, dp1[i]);
            answer = Math.Max(answer, dp2[i]);
        }

        return answer;
    }
}