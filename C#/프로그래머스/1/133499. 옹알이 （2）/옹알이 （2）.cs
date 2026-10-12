using System;
public class Solution
{
    string[] wordArr = { "aya", "ye", "woo", "ma" };

    public int solution(string[] babbling)
    {
        int answer = 0;

        foreach (string text in babbling)
        {
            if (Solve(text)) answer++;
        }

        return answer;
    }

    bool Solve(string text)
    {
        int index = 0; // 현재 읽어야 할 인덱스.
        int prevWord = -1;

        while (index < text.Length)
        {
            bool pass = false;

            for (int i = 0; i < wordArr.Length; i++)
            {
                int len = wordArr[i].Length;
                if (index + len > text.Length || prevWord == i) continue; // 이전에 사용했거나 길이 초과시 스킵.

                bool match = true; // 매치여부 확인
                for (int j = 0; j < len; j++)
                {
                    if (text[index + j] != wordArr[i][j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    pass = true;

                    index += len;
                    prevWord = i;
                    break;
                }
            }

            if (!pass) return false; // 완성못했는데 아무것도 매치불가하면 연결불가.
        }

        return true;
    }

}