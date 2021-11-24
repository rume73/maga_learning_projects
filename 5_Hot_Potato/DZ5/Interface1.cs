using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ5
{

    public class Players : IQueue<string>                   //наследуем или делаем по интерфейсу список игроков в формате очереди
    {
        Queue<string> players = new Queue<string>();

        public void Enqueue(string item)                    //добавить игроков
        {
            players.Enqueue(item);

        }

        public string Dequeue() => players.Dequeue();           //извлекать игроков 

        public int Count => players.Count();//свойство без скобок()         //количество в очереди 


    }


    public class Players1 : IQueue<string>
    {
        Stack<string> s1 = new Stack<string>();
        Stack<string> s2 = new Stack<string>();  //temp

        public void Enqueue(string item)                    //закинуть игрока
        {
            s1.Push(item);

        }

        public string Dequeue()                             //вытаскиваем игроков за счет: перекидывание из полного стека в пустой стек
        {
            while (s1.Count != 0)
                s2.Push(s1.Pop());
            string item = s2.Pop();

            while (s2.Count != 0)
                s1.Push(s2.Pop());
            return item;

        }

        public int Count => s1.Count();

    }
}
