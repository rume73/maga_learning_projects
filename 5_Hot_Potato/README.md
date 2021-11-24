## Учебные проекты в магистратуре "Технология программирования на платформе .NET"

## Hot_Potato

### Задача

Написать класс HotPotato, эмулирующий игру в «Картошку» с использованием класса очередь.
- В конструктор данного класса передается экземпляр класса, реализующий интерфейс IQueue<T> в котором хранятся имена участников игры. 
- В классе HotPotato предусмотреть следующие методы и свойства:
    + string Play(int n) – метод эмулирующий перебрасывание мяча от одного игрока к следующему. Возвращает имя игрока, который выбывает из игры – тот игрок, кто оказался с мячом на n шаге.
    + bool GameOver – свойство, которое показывает что игра окончена (остался один участник).
    + string Winner – свойство, которое возвращает имя оставшегося участника – победителя. Возврат результата только в случае, когда игра окончена.
- В классе Main необходимо создать экземпляр класса игры и вызывать Play со случайным n до тех пор, пока игра не окончится. Выводить на каждом шаге имя выбывающего игрока, а после окончания игры вывести имя победителя. Все манипуляции со списком игроков ведутся через интерфейс IQueue<T>.