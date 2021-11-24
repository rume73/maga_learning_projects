using System;

namespace _4__Логинов_В.О._
{
    class Program
    {
        static void Main(string[] args)
        {   
            //объявление переменных
            int S1 = 0;
            int S2 = 0;
            bool b = false;

            //примеры массивов
            //int[] Array = { 1, 2, 1, 3, 1, 2, 1, 4 };
            //int[] Array = { 1, 2, 1, 3, 1, 2, 1, 4, 1, 1 ,5 };
            //int[] Array = { 4, 1, 3, 1, 2, 1, 4 };
            //int[] Array = { 8, 4, 5, 6, 7, 8, 5 };
            //int[] Array = { 8, 4, 5, 6, 7, 8, 5, 6, 7, 8 };
            //int[] Array = { 1, 5, 1, 3, 1, 2, 1, 4 };
            //int[] Array = { 1, 1, 3, 1, 2, 1, 4};
            //int[] Array = { 3, 2, 8, 2, 1, 3, 7, 3, 5, 6 ,8 };
            int[] Array = { 8, 1, 8 };
            //int[] Array = { 9, 3, 2, 4, 2, 2, 9 };
            //int[] Array = { 3, -4, -2, 0, -3 };
            //int[] Array = { -4, -4, -4, 4, -4, -4, -4 };
            //int[] Array = { 1, -4, -1, 4, -3 };
            //int[] Array = { 2, -4, -4, 1, 0 };

            for (int i = 0; i < Array.Length; i++)    
            {
                for (int j = 0; j < i; j++)                   //сумма элементов до главного индекса
                    S1 = S1 + Array[j];
                for (int j = i + 1; j < Array.Length; j++)    //сумма элементов после главного индекса
                    S2 = S2 + Array[j];
                if (S1 == S2)                                //проверка на наличие главных индексов
                {
                    Console.WriteLine($"Главный индекс = {i}");
                    b = true;                                               
                }
                S1 = 0;                                       //обнуление сумм
                S2 = 0;
            }
            if (b != true)
                Console.WriteLine("Нет индексов");

            //вывод массива
            foreach (int j in Array)  
            {
                Console.Write($"{j} \t");
            }
            Console.ReadLine();
        }
    }
}
