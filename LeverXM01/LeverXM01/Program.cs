using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeverXM01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            Console.WriteLine(Task01(10));
            //Task 2
            Console.WriteLine(Task02("Hello, World!"));
            Console.WriteLine(Task02("aaaaaaaaaaaa"));
            //Task 3
            List<char> list1 = UniqueInOrder("AAAABBBCCDAABBB".ToCharArray());
            Console.WriteLine(string.Join(",", list1.ToArray()));
            List<char> list2 = UniqueInOrder("ABBCcAD".ToCharArray());
            Console.WriteLine(string.Join(",", list2.ToArray()));
            int[] a = { 1, 2, 2, 3, 3 };
            List<int> list3 = UniqueInOrder(a);
            Console.WriteLine(string.Join(",", list3.ToArray()));
            //Task 4
            Console.WriteLine(ips_between("10.0.0.0", "10.0.0.50"));
            Console.WriteLine(ips_between("10.0.0.0", "10.0.1.0"));
            Console.WriteLine(ips_between("20.0.0.10", "20.0.1.0"));
            //Task 5
            int N = 5;
            int[,] array = createSpiral(N);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write("{0, 2} ", array[i, j]);
                Console.WriteLine();
            }
        }

        static int Task01(int a)
        {
            int result = 0;
            //Подсчёт суммы групп по 15 чисел
            int k = (a - 1) / 15;
            result += 60 * k;
            k--;
            result += 105 * (k + k * k) / 2;
            //Перебор оставшихся чисел
            for (int i = (k + 1) * 15 + 1; i < a; i++)
                if ((i % 3 == 0) || (i % 5 == 0))
                    result += i;
            return result;
        }

        static string Task02(string s)
        {
            StringBuilder result = new StringBuilder();
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!charCount.ContainsKey(c))
                    charCount.Add(c, 0);
                charCount[c]++;
                result.Append(charCount[c]);
            }
            return result.ToString();
        }

        static List<T> UniqueInOrder<T>(T[] s)
        {
            List<T> result = new List<T>();
            if (s.Length == 0)
                return result;
            result.Add(s[0]);
            T b = s[0];
            foreach (T c in s)
                if (!c.Equals(b))
                {
                    b = c;
                    result.Add(c);
                }
            return result;
        }

        static long ips_between(string ip1, string ip2)
        {
            long result = 0;
            string[] ips1 = ip1.Split('.');
            string[] ips2 = ip2.Split('.');
            long multip = 1;
            for (int i = 3; i >= 0; i--)
            {
                result += (int.Parse(ips2[i]) - int.Parse(ips1[i])) * multip;
                multip *= 256;
            }
            return result;
        }

        static int[,] createSpiral(int N)
        {
            if (N < 1)
                return new int[0, 0];
            int[,] result = new int[N, N];
            int stepWidth = N - 1;
            int k = 1;
            for (int j = 0; j < N / 2; j++, k += stepWidth * 3, stepWidth -= 2)
            {
                for (int i = j; i < j + stepWidth; i++, k++)
                {
                    result[j, i] = k;
                    result[i, N - 1 - j] = k + stepWidth;
                    result[N - 1 - j, N - 1 - i] = k + stepWidth * 2;
                    result[N - 1 - i, j] = k + stepWidth * 3;
                }
            }
            if (N % 2 != 0)
                result[N / 2, N / 2] = k;
            return result;
        }
    }
}
