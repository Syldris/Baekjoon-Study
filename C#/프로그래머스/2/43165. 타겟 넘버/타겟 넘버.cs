using System;

public class Solution
{
    int answer = 0;
    int value = 0;
    int n;

    public int solution(int[] numbers, int target)
    {
        n = numbers.Length;

        DFS(0, target, numbers);

        return answer;
    }

    void DFS(int depth, int target, int[] numbers)
    {
        if (depth == n)
        {
            if (value == target) answer++;

            return;
        }

        // 이번 숫자 더하는 경우
        value += numbers[depth];
        DFS(depth + 1, target, numbers);
        value -= numbers[depth]; // 재귀 끝나고 회수

        // 이번 숫자 빼는 경우
        value -= numbers[depth];
        DFS(depth + 1, target, numbers);
        value += numbers[depth];
    }
}