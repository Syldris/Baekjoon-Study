using System;

public class Solution
{
    public int[] solution(int k, int[] score)
    {
        int n = score.Length;
        int[] answer = new int[n];

        int[] arr = new int[k];

        for (int i = 0; i < n; i++)
        {
            Insert(score[i], arr);
            answer[i] = GetValue(i, arr);
        }

        return answer;
    }

    void Insert(int value, int[] arr)
    {
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (value > arr[i]) // value가 더크다면 기록.
            {
                index = i;
                break;
            }
        }

        if (index == -1) return;

        for (int i = arr.Length - 1; i > index; i--) // index ~ k 까지 순위 1위씩 미루기
        {
            arr[i] = arr[i - 1];
        }
        arr[index] = value; // index에 value 기록.
    }

    int GetValue(int index, int[] arr)
    {
        if (index >= arr.Length) return arr[arr.Length - 1]; // k등 발표

        return arr[index]; // 아직 k명이 안됐다면 최하위 점수 리턴.
    }
}