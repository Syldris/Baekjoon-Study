using System;

public class Solution
{
    public int solution(string skill, string[] skill_trees)
    {
        int answer = 0;

        for (int i = 0; i < skill_trees.Length; i++)
        {
            bool pass = true;
            int progress = 0; // 스킬트리 진행도
            foreach (char c in skill_trees[i])
            {
                if (skill.Contains(c)) // 스킬트리에 포함된 스킬이라면
                {
                    if (skill[progress] == c) // 진행도 위치에 있는 스킬이라면 괜찮음(중복x)
                    {
                        progress++; // 진행
                    }
                    else
                    {
                        pass = false;
                        break;
                    }
                }
            }

            if (pass) answer++;
        }

        return answer;
    }
}