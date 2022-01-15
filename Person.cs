using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1Raik
{
    class Person
    {
        private string name;
        private string surname;
        private System.DateTime date;

        public Person(string name, string surname, System.DateTime date)
        {
            this.name = name;
            this.surname = surname;
            this.date = date;
        }
        public Person()
        {
            this.name = "Ivan";
            this.surname = "Ivanov";
            this.date = DateTime.Now;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public System.DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int DateYear
        {
            get { return date.Year; }
            set { date.AddYears(value - date.Year);}
        }
        public override string ToString() {
            return "Name: " + name + " Surname: " + surname + " BirthDay: " + date.ToString(); 
        }
        
        public virtual string ToShortString()
        {
            return "Name: " + name + " Surname: " + surname;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Person;
            if(item == null)
            {
                return false; 
            }
            return (this.date.Equals(item.date) && this.name.Equals(item.name) && this.surname.Equals(item.surname));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, surname, date);
        }

        public static bool operator !=(Person a, Person b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return false;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return true;
            }
         return !(a.date.Equals(b.date) && a.name.Equals(b.name) && a.surname.Equals(b.surname));
        }
        public static bool operator ==(Person a, Person b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return (a.date.Equals(b.date) && a.name.Equals(b.name) && a.surname.Equals(b.surname));
        }
       

    }
}
