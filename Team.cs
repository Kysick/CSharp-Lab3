using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1Raik
{
    class Team : INameAndCopy, System.IComparable<Team>
    {
        protected string name;
        protected int regNumber;
        public Team(string _name, int _regNumber)
        {
            name = _name;
            regNumber = _regNumber;
        }
        public Team()
        {
            name = "DefaultName";
            regNumber = 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int RegNumber
        {
            get { return regNumber; }
            set { 
                if(value <= 0)
                    throw new ArgumentOutOfRangeException("Registarion number cant be negative or 0");
                regNumber = value;
            }
        }

        public virtual object DeepCopy()
        {
            return new Team(this.name, this.regNumber);
        }

        public override bool Equals(object obj)
        {
            var item = obj as Team;
            if (item == null)
            {
                return false;
            }
            return (this.name.Equals(item.name) && this.regNumber.Equals(item.regNumber));
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(name, regNumber);
        }

        public static bool operator !=(Team a, Team b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return false;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return true;
            }
            return !(a.name.Equals(b.name) && a.regNumber.Equals(b.regNumber));
        }
        public static bool operator ==(Team a, Team b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return ( a.name.Equals(b.name) && a.regNumber.Equals(b.regNumber));
        }


        public override string ToString()
        {
            return "Name: " + name + " RegNumber: " + regNumber;    
        }

        public int CompareTo( Team obj)
        {
            
            if (this.regNumber < obj.regNumber)
                return -1;
            if (this.regNumber > obj.regNumber)
                return 1;
            else
                return 0;
        }


    }
}
