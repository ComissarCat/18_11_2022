using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_11_2022
{
    class Task_1
    {
        int[] array_1;
        int[] array_2;
        int[] array_3;
        public Task_1(int length_1, int length_2)
        {
            array_1 = new int[length_1];
            array_1 = Randomize_array(array_1);
            array_2 = new int[length_2];
            array_2 = Randomize_array(array_2);
        }
        int[] Randomize_array(int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(10);
            }
            return array;
        }
        public int[] Get_general_elements()
        {
            array_3 = array_1.Intersect(array_2).ToArray();
            return array_3;
        }
        public int[] Get_array_1() { return array_1; }
        public int[] Get_array_2() { return array_2; }
    }
    class Task_2
    {
        string line;
        public string Line
        {
            set
            {
                if (value.Contains(" ")) line = value.Replace(" ", "");
                else line = value;
            }
            get { return line; }
        }
        public void Check_for_palindrome()
        {
            if (line.SequenceEqual(line.Reverse())) Console.WriteLine("Палиндром");
            else Console.WriteLine("Не палиндром");
        }
    }
    class Task_3
    {
        int[,] array;
        public Task_3()
        {
            array = new int[5, 5];
            Random rnd = new Random();
            for(int i = 0; i < array.GetLength(0);i++)
            {
                for(int j = 0; j < array.GetLength(1);j++)
                {
                    array[i, j] = rnd.Next(-100, 100);
                }
            }
        }
        public void Print_array()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
        public int Get_sum_between_min_and_max()
        {
            int sum = 0;
            int min = array[0, 0];
            int[] min_index = { 0, 0 };
            int max = array[0, 0];
            int[] max_index = { 0, 0 };
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        min_index[0] = i;
                        min_index[1] = j;
                    }
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        max_index[0] = i;
                        max_index[1] = j;
                    }
                }
            }
            Console.WriteLine($"Минимальное значение: {min}, максимальное значение: {max}");
            if ((min_index[0] > max_index[0]) || ((min_index[0] == max_index[0]) && (min_index[1] > max_index[1]))) (min_index, max_index) = (max_index, min_index);
            for(int i = min_index[0]; i < array.GetLength(0); i++)
            {
                bool stop = false;
                int j;
                if (i == min_index[0]) j = min_index[1];
                else j = 0;
                for (; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                    if ((i == max_index[0]) && (j == max_index[1])) { stop = true; break; }
                }
                if (stop) break;
            }
            return sum;
        }
    }
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Задача 1\n");
            Random rnd = new Random();
            Task_1 task_1 = new Task_1(rnd.Next(20), rnd.Next(20));
            Console.WriteLine($"Первый массив: {string.Join(" ", task_1.Get_array_1())}");
            Console.WriteLine($"Второй массив: {string.Join(" ", task_1.Get_array_2())}");
            Console.WriteLine($"Общие элементы: {string.Join(" ", task_1.Get_general_elements())}");

            Console.WriteLine("\nЗадача 2\n");
            Task_2 task_2 = new Task_2();
            Console.Write("Введите слово: ");
            task_2.Line = Console.ReadLine();
            task_2.Check_for_palindrome();

            Console.WriteLine("\nЗадача 3\n");
            Task_3 task_3 = new Task_3();
            Console.WriteLine("Массив:");
            task_3.Print_array();
            Console.WriteLine($"Сумма элементов между минимальным и максимальным равна {task_3.Get_sum_between_min_and_max()}");
        }
    }
}
