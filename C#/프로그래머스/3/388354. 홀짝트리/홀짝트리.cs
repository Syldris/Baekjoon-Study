using System;
using System.Collections.Generic;
public class Solution
{
    int[] answer = new int[2];
    static int size = 1000000; // 원소의 최대 크기.
    List<int>[] graph = new List<int>[size + 1];

    public int[] solution(int[] nodes, int[,] edges)
    {
        /*
         * 홀짝노드 : 노드의 번호와 자식노드의 갯수가 홀짝이 같음.
         * 역홀짝노드 : 노드의 번호와 자식노드의 갯수가 홀짝이 다름.
         * 홀짝노드 혹은 역홀짝노드로만 트리를 이루는 갯수 세기.
         * 
         * 트리의 특징을 생각해보자..
         * 루트 노드가 없는 트리이므로 루트 번호를 매번 지정해주면서 체크하는방법도 있지만
         * 40만 * 40만이니 불가능하다.
         * 루트노드를 제외한 모든 노드는 부모와 연결되어 있는 간선이 있다.
         * 노드가 루트노드가 되면 원래 자식일때 연결되던 부모와의 간선이 자식과의 연결로 바뀌니
         * 곧 루트노드가 되면 자식갯수가 +1개 되며, 루트노드에서 자식이 되면 자식 갯수-1
         * 그니까 홀짝노드 1개 역홀짝노드 n개면. 홀짝노드를 루트로 삼아 자식갯수+1로 역홀짝으로 만들면서 역홀짝트리.
         * 반대의 경우인 역홀짝노드가 1개일때도 루트노드로 설정시 홀짝노드로 만들어 홀짝트리 가능할것같다.
         */

        for (int i = 1; i <= size; i++)
            graph[i] = new List<int>();

        for (int i = 0; i < edges.GetLength(0); i++)
        {
            int from = edges[i, 0];
            int to = edges[i, 1];

            graph[from].Add(to);
            graph[to].Add(from);
        }

        bool[] visited = new bool[size + 1];

        for (int i = 0; i < nodes.Length; i++)
        {
            int num = nodes[i];

            if (!visited[num])
            {
                int oddEvenNode = 0;
                int reverseNode = 0;

                DFS(num, true, visited, ref oddEvenNode, ref reverseNode);

                if (oddEvenNode == 1) // 홀짝노드가 1개라면 이걸 루트노드로 잡으면 자식 +1로 전부 역홀짝노드로 변형가능.
                    answer[1]++;

                if (reverseNode == 1) // 역홀짝 노드가 1개라면 이걸 루트로 잡으면 자식+1로 홀짝노드로 변형가능.
                    answer[0]++;
            }
        }

        return answer;
    }

    void DFS(int node, bool first, bool[] visited, ref int oddEvenNode, ref int reverseNode)
    {
        visited[node] = true;
        foreach (var child in graph[node])
        {
            if (!visited[child])
            {
                DFS(child, false, visited, ref oddEvenNode, ref reverseNode);
            }
        }

        if (graph[node].Count == 0) // 고립노드일때.
        {
            if (node % 2 == 0) // 번호 짝수면 홀짝노드.
                answer[0]++;
            else               // 번호 홀수면 역홀짝노드.
                answer[1]++;
            return;
        }

        int childNode = graph[node].Count - 1; // 부모노드로부터의 간선을 제외. 모두 루트노드가 아니게 두고 나중에 정하면 된다.

        if (node % 2 == childNode % 2) // 홀짝노드.
            oddEvenNode++;
        else // 번호랑 자식갯수가 다르면 역홀짝노드.
            reverseNode++;
    }
}