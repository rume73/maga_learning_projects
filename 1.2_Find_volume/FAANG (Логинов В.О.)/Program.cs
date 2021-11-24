using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAANG__Логинов_В.О._
{
    class Program
    {
        static void Main(string[] args)
        {
            //Объявление переменных
            int S = 0;
            int S1=0;
            int iMax1 = 0;
            int iMax2 = 1;
            int MinMax;
            int temp;
            int temp1;
            int tempI = 2;
            int oldiMax1=-1;
            int oldiMax2=-1;
            int C = 0;

            // Варианты массивов
            int[] Array = { 1, 2, 1, 3, 1, 2, 1, 4 };
            //int[] Array = { 1, 2, 1, 3, 1, 2, 1, 4, 1, 1 ,5 };
            //int[] Array = { 4, 1, 3, 1, 2, 1, 4 };
            //int[] Array = { 8, 4, 5, 6, 7, 8, 5 };
            //int[] Array = { 8, 4, 5, 6, 7, 8, 5, 6, 7, 8 };
            //int[] Array = { 1, 5, 1, 3, 1, 2, 1, 4 };
            //int[] Array = { 1, 1, 3, 1, 2, 1, 4};
            //int[] Array = { 3, 2, 8, 2, 1, 3, 7, 3, 5, 6 ,8 };
            //int[] Array = { 8, 1, 8 };
            //int[] Array = { 9, 3, 2, 4, 2, 2, 9 };
            int Max1 = Array[0];
            int Max2 = Array[1];
            if (Max1 < Max2)
            {
                temp = Max1;
                Max1 = Max2;
                Max2 = temp;
                temp1 = iMax1;
                iMax1 = iMax2;
                iMax2 = temp1;
            }
            A:
            for (int i = tempI; i < Array.Length; i++)    //Находим 2 максимальных индекса по значениям
            {
                if (Array[i] >= Max2)
                { Max2 = Array[i]; iMax2 = i; }
                if ((Max1 < Max2) && (i != iMax2))
                //if (Max1 < Max2)
                {
                    temp = Max1;
                    Max1 = Max2;
                    Max2 = temp;
                    iMax1 = i - 1;
                }
                if (i < Array.Length-1)
                    if ((Max1 > Array[i + 1]) && (Max2 > Array[i + 1]) && (Max2 > Array[i - 1])) //Поиск бортиков
                        //if ((iMax1 > oldiMax1)&& (iMax2 > oldiMax2))                             //Проверяем, участвовал ли бортик в вычислении
                        { 
                            tempI = i + 1;                                                       
                            break;                                                               //Нашли бортики - переходим к вычислению S
                        }
                        //else
                        //    tempI = i + 1;
                    else
                        tempI = i + 1;
            }
            //if (iMax1 != oldiMax1)
            //Console.WriteLine($"Бортики = {iMax1} ; {iMax2}");
            if (Array[iMax1] > Array[iMax2]) //Находим максимальный порог воды
                MinMax = Array[iMax2];
            else
                MinMax = Array[iMax1];
            if (iMax1 > iMax2)              //Находим левый бортик
            {
                S1 = 0;                                           //Обнуляем кусок площади
                for (int i = iMax2 + 1; i < iMax1; i++)
                {
                    S1 = S1 + (MinMax - Array[i]);                //Находим кусок площади от левого до правого бортика
                    if (iMax1 != oldiMax1)                        //Запоминаем площадь на этапе iTemp
                        C = S1;                                     
                }
                S = S + S1;                                       //Считаем общую площадь
                if (iMax1 == oldiMax1)                            //Если уже площадь участвовала в вычислении, то вычитаем её, т.к. берем больший диапазон между бортиками
                    S = S - C;                                    //Вычитаем кусок площади, который уже участвует в большем диапазоне
            }
            else
            {
                S1 = 0;
                for (int i = iMax1 + 1; i < iMax2; i++)
                {
                    S1 = S1 + (MinMax - Array[i]);
                    if (iMax1 != oldiMax1)
                        C = S1;
                }
                S = S + S1;
                //if ((iMax1 == oldiMax1) && (iMax2 > oldiMax2))
                if (iMax1 == oldiMax1)
                        S = S-C ;
            }
            if (tempI < Array.Length - 1)                      //проверка на конец массива
            {
                oldiMax1 = iMax1;                              //запоминаем бортик, который был включен в вычисление
                oldiMax2 = iMax2;
                goto A;                                        //переходим на этап iTemp для продолжения цикла по поиску бортиков
            }
            else
                Console.WriteLine($"Объем залитой сверху воды = {S}");

            //Вывод массива
            foreach (int i in Array)
            {
                Console.Write($"{i} \t");
            }
            Console.ReadLine();

        }
    }
}
