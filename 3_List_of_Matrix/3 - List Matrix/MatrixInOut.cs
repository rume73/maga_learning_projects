using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _3___List_Matrix
{
    static class MatrixInOut
    {
        //static void AppDirectory()                                              //создание директории
        //{ 
        //   DirectoryInfo dir = new DirectoryInfo(@"C:\Users\rume7\Документы");
        //   DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"NewMatrix");
        //   FileInfo MatrixFile = new FileInfo(@"C:\Users\rume7\Документы\NewMatrix\Matrix.txt");
        //  // Console.WriteLine("Новый файл: {0}", myDataFolder);
        //}
        public static void WriteAllLines(string FileName, ListOfMatrix list)             //запись в файл
        {
            File.WriteAllLines(FileName, list.ConvertToStringArray());              //как обратиться к списку из класса ListOfMatrix (ToString)
        }
        public static ListOfMatrix ReadAllLines(string FileName)                           //запись из файла в список
        {
            //try
            //{
                return ListOfMatrix.ConvertToList(File.ReadAllLines(FileName));              //преобразование в список  
            //}
            //catch (FileNotFoundException fn)
            //{
            //    return fn.Message                                                         //не работает исключение по файлу
            //}
        }
    }
}
