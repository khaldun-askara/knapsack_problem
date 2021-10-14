using System;
using System.Linq;

namespace knapsack_problem
{
    class Program
    {
        static (int[], int[], int, int) Input(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            int N = int.Parse(lines[0].Split(' ')[0]);
            int M = int.Parse(lines[0].Split(' ')[1]);
            int[] mass = lines[1].Split(' ').Select(x => int.Parse(x)).ToArray();
            int[] costs = lines[2].Split(' ').Select(x => int.Parse(x)).ToArray();
            return (mass, costs, N, M);
        }


        static void DoSomething(bool[] S)
        {
            foreach (var s in S)
                Console.Write(s ? "1 " : "0 ");
            Console.WriteLine("");
        }

        static void GrayCode(int N)
        {
            bool[] S = new bool[N];
            int[] b = new int[N + 1];
            for (int i = 0; i < N + 1; i++)
                b[i] = i + 1;
            int x = 0;
            do
            {
                DoSomething(S);
                x = b[0];
                b[0] = 1;
                b[x - 1] = b[x];
                b[x] = x + 1;
                if (x <= N)
                    S[x - 1] = !S[x - 1];
            }
            while (x <= N);
        }



        static void Main(string[] args)
        {
            var (mass, costs, N, M) = Input("input.txt");

            GrayCode(N);
        }
    }
}
