using System;
using System.Collections.Generic;
using System.Text;

namespace _4___HomoEventArgs
{

    class LifeInTown
    {
        public LifeInTown(uint Year)
        {
            this.Year = Year;
            list = new List<Homo>();
        }
        public uint Year;
        private List<Homo> list;
        public int numhomo
        {
            get { return list.Count; }      //возвращает количество эл-тов
        }
        //public uint Year
        //{
        //    get { return Year; }
        //    set { Year = value; }
        //}

        public Homo this[int i]
        {  //аксессор для получения данных
            get
            {
                if (i >= 0 && i < list.Count) return list[i];
                else
                    throw new Exception("Индекс за пределами");
            }
            //аксессор для установки данных
            set
            {
                if (i >= 0 && i < list.Count) list[i] = value;
                else
                    throw new Exception("Индекс за пределами");
            }
        }
        public void Add(string Name, string Surname, uint BYear, bool Gender)//добавление человека
        {
            list.Add(new Homo(Name, Surname, BYear, Gender));
        }
        public List<Homo> adult()//поиск совершеннолетних
        {
            return list.FindAll(h => this.Year - h.BYear >= 18);
        }
        public List<Homo> holost()//поиск холостяков обоего пола
        {
            return list.FindAll(h => h.Partner == null && Year - h.BYear > 17);
        }
        public List<Homo> holostmen()//поиск холостяков мужского пола
        {
            return list.FindAll(h => h.Partner == null && h.Gender == true && this.Year - h.BYear > 17);
        }
        public List<Homo> holostwomen()//поиск холостяков женского пола
        {
            return list.FindAll(h => h.Partner == null && h.Gender == false && this.Year - h.BYear > 17);
        }
        public void life()
        {//женить с помощью рандома
            List<Homo> list1;//для незамужних и холостяков
            List<Homo> list2;//для холостяков
            List<Homo> list3;//для незамужних
            List<Homo> list4;//для тех, кому 18
            Year++;
            Random rand = new Random();
            list4 = adult();            //поиск тех, кому больше восемнадцати
            //homolist3.ForEach(adult(this));
            for (int i = 0; i < list4.Count; i++)
                list4[i].OnAdult(Year);//вызов события совершеннолетие
            list1 = holost();//поиск всех холостяков
            list2 = holostmen();//холостяки
            list3 = holostwomen();//незамужние
            int a;
            if (list2.Count > list3.Count)
                a = list3.Count;
            else//ищем максимальное кол-во тех, кого можно женить
                a = list2.Count;
            for (int i = 0; i < rand.Next(a); ++i)
                list2[i].Partner = list3[i];//женим
        }
        public void Add(Homo hm)//функция добавления человека
        {
            list.Add(hm);
        }

    }
    public class Printing
    {
        public void ObrabEvent(object ob1, HomoEventArgs hev)
        {
            if (hev.homoEvents == HomoEvents.Adult)
                Console.WriteLine("{0} {1} достиг(ла) совершеннолетия", ((Homo)ob1).Name, ((Homo)ob1).Surname);//когда вызывается событие, то оно вызывает вот этот класс за счёт того, что мы объявили в мейне
            else
                Console.WriteLine(String.Format("{0} {1} {2}г сочетался(ась) законным браком с {3} {4} {5}г", ((Homo)ob1).Name, ((Homo)ob1).Surname, ((Homo)ob1).BYear, ((Homo)ob1).Partner.Name, ((Homo)ob1).Partner.Surname, ((Homo)ob1).Partner.BYear));
        }
    }
    static class HomoExtension
    {
        public static Homo CreateWoman(uint BYear, string Name, string Surname = "Dmitrieva")
        {
            return new Homo(Name, Surname, BYear, false);
        }
        public static Homo CreateMan(uint BYear, string Name, string Surname = "Dmitriev")
        {
            return new Homo(Name, Surname, BYear, true);
        }
    }
}
