using System;
using System.Collections.Generic;
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

        static bool[] GrayCode(int N, int M, int[] mass, int[] costs)
        {
            int cur_mass = 0;
            int cur_cost = 0;
            bool[] S = new bool[N];
            int[] b = new int[N + 1];
            for (int i = 0; i < N + 1; i++)
                b[i] = i + 1;
            int x = 0;

            int max_cost = 0;
            bool[] max_knapsack = new bool[N];

            do
            {
                // Console.Write("S: ");
                // DoSomething(S);

                if (cur_mass <= M && cur_cost > max_cost)
                {
                    max_cost = cur_cost;
                    for (int i = 0; i < N; i++)
                        max_knapsack[i] = S[i];
                    // Console.Write(max_cost + "\nmax:");
                    // DoSomething(max_knapsack);
                }

                x = b[0];
                if (x <= N)
                {
                    b[0] = 1;
                    b[x - 1] = b[x];
                    b[x] = x + 1;
                    S[x - 1] = !S[x - 1];
                    if (S[x - 1])
                    {
                        cur_mass += mass[x - 1];
                        cur_cost += costs[x - 1];
                    }
                    else
                    {
                        cur_mass -= mass[x - 1];
                        cur_cost -= costs[x - 1];
                    }
                }
            }
            while (x <= N);
            // Console.Write("result: ");
            // DoSomething(max_knapsack);
            return max_knapsack;
        }



        static void Main(string[] args)
        {
            var (mass, costs, N, M) = Input("input.txt");

            var result = GrayCode(N, M, mass, costs);
            // DoSomething(result);
            for (int i = 0; i < N; i++)
                Console.Write(result[i] ? i + " " + mass[i] + "(" + costs[i] + ") " : "");

        }
    }
}
