using System;
using System.Collections.Generic;
using System.Linq;
public class Solution
{
    public int[] solution(string[] genres, int[] plays)
    {
        Dictionary<string, (int genrePlay, int song1, int song2)> dict = new Dictionary<string, (int play, int song1, int song2)>();

        for (int i = 0; i < genres.Length; i++)
        {
            string song = genres[i];
            int play = plays[i];

            if (dict.TryGetValue(song, out (int genrePlay, int song1, int song2) value))
            {
                if (play > plays[value.song1]) // 장르중 1위곡보다 많이 재생된 경우.
                {
                    value.song2 = value.song1; // 기존 1위 => 2위;
                    value.song1 = i; // 1위 갱신
                }
                else if (value.song2 == -1 || play > plays[value.song2]) // 2위 곡이 없거나 더 많은경우.
                {
                    value.song2 = i; // 2위 갱신
                }

                // 장르 재생수, 장르1위곡, 장르2위곡 기록.
                dict[song] = (value.genrePlay + play, value.song1, value.song2);
            }

            else // 없으면 새로 만듬 (2번째로 많이 재생된 곡이 없으면 -1로 기록.)
            {
                dict.Add(song, (play, i, -1));
            }
        }

        // 많이 재생된 장르순으로 정렬, 장르 내에서 많이 재생된 곡부터 기록.
        List<(int index1, int index2)> list = dict.OrderByDescending(x => x.Value.genrePlay).Select(x => (x.Value.song1, x.Value.song2)).ToList();

        List<int> answer = new List<int>();

        for (int i = 0; i < list.Count; i++)
        {
            answer.Add(list[i].index1);

            if (list[i].index2 != -1) // 2번곡이 비어있을수도 있으니 예외처리
                answer.Add(list[i].index2);
        }

        return answer.ToArray();
    }
}