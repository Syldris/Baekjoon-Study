using System;
using System.Collections.Generic;
public class Solution
{
    public string[] solution(string[] players, string[] callings)
    {
        int n = players.Length;
        Dictionary<string, int> dict = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
            dict.Add(players[i], i);

        for (int i = 0; i < callings.Length; i++)
        {
            int index = dict[callings[i]];

            dict[callings[i]]--; // 호출된 선수는 추월해서 등수가 오름
            dict[players[index - 1]]++; // 호출된 선수 앞번호는 등수가 내려감.

            // 스왑
            (players[index], players[index - 1]) = (players[index - 1], players[index]);
        }

        return players;
    }
}