using System;
using System.Collections.Generic;
public class Solution
{
    int answer = 0;
    int n;

    public int solution(int k, int[,] dungeons)
    {
        n = dungeons.GetLength(0);

        BackTrack(k, dungeons);
        return answer;
    }

    HashSet<int> dungeon = new HashSet<int>(); // 탐험한 던전 기록.

    void BackTrack(int fatigue, int[,] dungeons) // 피로도
    {
        if (dungeon.Count > answer)  // 탐험한 던전 갯수
            answer = dungeon.Count;

        for (int i = 0; i < n; i++)
        {
            if (fatigue >= dungeons[i, 0] && !dungeon.Contains(i)) // 최소 필요 피로도 보다 높으면 이동 가능 & 미 탐험 던전만 이동.
            {
                dungeon.Add(i); // 탐험으로 표시

                int nextFatigue = fatigue - dungeons[i, 1]; // 소모 피로도 감소
                BackTrack(nextFatigue, dungeons);

                dungeon.Remove(i); // 재귀 끝나면 회수
            }
        }
    }
}