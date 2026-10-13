using System;
using System.Collections;
using System.Text;
public class Solution
{
    public string solution(string X, string Y)
    {
        StringBuilder sb = new StringBuilder();

        int[] countX = new int[10];  // X, Y에 각각 0~9 정수 숫자가 몇개있는지 카운팅.
        int[] countY = new int[10];

        for (int i = 0; i < X.Length; i++)
            countX[X[i] - '0']++;
        for (int i = 0; i < Y.Length; i++)
            countY[Y[i] - '0']++;


        for (int i = 9; i >= 0; i--) // 1자리 숫자라면, 높은숫자부터 배치하는게 항상 이득
        {
            sb.Append(new string((char)(i + '0'), Math.Min(countX[i], countY[i])));
        }

        if (sb.Length == 0) // 없으면 -1
            return "-1";

        if (sb[0] == '0') // 값이 0이라면 0만 반환
            return "0";

        return sb.ToString();
    }
}