using System;

public class Solution
{
    public int solution(string[] babbling)
    {
        int answer = 0;

        string[] wordArr = { "aya", "ye", "woo", "ma" };

        foreach (string text in babbling)
        {
            bool success = true;

            int prevWord = -1; // 이전에 사용한 단어 기록.
            int index = 0; // 지금부터 읽어야 할 인덱스.

            while (index < text.Length) // 다 읽을때까지.
            {
                bool pass = false;

                for (int i = 0; i < 4; i++)
                {
                    int len = wordArr[i].Length;

                    if (prevWord == i || index + len > text.Length) continue;

                    bool match = true;
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
                        prevWord = i;
                        index += len;
                        break;
                    }

                }

                if (!pass) // 단어매칭 실패시 완성불가.
                {
                    success = false;
                    break;
                }
            }

            if (success) answer += 1;
        }

        return answer;
    }
}