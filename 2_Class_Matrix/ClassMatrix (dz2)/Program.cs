using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMatrix__dz2_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите размерность матрицы: ");
            //int nn = Convert.ToInt32(Console.ReadLine());     //ввод размерности
            // Инициализация
            const int r = 2;  //размерность 2х2
            Matrix A1 = new Matrix(r);      //матрица А
            Matrix A2 = new Matrix(r);      //матрица B
            Matrix A3 = new Matrix(r);      //сложение матриц  A+B
            Matrix A4 = new Matrix(r);      //вычитание матриц A-B
            Matrix A5 = new Matrix(r);      //умножение матрицы
            Matrix A6 = new Matrix(r);      //инкремент
            Matrix A7 = new Matrix(r);      //декремент
            Matrix A8 = new Matrix(r);      //обратная матрица А
            Matrix A9 = new Matrix(r);      //обратная матрица B    
            Matrix A10 = new Matrix(r);     //матрица A*obr(A)=E
            Matrix A11 = new Matrix(r);     //матрица B*obr(B)=E
            Matrix A55 = new Matrix(r);     //деление матрицы (элемент/элемент)
            Matrix A22 = new Matrix(r);     //матрица C - Parse
            Matrix A12 = new Matrix(r);     //матрица A+B*C
            Matrix A23 = new Matrix(r);     //матрица D - TryParse

            Console.WriteLine("ввод Матрицы А: ");
            A1.WriteArray();
            Console.Clear();

            Console.WriteLine("Ввод Матрицы B: ");
            A2.WriteArray();
            Console.Clear();

            Console.WriteLine("ввод Матрицы C в формате [6,4],[10,7]: "); //([6,4],[10,7])
            A22 = Matrix.Parse(Console.ReadLine());
            Console.Clear();

            

            Console.WriteLine("Матрица А: ");
            A1.ReadArray();
            Console.WriteLine(A1.ToString());           //Матрица в строковом виде
            Console.WriteLine($"определитель матрицы = {A1.det()}");
            Console.WriteLine();
            Console.WriteLine("Обратная матрица к A: ");
            if (A1.det() != 0)
            {
                A8 = A1.Obr(A1);
                A8.ReadArray();
                Console.WriteLine("Проверка: A*obr=E");
                A10 = A1 * A8;
                A10.ReadArray();
                Console.WriteLine();
            }
            else Console.WriteLine("DET=0");
            //Console.WriteLine($"обратная матрица = {A8.Obr(A1)}");
            Console.WriteLine();
            Console.WriteLine("Матрица В: ");
            A2.ReadArray();
            Console.WriteLine($"определитель матрицы = {A2.det()}");
            Console.WriteLine();
            Console.WriteLine("Обратная матрица к B: ");
            if (A2.det() != 0)
            {
                A9 = A2.Obr(A2);
                A9.ReadArray();
                Console.WriteLine("Проверка: B*obr=E");
                A11 = A2 * A9;
                A11.ReadArray();
                Console.WriteLine();
            }
            else Console.WriteLine("DET=0");
            //Console.WriteLine($"обратная матрица = {A9.Obr(A2)}");
            Console.WriteLine();
            Console.WriteLine("Матрица C: ");
            A22.ReadArray();
            Console.WriteLine($"определитель матрицы = {A22.det()}");
            Console.WriteLine();
            Console.WriteLine("ввод Матрицы D в формате [55,66],[77,88]: "); //([55,66],[77,88])
            if (!Matrix.TryParse(Console.ReadLine(), out A23))
                Console.WriteLine("формат неверный");
            else Console.WriteLine(A23.ToString());
            Console.WriteLine("Матрица D: ");
            A23.ReadArray();
            Console.WriteLine($"определитель матрицы = {A22.det()}");
            Console.WriteLine();
            Console.WriteLine("Сложение матриц A и B: ");
            A3 = (A1 + A2);
            A3.ReadArray();
            Console.WriteLine();
            Console.WriteLine("Вычитание матриц А и B: ");
            A4 = (A1 - A2);
            A4.ReadArray();
            Console.WriteLine();
            Console.WriteLine("деление матриц А и B: ");
            A55 = (A1 / A2);
            A55.ReadArray();
            Console.WriteLine();
            Console.WriteLine("умножение матриц А и B: ");
            A5 = (A1 * A2);
            A5.ReadArray();
            Console.WriteLine();
            Console.WriteLine("инкремент матрицы А: ");
            A6 = (++A1);
            A6.ReadArray();
            Console.WriteLine();
            Console.WriteLine("декремент матрицы B: ");
            A7 = (--A2);
            A7.ReadArray();
            Console.WriteLine();
            Console.WriteLine("выражение А+B*С: ");
            A12 = (A1+A2*A22);
            A12.ReadArray();
            Console.WriteLine();
            if (A1 == A2) Console.WriteLine("Матрицы равны по определителю, A=B");
            if (A1 != A2)
                { 
                Console.WriteLine("Матрицы не равны по определителю, A != B");
                if (A1 > A2) Console.WriteLine("A>B");
                if (A1 < A2) Console.WriteLine("A<B");
                }
            Console.WriteLine($"A1[1, 1] = {A1[1, 1]}");       //Обращение к конкретному элементу
            Console.WriteLine();

            Console.ReadLine();
        }
    }
    
}
