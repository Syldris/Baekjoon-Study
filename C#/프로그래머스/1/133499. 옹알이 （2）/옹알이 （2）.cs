using System;

public class Solution
{
    public int solution(string[] babbling)
    {
        int answer = 0;

        string[] wordArr = { "aya", "ye", "woo", "ma" };

        foreach (string text in babbling)
        {
            ReadOnlySpan<char> word = text.AsSpan();
            bool success = true;

            int prevWord = -1; // 이전에 사용한 단어 기록.
            int index = 0; // 지금부터 읽어야 할 인덱스.

            while (index < text.Length) // 다 읽을때까지.
            {
                bool pass = false;

                for (int i = 0; i < 4; i++)
                {
                    int len = wordArr[i].Length;

                    // 이전에 쓴 단어와 달라야하며. word의 index..의 시작부분이 wordArr과 같아 이을수 있는지 체크.
                    if (prevWord != i && word[index..].StartsWith(wordArr[i])) // 단어 일치 여부 확인.
                    {
                        prevWord = i;
                        index = index + len;
                        pass = true;
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