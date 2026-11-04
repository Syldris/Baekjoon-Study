public class Solution
{
    public int[,] solution(int[,] arr1, int[,] arr2)
    {
        int r = arr1.GetLength(0);
        int c = arr1.GetLength(1);
        int[,] answer = new int[r, c];

        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                answer[i, j] = arr1[i, j] + arr2[i, j];

        return answer;
    }
}