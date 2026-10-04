using System;

public class Solution
{
    public int solution(int[] A, int[] B)
    {
        int answer = 0;

        int n = A.Length;

        // A순서를 바꿀순 없지만, B순서를 자유롭게 바꿀수있기에 자유롭게 매칭가능.

        Array.Sort(A, (a, b) => b.CompareTo(a)); // 내림차순
        Array.Sort(B); // 오름차순

        int start = 0, end = n - 1; // B 양끝 인덱스를 저장하자.

        for (int i = 0; i < n; i++)
        {
            if (B[end] > A[i]) // 현재 end쪽 수가 A 보다 커서 이기는경우.
            {
                answer++;
                end--;
            }
            else // 아닌 경우 작은 숫자 집어넣고 처리
            {
                start++;
            }
        }

        return answer;
    }
}