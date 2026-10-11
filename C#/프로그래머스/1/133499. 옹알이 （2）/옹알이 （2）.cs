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

                    // 이전에 쓴 단어와 달라야하며, 인덱스+길이가 텍스트 초과하면 안됨. 반열림구간이니 끝점 textLen까지.
                    bool isValid = prevWord != i && index + len <= text.Length;

                    if (isValid && word[index..(index + len)].SequenceEqual(wordArr[i])) // 단어 일치 여부 확인.
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