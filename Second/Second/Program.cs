using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Program
    {
        public int task480(int N, int[] money, int K)
        {
            int[] S = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                S[i] = 0;
                for (int j = i; j <= N; j++)
                {
                    S[i] += money[j];
                }
            }

            int[,] G = new int[N + 1, K + 1];

            for (int R = 1; R <= N; R++)
            {
                for (int M = 1; M <= K; M++)
                {
                    if (M >= N - R + 1) G[R, M] = S[R];
                }
            }

            for (int R = N; R > 0; R--)
            {
                for (int M = 1; M <= K; M++)
                {
                    if (M < N - R + 1)
                    {
                        int[] win = new int[M + 1];
                        for (int i = 1; i <= M; i++)
                        {
                            win[i] = S[R] - G[R + i, i];
                        }
                        Array.Sort(win);
                        G[R, M] = win[M];
                    }
                }
            }
            return G[1, K];
        }
        static void Main(string[] args)
        {
        }
    }
}
