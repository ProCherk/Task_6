﻿using System;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Massives a = new Massives();

            a.InputMassiveSize_M();
            a.InputMassiveSize_N();

            a.CreateMassive();
            a.OutputMassive();

            bool flag = false;
            do
            {
                a.GetMassiveValue();

                Console.WriteLine("Обрати елемент масиву ще раз? Якщо ТАК - 1, НІ - інше");
                string ans = Console.ReadLine();
                if (ans == "1")
                    flag = true;
                else
                    flag = false;

            } while (flag);

            a.TaskFunction();
        }
    }

    class Massives
    {
        Random rnd = new Random();

        private int m;
        public int M
        {
            get { return m; }
            set { m = value; }
        }

        private int n;
        public int N
        {
            get { return n; }
            set { n = value; }
        }

        private int[,] mass;
        public int[,] Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        public int InputMassiveSize_M()
        {
            //Введення і перевірка на правильність кількості строк масиву
            bool flag = false;
            do
            {
                Console.Write("Введіть к-сть строк масиву: ");
                string a = Console.ReadLine();
                flag = int.TryParse(a, out m);
                if (flag)
                    break;
                else
                {
                    Console.WriteLine("Невірно введені данні!!!!");
                    flag = true;
                }

            } while (flag);

            Console.WriteLine();
            return m;
        }

        public int InputMassiveSize_N()
        {
            //Введення і перевірка на правильність кількості стовпчиків масиву
            bool flag = false;
            do
            {
                Console.Write("Введіть к-сть стовпчиків масиву: ");
                string a = Console.ReadLine();
                flag = int.TryParse(a, out n);
                if (flag)
                    break;
                else
                {
                    Console.WriteLine("Невірно введені данні!!!!");
                    flag = true;
                }

            } while (flag);

            Console.WriteLine();
            return n;
        }

        public int[,] CreateMassive()
        {
            //Створення і заповнення масиву
            Console.WriteLine("Створений масив: ");

            mass = new int[m, n];
            for (int i = 0; i < m; i++) 
            {
                for (int j = 0; j < n; j++)
                {
                    mass[i, j] = rnd.Next(1, 40);
                }
            }

            Console.WriteLine();
            return mass;
        }
        
        public void OutputMassive()
        {
            //Вивід масиву у консоль
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{mass[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void GetMassiveValue()
        {
            //Функція отримання індексу масиву за його значенням
            int count = 0;

            Console.Write("Введіть елемент масиву ");
            int a = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(a == mass[i, j])
                    {
                        Console.WriteLine($"Елемент масиву у {a} знаходиться на позиції - {i}, {j}");
                        count++;
                    }
                }
            }
            if (count == 0)
                Console.WriteLine($"Елементу {a} у масиві немає");
            Console.WriteLine();
        }

        public void TaskFunction()
        {
            //Функція знаходження середнього значення елементів у стовпчику масиву
            double sum = 0;
            for (int st = 0; st < n; st++)
            {
                sum = 0;
                for (int i = 0; i < m; i++)
                {
                    sum += mass[i, st];
                }
                sum = sum / n;
                Console.WriteLine($"Середнє значення елементів у {st + 1} стовпчику - {sum}");
            }
        }
    }    
}
