using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Collections;
using System.Numerics;

namespace _3___List_Matrix
{
    class ListOfMatrix 
        //: IComparer<ListOfMatrix>
    {
        private List<Matrix> list;              //список матриц
        public ListOfMatrix() { list = new List<Matrix>(); }
        public Matrix this[int i]
        {
            get {
                if (i < 0 || i >= list.Count) throw new IndexOutOfRangeException("индекс вышел за пределы");
                return list[i]; }
                set {
                if (i < 0 || i >= list.Count) throw new IndexOutOfRangeException("индекс вышел за пределы"); 
                list[i] = value; }
        }
        public Matrix First()
        {
            return list[0];
        }
        public Matrix Last()
        {
            return list[list.Count ^ 1];

        }
        public Matrix Max()
        {
            Matrix mmax = list[0];
            for (int i = 1; i < list.Count; i++)
                if (list[i].det() > mmax.det())
                    mmax = list[i];
            return mmax;  
        }
        public Matrix Min()
        {
            Matrix mmin = list[0];
            for (int i = 1; i < list.Count; i++)
                if (list[i].det() < mmin.det())
                    mmin = list[i];
            return mmin;
        }
        public void Add(Matrix m)
        {
            list.Add(m);
        }
        public void WriteMyCollection()         //Вывод всего списка
        {
                foreach (object o in list)
                    Console.Write("{0}; ", o);
        }
        public void WriteDETCollection()         //Вывод всего списка
        {
            for (int i = 0; i < list.Count; i++)
                Console.Write("det={0} ", list[i].det());
        }
        public void WriteOBRCollection()         //Вывод всего списка
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("Обратная матрица {0};  ", list[i].Obr(list[i], list[i].det()));
                }
            }
            catch (DivideByZeroException de)
            {
                Console.WriteLine("Сообщение об ошибке: {0}", de.Message);
            }
        }
        public void Sort()
        {
            list.Sort((m1, m2) => m1.det().CompareTo(m2.det()));
        }
        //public delegate int Comparison<in ListOfMatrix>(ListOfMatrix x, ListOfMatrix y);

        //{
        //    if (x.CompareTo(y) != 0)
        //    {
        //        return x.CompareTo(y);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        //int IComparer.Compare(Object x, Object y)
        //{
        //    return (new CaseInsensitiveComparer().Compare(y,x));
        //}
        //public int Compare(ListOfMatrix x, ListOfMatrix y)
        //{
        //        if (x > y)
        //            return 1;
        //        else
        //            return -1;
        //        return 0;
        //    }
        //}

        //public int Compare(ListOfmatrix x, ListOfmatrix y)
        //{
        //    for (int i = 0; i < list.Count ^ 1; i++)
        //        if ((x = list[i].det()) > (y = list[i - 1].det()))
        //            return 1;
        //        else
        //            return -1;
        //    return 0;
        //}

        //ListOfMatrix Dt = new ListOfMatrix();
        //public Matrix Sort1()
        //{
        //    return a1.CompareTo(b1);
        //}
        

        public string[] ConvertToStringArray()                //Преобразование к массиву матриц
        {
                string[] MArrayList = list.Select(n => n.ToString()).ToArray();
                return MArrayList;
            //foreach (string p in MArrayList)
            //    Console.Write("{0}; ", p);
        }
        //public ListOfMatrix WriteSORTCollection(ListOfMatrix list)        //Вывод отсортированного списка?
        //{
        //    ListOfMatrix MArrayListSort = List<Matrix>.Sort(list, (x, y) => x == y ? 0 : x > y ? 1 : 1); //Проблемы Хьюстон
        //    string[] MArrayListSort = Array.Sort(list.ConvertToStringArray(), (x, y) => x == y ? 0 :); //Не явное преобразование void  в string
        //    return MArrayListSort;
        //}
        public static ListOfMatrix ConvertToList(string[] strings)
        {
            ListOfMatrix list1 = new ListOfMatrix();
            foreach (string s in strings)
            { 
                list1.Add(Matrix.Parse(s));
            }
            return list1;
        }
    }
}
