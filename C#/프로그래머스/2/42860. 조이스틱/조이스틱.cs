using System;
using static System.Math;

public class Solution
{
    public int solution(string name)
    {
        int answer = 0;
        int[] alpahBet = new int[26]; // 각 알파벳마다 이동해야 하는 최소 횟수

        for (int i = 0; i < alpahBet.Length; i++)
        {
            alpahBet[i] = i; // 다음 알파벳으로 움직여서 필요한 총 이동횟수
        }

        for (int i = alpahBet.Length - 1; i >= 0; i--)
        {
            alpahBet[i] = Math.Min(alpahBet[i], 26 - i); // 이전 알파벳으로 움직여서 필요한 총 이동횟수(z=1부터 시작.)
        }

        for (int i = 0; i < name.Length; i++)
        {
            int index = name[i] - 'A';
            answer += alpahBet[index];
        }

        int minMove = name.Length - 1; // 최소 이동 횟수.

        for (int i = 0; i < name.Length; i++)
        {
            int startIndex = i;
            while (i + 1 < name.Length && name[i + 1] == 'A')// A 연속구간 체크. (A가 연달아 있으면 반대로 이동이 이득일 가능성 있음.)
            {
                i++;
            }
            int lastIndex = i;
            int diff = (name.Length - 1) - lastIndex; // 0번칸에서 마지막A전까지 되돌아 가야하는 이동횟수.


            minMove = Math.Min(minMove, startIndex * 2 + diff); // 오른쪽=> 왼쪽 => 뒤돌아가기 이동.
            minMove = Math.Min(minMove, startIndex + diff * 2); // 뒤돌아가기 => 0번으로 오기 => 오른쪽.

        }

        answer += minMove;

        return answer;
    }
}