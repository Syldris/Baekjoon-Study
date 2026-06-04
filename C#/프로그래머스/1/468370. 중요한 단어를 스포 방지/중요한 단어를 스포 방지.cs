using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(string message, int[,] spoiler_ranges)
    {
        int answer = 0;

        HashSet<string> hash = new HashSet<string>();

        List<string> spoilerWords = new List<string>();
        List<char> chars = new List<char>();

        int index = 0;
        bool spoiler = false;

        for (int i = 0; i < message.Length; i++)
        {
            if (message[i] == ' ') // 빈공간일때 부터 처리.
            {
                if (spoiler)
                    spoilerWords.Add(new string(chars.ToArray()));
                else
                    hash.Add(new string(chars.ToArray()));

                spoiler = false;
                chars.Clear();

                continue;
            }

            // 단어 일부라면 스포일러 체크.
            int spoStart = spoiler_ranges[index, 0];
            int spoEnd = spoiler_ranges[index, 1];

            if (i > spoEnd && index < spoiler_ranges.GetLength(0) - 1) // 스포 끝구간 넘었으면 다음구간으로 넘겨서 계산하자.
            {
                index++;
                spoStart = spoiler_ranges[index, 0];
                spoEnd = spoiler_ranges[index, 1];
            }

            if (!spoiler && spoStart <= i && i <= spoEnd) // 스포일러 구간에 해당하면 표시.
                spoiler = true;

            chars.Add(message[i]);
        }

        // 남은 문자 처리.
        if (spoiler)
            spoilerWords.Add(new string(chars.ToArray()));
        else
            hash.Add(new string(chars.ToArray()));


        foreach (string word in spoilerWords)
        {
            if (!hash.Contains(word)) // 아직 등장하지 않은 스포방지 단어 갯수 세기.
            {
                answer++;
                hash.Add(word);
            }
        }


        return answer;
    }
}