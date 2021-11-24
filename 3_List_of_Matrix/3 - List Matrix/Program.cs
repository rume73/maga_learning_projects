using System;
using System.Collections;
using System.Linq;
using System.IO;

namespace _3___List_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            ListOfMatrix MList = new ListOfMatrix();  // список матриц
            ListOfMatrix MList2 = new ListOfMatrix(); //список из MatrixFile2
            ListOfMatrix MList3 = new ListOfMatrix(); //отсортированный список MList1
            string MatrixFile = "Matrix.txt";
            string MatrixFile2 = "Matrix2.txt";
            Matrix A1;      //матрица А
            Matrix A2;      //максимум по определителю 
            Matrix A3;      //минимум по определителю
            A1 = Matrix.Parse("[6, 4],[10,7]");
            MList.Add(A1);                                  //MList[0]
            MList.Add(Matrix.Parse("[3, 5],[6,3]"));        //MList[1]
            Console.WriteLine("ввод Матрицы C в формате [2,2],[2,2]: "); //([2,2],[2,2])
            MList.Add(Matrix.Parse(Console.ReadLine()));    //MList[3]
            Console.Clear();
            
            //**ВЫВОД**
            A2 = MList.Max();               
            A3 = MList.Min();
            Console.WriteLine($"Максимум по определителю: {A2.ToString()}");
            Console.WriteLine($"Минимум по определителю: {A3.ToString()}");
            Console.WriteLine();
            Console.WriteLine("Полный список матриц:");
            MList.WriteMyCollection();                      //вывод всего списка
            Console.WriteLine();
            Console.WriteLine("Список определителей: ");
            MList.WriteDETCollection();
            Console.WriteLine();
            MList.Sort();
            Console.WriteLine("Отсортированный cписок: ");
            MList.WriteMyCollection();                            //вывод отсортированного списка
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("MList[3]: ");
            try { Console.WriteLine(MList[3]); }           //Вывод 4-го элемента списка (не существует в списке)
            catch (IndexOutOfRangeException mm) { Console.WriteLine(mm.Message); }
            Console.WriteLine();
            Console.WriteLine("Список обратных матриц: ");
            MList.WriteOBRCollection();
            Console.WriteLine();
            MatrixInOut.WriteAllLines(MatrixFile, MList);   //запись в файл "Matrix.txt"
            try
            {
                MList2 = MatrixInOut.ReadAllLines(MatrixFile2);        
            }
            catch(FileNotFoundException fn) { Console.WriteLine("File not found {0}", fn.Message); }
            Console.WriteLine("Файл 2: ");
            MList2.WriteMyCollection();                     //вывод списка из файла "Matrix2.txt"
            Console.WriteLine();
            Console.WriteLine("Список в виде массива: ");
            foreach(string s in MList.ConvertToStringArray())   
                Console.WriteLine(s);                       // вывод списка в виде массива
            Console.WriteLine("Список в виде массива2: ");
            foreach (string s in MList2.ConvertToStringArray())
                Console.WriteLine(s);
            Console.ReadKey();

        }
    }
}
