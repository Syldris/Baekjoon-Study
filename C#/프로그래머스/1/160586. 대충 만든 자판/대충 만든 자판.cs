using System;
using static System.Math;
public class Solution
{
    public int[] solution(string[] keymap, string[] targets)
    {
        const int MAX = int.MaxValue / 10;

        int[] alphabet = new int[26]; // 각 알파벳을 입력하기 위한 최소 행동수.
        Array.Fill(alphabet, MAX); // MAX로 값 초기화.

        for (int i = 0; i < keymap.Length; i++)
        {
            for (int j = 0; j < keymap[i].Length; j++)
            {
                int index = keymap[i][j] - 'A';

                alphabet[index] = Min(j + 1, alphabet[index]); // 값 작을때만 갱신
            }
        }

        int n = targets.Length;
        int[] answer = new int[n];

        for (int i = 0; i < n; i++)
        {
            int value = 0;

            foreach (char c in targets[i]) // 문자열 루프.
            {
                int index = c - 'A';

                if (alphabet[index] == MAX) // 입력 불가 알파벳.
                {
                    value = -1;
                    break;
                }

                value += alphabet[index]; // 각 문자마다 얼마의 행동을 하는지 누적.
            }
            answer[i] = value;
        }

        return answer;
    }
}