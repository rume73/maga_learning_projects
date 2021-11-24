using System;
using System.Threading.Tasks;

namespace _6___Determinant
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int n = 3;
            double[,] matrix = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = r.Next(0, 10);
                }
            }

            DateTime time1 = DateTime.Now;
            var det = DetRec(matrix);        //Рекурсивно считаем определитель

            Console.WriteLine("Обычный способ");
            Console.WriteLine("det = {0}",det);
            Console.WriteLine($"Затраченное время: {(DateTime.Now - time1).TotalMilliseconds} мс");

            double result = 0;
            object lockObject = new object();

            time1 = DateTime.Now;
            Parallel.For(0, matrix.GetLength(1), (i) =>            //Создаем потоки - счёт по 1 строчке 
            {
                double[,] minor = GetMinor(matrix, i);
                double temp = Math.Pow(-1, i) * matrix[0, i] * DetRec(minor);      

                lock (lockObject)           //поочередный доступ к записи
                {
                    result += temp;
                }
            }
            );
            Console.WriteLine();
            Console.WriteLine("Параллельный способ");
            Console.WriteLine($"det={result}");
            Console.WriteLine($"Затраченное время {(DateTime.Now - time1).TotalMilliseconds} мс");
            Console.ReadKey();
        }

        public static double DetRec(double[,] matrix)           //вычисление определителя
        {
            if (matrix.Length == 4)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            double sign = 1, result = 0;
 
            for (int i = 0; i < matrix.GetLength(1); i++)

            {
                double[,] minor = GetMinor(matrix, i);
                result += sign * matrix[0, i] * DetRec(minor);
                sign = -sign;
            }
            return result;
        }

        public static double[,] GetMinor(double[,] matrix, int n)       //вычисление минора
        {
            double[,] result = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < n; j++)
                    result[i - 1, j] = matrix[i, j];
                for (int j = n + 1; j < matrix.GetLength(0); j++)
                    result[i - 1, j - 1] = matrix[i, j];
            }
            return result;
        }
    }
}
