using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ5
{
    class Program
    {
        static void Main(string[] args)
        {
            



            //Players p = new Players();//если вызываем очередь
            Players1 p = new Players1();//если вызываем стек

            p.Enqueue("Ivan1");
            p.Enqueue("Ivan2");
            p.Enqueue("Ivan3");
            p.Enqueue("Ivan4");
            p.Enqueue("Ivan5");

            



            HotPotato hot = new HotPotato(p);           //создаем игру за счет интерфейса
            Random r = new Random();

            Console.WriteLine("Начало игры");
            int i = 1;
            while(!hot.GameOver)
            {
                


                int n = r.Next(1,20);                       //кол-во бросков
                Console.WriteLine("Шаг= {0}, n= {1}, игрок= {2},Count = {3} ", i, n,hot.Play(n),p.Count);

                i++;

            }

            Console.WriteLine("Победитель {0}",hot.Winner);
            Console.ReadKey();
        }
    }
}
