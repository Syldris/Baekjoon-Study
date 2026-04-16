# [Platinum III] Precarious Stacks - 31666 

[문제 링크](https://www.acmicpc.net/problem/31666) 

### 성능 요약

메모리: 35532 KB, 시간: 332 ms

### 분류

자료 구조, 세그먼트 트리, 느리게 갱신되는 세그먼트 트리, 값 / 좌표 압축

### 제출 일자

2026년 4월 17일 06:23:38

### 문제 설명

<p>It’s been difficult finding a job in the tech industry lately. You managed to land a job working for a construction company, but some of the tasks being assigned to you have you wondering whether the engineers have ever heard of gravity. Anyway, in the latest task, you are asked to evaluate the following model of a construction project.</p>

<p>The model is built by dropping axis-aligned squares, each with a specific $x$ coordinate and size, towards the ground (which is defined by the line $y=0$). Each square will move downwards until its bottom face hits the ground or some other square. Once a square lands, it is securely fastened in place, so even if two squares are off balance, they will not fall over.</p>

<p>Given the list of squares to place and the order to place them in, determine the maximum $y$ coordinate reached by the structure after each square is placed.</p>

### 입력 

 <p>The first line of input contains an integer $N$ ($1 \le N \le 10^5$) indicating how many squares there are in the model. The next $N$ lines describe the squares in the ordered they are to be dropped. Line $i$ contains two integers $x_ i$ ($0 \le x_ i \le 10^9$) and $s_ i$ ($1 \le s_ i \le 10^9$), indicating the $x$ coordinate of the leftmost edge of square $i$ and the size of square $i$, respectively.</p>

### 출력 

 <p>Output $N$ lines, with line $i$ containing the $y$ coordinate of the highest point that is reached by the structure after squares $1,\dots ,i$ have been dropped.</p>

