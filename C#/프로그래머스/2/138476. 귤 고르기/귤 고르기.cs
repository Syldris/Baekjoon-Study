using System;

public class Solution
{
    public int solution(int k, int[] tangerine)
    {
        int answer = 0;

        int[] arr = new int[10000001]; // [귤 사이즈] = 갯수

        for (int i = 0; i < tangerine.Length; i++)
        {
            int size = tangerine[i];
            arr[size]++;
        }

        // 갯수가 많은 귤사이즈부터 내림차순으로 고르자.
        Array.Sort(arr, (a, b) => b.CompareTo(a));

        for (int i = 0; i < arr.Length; i++)
        {
            k -= arr[i]; // arr[i] 개만큼 귤 담기.
            answer++;  // 크기가 다른 귤종류 +1

            if(k <= 0) // 더 이상 담을 필요 없으면 그만.
                break;
        }

        return answer;
    }
}