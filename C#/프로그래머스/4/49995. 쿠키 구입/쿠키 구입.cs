using System;
using static System.Math;
public class Solution
{
    public int solution(int[] cookie)
    {
        int answer = 0;
        int n = cookie.Length;

        int[] sum = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            sum[i] = sum[i - 1] + cookie[i - 1];
        }

        for (int mid = 1; mid < n; mid++)
        {
            int leftIndex = mid;
            int rightIndex = mid + 1;

            while (true)
            {
                int leftValue = sum[mid] - sum[leftIndex - 1]; // 누적합으로 leftIndex ~ mid
                int rightValue = sum[rightIndex] - sum[mid]; // mid+1 ~ rightIndex

                if (leftValue == rightValue) // 같으면 갱신시도.k
                    answer = Max(answer, leftValue);

                if (leftIndex == 1 && rightIndex == n) // 모두 탐색 완료.
                    break;

                if (leftIndex == 1) // 한쪽 전부 탐색한 경우
                    rightIndex++;
                else if (rightIndex == n)
                    leftIndex--;

                else if (leftValue <= rightValue) // left가 더작으면 left쪽으로 늘려서 왼쪽부분 값증가.
                    leftIndex--;
                else                              // right가 더작으면 right쪽으로 늘리기.
                    rightIndex++;
            }
        }

        return answer;
    }
}