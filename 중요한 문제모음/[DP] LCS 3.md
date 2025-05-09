## [백준 1958번: LCS3](https://github.com/Syldris/Baekjoon-Study/tree/main/C%23/%EB%B0%B1%EC%A4%80/Gold/1958.%E2%80%85LCS%E2%80%853)

### ✅ 문제 요약
- 문자열 A, B, C가 주어졌을 때, **세 문자열에 모두 포함되는 가장 긴 공통 부분 수열**의 길이를 구하는 문제
- 단, 연속일 필요는 없고 **순서만 유지**하면 됨
- **연속된 공통 문자열 길이**를 찾는 문제는 [**공통 부분 문자열**](https://github.com/Syldris/Baekjoon-Study/blob/main/%EC%A4%91%EC%9A%94%ED%95%9C%20%EB%AC%B8%EC%A0%9C%EB%AA%A8%EC%9D%8C/%5BDP%5D%20%EA%B3%B5%ED%86%B5%20%EB%B6%80%EB%B6%84%20%EB%AC%B8%EC%9E%90%EC%97%B4.md)
---

### 💡 핵심 개념

1. **DP (동적 계획법) 3차원 확장**
   - `dp[i][j][k]`: 문자열 A의 i, B의 j, C의 k번째까지 고려했을 때 **공통 부분 수열의 최대 길이**
   - 기존 2차원 LCS 문제에서 3개 문자열을 비교해야 하므로 **3차원 배열**을 사용

2. **점화식**
   - 세 문자가 모두 같을 경우  
     **`dp[i][j][k] = dp[i-1][j-1][k-1] + 1`**
   - 아니라면,  
     **`dp[i][j][k] = max(dp[i-1][j][k], dp[i][j-1][k], dp[i][j][k-1])`**  
   → 셋 중 가장 긴 공통 부분 수열을 가져오는 방식

---

### 🔍 추가 분석

#### 📌 왜 3차원 배열을 써야 할까?
기존 LCS(최장 공통 부분 수열)는 두 문자열 간의 관계만 저장하면 되어 2차원 배열로 충분했음.

하지만 이번 문제는 A, B, C 세 문자열 모두의 상태를 고려해야 함으로, 각각의 인덱스를 기준으로 세 좌표가 필요!  
→ 그래서 `dp[i][j][k]`로 3차원 상태를 관리.

#### ⏱️ 시간 복잡도
`O(N³)` (N = 각 문자열 길이 N<=100)

- 각 문자마다 비교가 들어가고, 모든 인덱스 조합을 순회해야 해서 **3중 반복문**이 들어감  
→ **N <= 100** 이므로 최악의경우에도 **100^3 = 1,000,000**

---

### 💡 DP 없이 계산하면?
- DP를 사용하지 않으면, 각 문자열의 모든 인덱스를 비교하면서 **재귀적으로 호출**하거나, **중복되는 계산을 여러 번** 하게 되기 때문에 지속적으로 **재계산**이 일어난다.

- 최악의 경우, 각 문자열에 대해 **재귀적으로 계산**을 해야 하므로 **시간 복잡도**가 **O(3^N)** 에 가까운 값이 될 수 있다. 

- 예를 들어, **문자열 A, B, C 각각의 길이가 100**이라면, DP 없이 풀 경우 최악 **3^100번**의 연산을 해야 할 수 있다.
- **(3^100 = 515,377,520,732,011,300,000,000,000,000,000,000,000,000,000,000)**

---

### 📝 느낀 점
- LCS3 문제는 기존 2차원 LCS를 3차원으로 확장하는 문제였기 때문에 문제를 풀기 위해서는 상태 공간을 확장하는 느낌. 
- DP 문제를 풀 때마다 **점화식의 확장이 핵심**인 것 같다!
- 이렇게 점화식을 확장하면서, 점차적으로 문제 해결의 **유연한 사고**가 길러지는 느낌이었다.

---

### 💻 C# 코드

```csharp
public class Program
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        string c = Console.ReadLine();
        int alen = a.Length;
        int blen = b.Length;
        int clen = c.Length;

        // 3차원 DP 배열 선언
        int[,,] dp = new int[alen + 1, blen + 1, clen + 1];

        for (int i = 1; i <= alen; i++)
        {
            char achar = a[i - 1];
            for (int j = 1; j <= blen; j++)
            {
                char bchar = b[j - 1];
                for (int k = 1; k <= clen; k++)
                {
                    char cchar = c[k - 1];
                    // 세 문자가 모두 같으면 이전 dp값 + 1
                    if (achar == bchar && bchar == cchar)
                    {
                        dp[i, j, k] = dp[i - 1, j - 1, k - 1] + 1;
                    }
                    else // 셋 중 최댓값 가져오기
                    {
                        dp[i, j, k] = Math.Max(Math.Max(dp[i - 1, j, k], dp[i, j - 1, k]),
                            dp[i, j, k - 1]);
                    }
                }
            }
        }
        Console.WriteLine(dp[alen, blen, clen]);
    }
}
```
