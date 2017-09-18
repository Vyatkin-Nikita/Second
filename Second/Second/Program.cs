using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Second
{
    class Program
    {
        static int N, K;
        static int[] money;
        public static int MainFunction(int N, int[] money, int K)
        {
            int[] S = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                S[i] = 0;
                for (int j = i; j <= N; j++)
                {
                    S[i] += money[j-1];
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
            FileStream fs = new FileStream("INPUT.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string [] arr = sr.ReadLine().Split();            
            sr.Close();
            fs.Close();
            N = int.Parse(arr[0]);
            K = int.Parse(arr[arr.Length-1]);
            money = new int[arr.Length - 2];
            for (int i = 1; i < arr.Length - 1; i++)
            {
                money[i - 1] = int.Parse(arr[i]);
            }

            FileStream fs1 = new FileStream("OUTPUT.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(MainFunction(N, money, K));
            sw.Close();
            fs1.Close();
        }
    }
}
