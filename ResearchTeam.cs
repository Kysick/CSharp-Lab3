using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace Lab1Raik
{
    class ResearchTeam : Team, System.Collections.Generic.IComparer<ResearchTeam>,System.ComponentModel.INotifyPropertyChanged
    {
        System.Collections.Generic.List<Person> members1;
        System.Collections.Generic.List<Paper> publications1;
        private string theme;
        private TimeFrame period;
        private List<Person> members = new List<Person>();
        private List<Paper> publications = new List<Paper>();
        enum Revision
        {
            Remove,
            Replace ,
            Property
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ResearchTeam(string _name, string _theme, int _regNumber, TimeFrame _period)
        {
            name = _name;
            theme = _theme;
            regNumber = _regNumber;
            period = _period;
        }

        public ResearchTeam()
        {
            name = "DefaultResearchName";
            theme = "DefaultTheme";
            regNumber = 1;
            period = TimeFrame.Year;
        }
        public List<Paper> Publications
        {
            get { return publications; }
            set { publications = value; }
        }
        public Paper LatestPublication
        {
            get {
                if (publications.Count == 0)
                    return null;
                System.DateTime date = new System.DateTime(0, 0, 0);
                Paper returnedP = new Paper();
                foreach (var p in publications)
                {
                    if (p.PublicationDate > date) {
                        date = p.PublicationDate;
                        returnedP = p;
                    }

                }
                return returnedP;
            }

        }
        public TimeFrame Period
        {
            get { return period; }
        }

        public void AddPapers(params Paper[] papers)
        {
            foreach (var p in papers)
            {
                publications.Add(p);
            }
        }

        public virtual string ToString()
        {
            string publicationsStr = "";
            foreach(Paper p in publications)
            {
                publicationsStr+=(p.ToString() + " ");
            }
            string membersStr = "";
            foreach (Person p in members)
            {
                membersStr += (p.ToString() + " ");
            }
            return "Organization Name: " + name + " RegNumber: " + regNumber.ToString() + " Theme: " + theme + " Period: " + period.ToString() +
                System.Environment.NewLine + " Publications: " + publicationsStr +
                System.Environment.NewLine + " Members " + membersStr;

        }
        public string ToShortString()
        {
            return "Organization Name: " + name + System.Environment.NewLine + " RegNumber " + regNumber.ToString() + " Theme " + theme + System.Environment.NewLine + " Period " + period.ToString() + " Amount of members:" 
                + members.Count.ToString() + " Amount of Publications: " + publications.Count.ToString() + " ";

        }

        public List<Person> Members
        {
            get { return members; }

        }

        public void AddMembers(params Person[] people)
        {
            foreach (var p in people)
            {
                members.Add(p);
            }
        }
        public virtual object DeepCopy()
        {
            ResearchTeam r = new ResearchTeam(name, theme, regNumber, period);
            r.publications = new List<Paper>(publications);
            r.members = new List<Person>(members);
            return r;
        }

        public Team Team
        {
            get { return new Team(name, regNumber); }
            set { 
                name = value.Name;
                regNumber = value.RegNumber;
                }

        }

        public  System.Collections.IEnumerable UnpublicatedAuthors()
        {

           foreach(Person person in members)
            {
                foreach (Paper p in publications)
                {
                    if (p.Author.Equals(person))
                        yield break;
                }
                yield return person;
            }


        }

        public System.Collections.IEnumerable NYearsPublications(int n)
        {
            foreach(Paper p in publications)
            {
                if(System.DateTime.Now.Year - p.PublicationDate.Year  <= n)
                    yield return p;
            }
        }

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return (x.theme.CompareTo(y.theme));
        }
    }
}
