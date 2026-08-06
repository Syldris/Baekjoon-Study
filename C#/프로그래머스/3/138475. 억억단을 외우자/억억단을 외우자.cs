using System;

public class Solution
{
    public int[] solution(int e, int[] starts)
    {
        int n = starts.Length;
        int[] answer = new int[n];

        int[] arr = new int[e + 1];

        for (int i = 1; i <= e; i++)
        {
            for (int j = 1; i * j <= e; j++)
            {
                arr[i * j]++;
            }
        }

        // 문제에서 요구하는것은 구간 s,e에 대해 최빈값을 찾는것이다.
        // max값을 유지하면서 e=>s 방향으로 정보를 저장하면 구간 s,e에 대해서의 최빈값을 알수있다.

        int value = arr[e]; // 현재 최빈값.
        int max = arr[e]; // 최빈값의 등장횟수.
        int[] info = new int[e + 1]; // info[x] = x~e 까지의 최빈값중 가장 작은값을 저장.

        for (int i = e; i >= 1; i--)
        {
            if (arr[i] >= max) // 등장횟수가 같다면 작은 수로 저장.
            {
                value = i;
                max = arr[i];
            }
            info[i] = value;
        }

        for (int i = 0; i < n; i++)
        {
            int start = starts[i];
            answer[i] = info[start];
        }

        return answer;
    }
}