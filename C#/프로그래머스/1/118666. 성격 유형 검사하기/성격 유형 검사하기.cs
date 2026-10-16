using System;

public class Solution
{
    public string solution(string[] survey, int[] choices)
    {
        int[] type1 = new int[4];
        int[] type2 = new int[4];

        for (int i = 0; i < choices.Length; i++)
        {
            if (choices[i] == 4) continue; // 4번 항목은 점수없음.

            int read = choices[i] <= 3 ? 0 : 1; // 선택지따라 어디쪽에 가까운지 체크.
            int value = choices[i] <= 3 ? 4 - choices[i] : choices[i] - 4; // 1~3 선택은 낮을수록, 5~7선택은 높을수록 점수많이.

            (int type, int index) = Convert(survey[i][read]);

            if (type == 0)
                type1[index] += value;
            else
                type2[index] += value;
        }

        char[] answer = new char[4];

        char[] pers1 = { 'R', 'C', 'J', 'A' };
        char[] pers2 = { 'T', 'F', 'M', 'N' };

        for (int i = 0; i < 4; i++)
        {
            if (type1[i] >= type2[i]) answer[i] = pers1[i];
            else answer[i] = pers2[i];
        }

        return new string(answer);
    }

    (int type, int index) Convert(char c) => c switch
    {
        'R' => (0, 0),
        'C' => (0, 1),
        'J' => (0, 2),
        'A' => (0, 3),
        'T' => (1, 0),
        'F' => (1, 1),
        'M' => (1, 2),
        'N' => (1, 3),
    };
}
