using System;
using System.Collections.Generic;
using System.Text;

namespace _4___HomoEventArgs
{
    public enum HomoEvents { Adult, Marriage } 
    public class HomoEventArgs : EventArgs
    {
        public HomoEventArgs(HomoEvents h)
        {
            homoEvents = h;
        }
        public readonly HomoEvents homoEvents;
    }

    public delegate void MydelegateEventHandler(Object sender, HomoEventArgs events);
    class Homo
    {
        public event MydelegateEventHandler MEvent;  //Событие женитьбы 
        public event MydelegateEventHandler AEvent;  //Событие совершенолетия
        //public Homo()
        //{
        //    Name = "";
        //    Surname = "";
        //    BYear = 0;
        //    Gender = true;
        //}
        public Homo(uint BYear, bool Gender)
        {
            if (Gender == true)
            {
                this.Name = "Mihail";
                this.Surname = "Dmitriev";
            }
            else
            {
                this.Name = "Elena";
                this.Surname = "Dmitrieva";
            }
            this.BYear = BYear;
            this.Gender = Gender;
        }
        public Homo(string Name, string Surname, uint BYear, bool Gender) :this (BYear, Gender)
        {
            this.Name = Name;
            this.Surname = Surname;
            //this.BYear = BYear;
            //this.Gender = Gender;
        }
        public string Name;
        public string Surname;
        public uint BYear;
        public bool Gender;
        private Homo candidate;
        public Homo Partner
        {
            get { return candidate; }
            set { Marry(value); }
        }
        public void Print()
        {
            Console.WriteLine(string.Format($"Имя: {this.Name.ToString()} {this.Surname.ToString()}, {this.BYear.ToString()} г.р."));
        }
        public void Marry(Homo candidate1)
        {
            //if (Partner != null) throw new Exception("Есть супруг у 1-го ");
            //if (candidate.Partner != null) throw new Exception("Есть супруг у 2-го ");
            //if (this.Gender == Partner.Gender) throw new Exception("одинаковый пол");
            if (candidate1.Gender == this.Gender || candidate1.Partner != null || this.Partner != null)
                return;
            this.candidate = candidate1;                 //указатель на объект, который вызывает этот метод = человеку, на котором женат
            candidate1.candidate = this;                  //поле второго объекта женат = объекту, который вызывает метод

            //candidate.Partner = this;
            //this.Partner = candidate;
            if (MEvent != null)
                MEvent(this, new HomoEventArgs(HomoEvents.Marriage));
        }
        public void OnAdult(uint Year)
        {
            if (Year - this.BYear < 18) throw new Exception("несовершеннолетний");
            if (Year - this.BYear == 18)
                if (AEvent != null)
                    AEvent(this, new HomoEventArgs(HomoEvents.Adult));
        }
        //public override string ToString()
        //{
        //    return string.Format($"Имя: {Name} {Surname}, Год рождения: {Day}:{Month}:{Year}");
        //}
    }
}
