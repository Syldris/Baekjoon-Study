using System;
using System.Collections.Generic;
class Solution
{
    public int[] solution(int n, string[] words)
    {
        int[] answer = new int[2];

        HashSet<string> hash = new HashSet<string>();

        // 마지막 문자 저장.
        char lastChar = words[0][0]; // 일단 첫단어 첫글자로 시작해서 예외처리.

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // 이미 등장했거나, 1글자, 끌맛잇기가 아닌경우.(첫글자가 이전 마지막글자랑 다름.)
            if (hash.Contains(word) || word.Length == 1 || word[0] != lastChar)
                return new int[2] { (i % n) + 1, (i / n) + 1 }; // 번호, 차례 리턴

            hash.Add(word);
            lastChar = word[word.Length - 1];
        }

        return answer; // 탈락 안하면 [0,0] 반환
    }
}