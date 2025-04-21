
## [백준 2096번: 내려가기](https://www.acmicpc.net/problem/2096)

### ✅ 문제 요약

- N×3 크기의 숫자 배열이 주어짐.
- 윗줄에서 시작해 아랫줄로 내려오며 숫자를 선택할 수 있음.
- 단, 현재 위치의 **바로 아래**, **왼쪽 아래**, **오른쪽 아래**만 선택 가능.
- **얻을 수 있는 최대 점수와 최소 점수**를 구하는 문제.
![image](https://github.com/user-attachments/assets/ce3bfdac-fb94-4ac0-949e-22219cb05abc)
- 파란 동그라미는 **내려갈 수 있는 위치**
- 빨간 가위표는 **내려갈 수 없는 위치**
---

### 💡 풀이법: DP로 누적 최대/최소값 관리

```csharp
int[] min = new int[3];
int[] max = new int[3];

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

    if (i == 0) 
    {
        min = input.ToArray();
        max = input.ToArray();
    }
    else
    {
        int[] tempMin = new int[3];
        int[] tempMax = new int[3];

        // 0번 칸은 (0, 1)번 칸에서 올 수 있음
        tempMin[0] = Math.Min(min[0], min[1]) + input[0];
        tempMax[0] = Math.Max(max[0], max[1]) + input[0];

        // 1번 칸은 (0, 1, 2)번 칸에서 올 수 있음
        tempMin[1] = Math.Min(Math.Min(min[0], min[1]), min[2]) + input[1];
        tempMax[1] = Math.Max(Math.Max(max[0], max[1]), max[2]) + input[1];

        // 2번 칸은 (1, 2)번 칸에서 올 수 있음
        tempMin[2] = Math.Min(min[1], min[2]) + input[2];
        tempMax[2] = Math.Max(max[1], max[2]) + input[2];

        min = tempMin;
        max = tempMax;
    }
}

Console.WriteLine($"{max.Max()} {min.Min()}");

```
---
### 📎 오답노트

#### ❗ 1. 얕은 복사(`=`) 사용으로 값이 같이 바뀜
```csharp
// ❌ 잘못된 코드
min = input;
max = input;
```
- 이렇게 하면 **min**과 **max**가 **input**의 값이 아닌 **메모리를 복사하는 배열 참조**를 가짐
- 값이 하나 바뀌면 같이 바뀌는 **얕은 복사 문제** 발생

✅ 반드시 .ToArray()를 써서 **깊은 복사** 해야 함

```csharp
// ✅ 올바른 코드
min = input.ToArray();
max = input.ToArray();
```

#### ❗ 2. 메모리 제한 주의 (제한: 4MB)
- **→ 메모리 초과** 발생 가능
- ✅ 따라서 **int[3] 배열만 4개 사용**하여 한 줄씩만 계산 및 갱신해야 함

---

### 🧠 핵심 아이디어
- min[i], max[i] 배열을 사용해 **현재 줄까지의 누적 최솟값/최댓값**을 계산
- 각 줄마다 3칸 중 갈 수 있는 칸만 고려하여 계산
- 배열을 덮어쓰지 않도록 항상 **tempMin, tempMax와 같은 임시 배열**을 사용
- 메모리 제한을 만족시키기 위해 최소한의 공간만 사용 (DP 전체 저장 ❌)
