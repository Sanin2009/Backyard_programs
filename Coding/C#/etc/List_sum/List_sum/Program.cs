using System;
using System.Collections;
using System.Collections.Generic;

// Дан List<uint> list и некое число ulong sum. Ожидаемое количество элементов
// в list - несколько миллионов. Необходимо написать метод FindElementsForSum,
// который сможет найти наименьшие индексы start и end такие, что сумма
// элементов list начиная с индекса start включительно и до индекса end не
// включительно будет в точности равна sum. Если таких start и end нельзя найти,
// то установить start и end равными 0. Решение предоставить в виде метода.
// Сигнаруту и название метода менять нельзя, только тело.




namespace List_sum
{
    internal class Program
    {
        static class solver
        {
            static public void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
            {
                start = 0;
                end = 0;
                ulong s = 0;
                while (true)
                {
                    if (s == sum) return;
                    else if(s<sum)
                    {
                        if (end!=list.Count) s += list[end];
                        end++;
                    }
                    else if(s>sum)
                    {
                        s-=list[start];
                        start++;
                    }
                    if (end == list.Count+1)
                    {
                        start = 0;
                        end = 0;
                        return;
                    }
                }

            }
        }
        
        static void Main(string[] args)
        {
            int start;
            int end;
            solver.FindElementsForSum(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 11, out start, out end); //start будет равен 5 и end 7;
            Console.WriteLine(start + " " + end);
            solver.FindElementsForSum(new List<uint> { 4, 5, 6, 7 }, 18, out start, out end); //start будет равен 1 и end 4;
            Console.WriteLine(start + " " + end);
            solver.FindElementsForSum(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 88, out start, out end); //start будет равен 0 и end 0;
            Console.WriteLine(start + " " + end);
            solver.FindElementsForSum(new List<uint> { 100, 1, 22, 33, 31, 2, 6, 7 }, 88, out start, out end); //start будет равен 2 и end 6;
            Console.WriteLine(start + " " + end);
            solver.FindElementsForSum(new List<uint> { 100, 1, 22, 33, 31, 2, 6, 97 }, 103, out start, out end); //start будет равен 6 и end 8;
            Console.WriteLine(start + " " + end);
        }
    }
}
