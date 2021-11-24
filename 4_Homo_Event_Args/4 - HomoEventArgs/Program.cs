using System;

namespace _4___HomoEventArgs
{
  
    class Program
    {
        static void Main(string[] args)
        {
            LifeInTown life1 = new LifeInTown(2020);//создание события жизнь
            uint[] manbyears = { 2000, 2002, 2004, 1995, 2001, 1955, 2007, 2010, 1993, 2000, 1983, 1999, 2015 };
            uint[] womanbyears = { 2001, 1968, 1992, 1987, 2012, 2013, 2014, 2002, 1996, 1993, 1981 };
            for (int i = 0; i < manbyears.Length; i++)
                life1.Add(HomoExtension.CreateMan(manbyears[i], "Mihail(" + i + ")"));  //добавляем людей муж. пола
            for (int i = 0; i < womanbyears.Length; i++)
                life1.Add(HomoExtension.CreateWoman(womanbyears[i], "Elena(" + i + ")")); //добавляем людей жен. пола
            Printing print = new Printing();
            for (int i = 0; i < life1.numhomo; i++)
                life1[i].AEvent += print.ObrabEvent;    //событие совершенолетия
            for (int i = 0; i < life1.numhomo; i++)
                life1[i].MEvent += print.ObrabEvent;    //событие жентьбы
            int y = 20;         //Продолжительность жизни 
            Console.WriteLine("Жизнь в городе N за последние " + y +" лет");
            Console.WriteLine("********************************");
            for (int i = 0; i < y; i++)
            {
                Console.WriteLine("Прошёл " + life1.Year + " год");
                life1.life();                                   //вызываем функцию, симулирующую жизнь
                Console.WriteLine("********************************");
            }
            Console.ReadLine();

        }
    }
}
