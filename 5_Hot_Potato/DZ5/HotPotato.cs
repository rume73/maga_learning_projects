using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ5
{
    class HotPotato
    {
        IQueue<string> queue;               

        public HotPotato(IQueue<string> queue)      //конструктор класса, с параметром очереди
        {
            this.queue = queue;
        }




        public bool GameOver => (queue.Count > 1) ? false : true;   //свойство







        public string Play(int n)
        {
            if (queue.Count == 0) throw new Exception("пустая очередь"); //проверка на пустоту очереди

                string name;
            

            if (!GameOver)                          //если игра не закончена, то мы играем
            {
                for (int i = 1; i < n ; i++)        //n - кол-во бросков, на n-ном шаге человек с мячиком выбывает
                {
                                                    //сортировка очереди (свап игроков) сначала 1ый встает в конец, потом 2ой за первым и т.д. 
                    name = queue.Dequeue();         //извлекаем из начала     
                    queue.Enqueue(name);            //закидываем в конец
                    
                }
                name = queue.Dequeue();             //извлекаем проигравшего
                

            }
            else name = Winner;                     //игроков == 1, объявляется победителем


            return name;
        }


        public string Winner //свойство               //извлекаем виннера
        {


            get
            {

            string name="";

            if (queue.Count == 1)
            {name = queue.Dequeue();      }
            return name;

            }
            
        }

       

    }
}
