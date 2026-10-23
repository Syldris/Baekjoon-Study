using System;

public class Solution
{
    public int[] solution(int[] lottos, int[] win_nums)
    {
        int[] answer = new int[2];

        int match = 0; // 정답 맞춘갯수.
        int blankSpace = 0; // 빈칸

        for (int i = 0; i < lottos.Length; i++)
        {
            if (win_nums.Contains(lottos[i])) // 길이 = 6 이므로 비용 얼마 안듬.
                match++;

            else if (lottos[i] == 0) blankSpace++;
        }


        answer[0] = rank(match + blankSpace); // 빈칸 1개의 최대 기댓값은 당첨번호 1개.
        answer[1] = rank(match);

        return answer;
    }

    // 맞춘 갯수에 따른 복권 당첨 등수.
    int rank(int match) => match switch
    {
        6 => 1,
        5 => 2,
        4 => 3,
        3 => 4,
        2 => 5,
        _ => 6
    };
}