using System;
using System.Collections.Generic;
using System.Text;

namespace _3___List_Matrix
{
   
    class Matrix
    {
        private int n;
        private double[,] A;

        public Matrix() { }
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }
        public Matrix(int n)                     //реализация двумерного индексатора
        {
            this.n = n;
            A = new double[this.n, this.n];
        }
        public double this[int i, int j]
        {
            get { return A[i, j]; }
            set { A[i, j] = value; }
        }
        public void WriteArray()
        {
            try
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                        A[i, j] = Convert.ToDouble(Console.ReadLine());
                    }
                }
            }
            catch (IndexOutOfRangeException ar)
            {
                Console.WriteLine(ar.Message);
            }
        }
        // Вывод матрицы с клавиатуры
        public void ReadArray()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public double det()
        {
            double d = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
            return d;

        }
        public Matrix Obr(Matrix a, double d )
        {
            Matrix resMass = new Matrix(a.N);
            if (det() == 0) throw new DivideByZeroException(
                  "Деление на ноль не может быть выполнено!");
            {
                resMass[0, 0] = (1 / det()) * a[1, 1];
                resMass[0, 1] = (1 / det()) * (-1) * a[0, 1];
                resMass[1, 0] = (1 / det()) * (-1) * a[1, 0];
                resMass[1, 1] = (1 / det()) * a[0, 0];
                return resMass;
            }
        }
        public override string ToString()
        {
            //return base.ToString();
            return $"[{this[0, 0]},{this[0, 1]}],[{this[1, 0]},{this[1, 1]}]";
        }
        public static Matrix Sum(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMass;
        }
        // Перегрузка сложения
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Sum(a, b);
        }
        public static Matrix razn(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMass;
        }
        // Перегрузка вычитания
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.razn(a, b);
        }
        public static Matrix del(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] / b[i, j];
                }
            }
            return resMass;
        }
        // Перегрузка деления
        public static Matrix operator /(Matrix a, Matrix b)
        {
            return Matrix.del(a, b);
        }
        public static Matrix multi(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
                for (int j = 0; j < b.N; j++)
                    for (int k = 0; k < b.N; k++)
                        resMass[i, j] += a[i, k] * b[k, j];
            return resMass;
        }
        // Перегрузка умножения
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Matrix.multi(a, b);
        }
        public static Matrix inc(Matrix a)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    resMass[i, j] = a[i, j] + 1;
                }
            }
            return resMass;
        }
        // Перегрузка инкремента
        public static Matrix operator ++(Matrix a)
        {
            return Matrix.inc(a);
        }
        public static Matrix dec(Matrix a)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    resMass[i, j] = a[i, j] - 1;
                }
            }
            return resMass;
        }
        // Перегрузка декремента
        public static Matrix operator --(Matrix a)
        {
            return Matrix.dec(a);
        }
        public static bool operator <(Matrix a, Matrix b)
        {
            return (a.det() < b.det());
        }
        public static bool operator >(Matrix a, Matrix b)
        {
            return (a.det() > b.det());
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return this.det() == ((Matrix)obj).det();
        }
        public override int GetHashCode()
        {
            return this.det().ToString().GetHashCode();
        }
        public static bool operator ==(Matrix a, Matrix b)
        {
            if (System.Object.ReferenceEquals(a, b))
            { return true; }
            if ((object)a == null) return false;
            return (a.Equals(b));

        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a.det() == b.det());
        }
        //public int Compare(Matrix a, Matrix b)        //Сравнение определителей в матрицах
        //{
        //    double a1 = a.det();
        //    double b1 = b.det();
        //    if (a1 == 0 || b1 == 0)
        //    {
        //         return 0;
        //    }
        //    return a1.CompareTo(b1); 
        //}
        public static Matrix Parse(string s)
        {
            Matrix resMass = new Matrix(2);
            string[] str = s.Split(',');//разбиваем на 4 элемнета
            for (int i = 0; i < str.Length; i++)
                str[i] = str[i].Trim(); //удаляем пробелы
            if (str[0][0] != '[')// первый элемент начинается со скобки?
                throw new ArgumentException("Формат матрицы неверный");
            else
            {
                str[0] = str[0].Substring(1); //тут должно быть только число
                resMass[0, 0] = Double.Parse(str[0]);

                str[1] = str[1].Substring(0, str[1].Length - 1);
                resMass[0, 1] = Double.Parse(str[1]);

                str[2] = str[2].Substring(1);
                resMass[1, 0] = Double.Parse(str[2]);

                str[3] = str[3].Substring(0, str[3].Length - 1);
                resMass[1, 1] = Double.Parse(str[3]);

                return resMass;
            }
        }
        public static bool TryParse(string s, out Matrix result)
        {
            result = null;
            Matrix resMass = new Matrix(2);
            string[] str = s.Split(',');//разбиваем на 4 элемнета
            for (int i = 0; i < str.Length; i++)
                str[i] = str[i].Trim(); //удаляем пробелы
            if (str[0][0] != '[')// первый элемент начинается со скобки?
                return false;
            else
            {
                str[0] = str[0].Substring(1); //тут должно быть только число  [55,66],[77,88]
                double a;

                if (!Double.TryParse(str[0], out a)) return false;
                else resMass[0, 0] = a;

                str[1] = str[1].Substring(0, str[1].Length - 1);
                if (!Double.TryParse(str[1], out a)) return false;
                else resMass[0, 1] = a;

                str[2] = str[2].Substring(1);
                if (!Double.TryParse(str[2], out a)) return false;
                else resMass[1, 0] = a;

                str[3] = str[3].Substring(0, str[3].Length - 1);
                if (!Double.TryParse(str[3], out a)) return false;
                else resMass[1, 1] = a;

                result = resMass;
            }
            return true;

        }
    }
}
