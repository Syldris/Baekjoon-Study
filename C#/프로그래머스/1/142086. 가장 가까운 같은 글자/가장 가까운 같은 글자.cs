using System;

public class Solution
{
    public int[] solution(string s)
    {
        int n = s.Length;
        int[] answer = new int[n];

        int[] alpahBet = new int[26]; // [알파벳] = 이전에 나온 위치.
        Array.Fill(alpahBet, -1);

        for (int i = 0; i < n; i++)
        {
            int index = s[i] - 'a'; // a~z 0~25 인덱스로 변환

            if (alpahBet[index] == -1)
                answer[i] = -1;

            else
                answer[i] = i - alpahBet[index];

            alpahBet[index] = i;
        }

        return answer;
    }
}