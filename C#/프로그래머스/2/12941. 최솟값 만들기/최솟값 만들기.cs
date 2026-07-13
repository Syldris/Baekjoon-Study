using System;

public class Solution
{
    public int solution(int[] A, int[] B)
    {
        int answer = 0;
        int n = A.Length;

        Array.Sort(A); // 오름차순
        Array.Sort(B, (a, b) => b.CompareTo(a)); // 내림차순

        // 큰수는 작은수랑 매칭시켜 곱해야 총 합이 낮음

        for (int i = 0; i < n; i++)
        {
            answer += A[i] * B[i];
        }

        return answer;
    }
}