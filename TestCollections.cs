using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Lab1Raik
{
    class TestCollections : System.ComponentModel.INotifyPropertyChanged
    {


        private System.Collections.Generic.List<Team> teamsKey;
        private System.Collections.Generic.List<string> stringsKey;
        private System.Collections.Generic.Dictionary<Team, ResearchTeam> keyValuePairs1;
        private System.Collections.Generic.Dictionary<string, ResearchTeam> keyValuePairs2;

      
        public event PropertyChangedEventHandler PropertyChanged;

        public static ResearchTeam GetResearchTeams(int n)
        {
            return new ResearchTeam();
        }

        public TestCollections(int n)
        {
            teamsKey = new List<Team>(n);
            stringsKey = new List<string>(n);
            keyValuePairs1 = new Dictionary<Team, ResearchTeam>(n);
            keyValuePairs2 = new Dictionary<string, ResearchTeam>(n);

            for (int i = 0; i < n; i++) {
                teamsKey.Add(new Team(i.ToString(),i));
                stringsKey.Add(i.ToString());
                keyValuePairs1.Add(new Team(i.ToString(), i), new ResearchTeam(i.ToString(), "Default", i,TimeFrame.Long));
                keyValuePairs2.Add(i.ToString(), new ResearchTeam(i.ToString(), "Default", i, TimeFrame.Long));
            }
        }

        public void SearchInCollections(int n)
        {
            Console.WriteLine("Team Search:");
            int time = Environment.TickCount;
            Console.WriteLine(teamsKey.Contains(new Team {Name = n.ToString(), RegNumber = n }));
            Console.WriteLine("Position: " + teamsKey.IndexOf(new Team { Name = n.ToString(), RegNumber = n }));
            Console.WriteLine(Environment.TickCount - time);
            time = Environment.TickCount;
            Console.WriteLine("String Search:");
            Console.WriteLine(stringsKey.Contains(n.ToString()));
            Console.WriteLine("Position: " + stringsKey.IndexOf(n.ToString()));
            Console.WriteLine(Environment.TickCount - time);

            Console.WriteLine("Team/ResearchTeam");
            Console.WriteLine("Team/ResearchTeam search by key");
            time = Environment.TickCount;
            Console.WriteLine(keyValuePairs1.ContainsKey(new Team { Name = n.ToString(), RegNumber = n }));
            Console.WriteLine("Position: " + keyValuePairs1.Keys.ToList().IndexOf((new Team { Name = n.ToString(), RegNumber = n })));
            Console.WriteLine(Environment.TickCount - time);

            Console.WriteLine("Team/ResearchTeam search by value");
            time = Environment.TickCount;
            Console.WriteLine(keyValuePairs1.ContainsValue(new ResearchTeam { Name = n.ToString(), RegNumber = n }));
            Console.WriteLine(keyValuePairs1.Values.ToList().IndexOf((new ResearchTeam { Name = n.ToString(), RegNumber = n })));
            Console.WriteLine(Environment.TickCount - time);
            Console.WriteLine("String/ResearchTeam");
            Console.WriteLine("String/ResearchTeam search by key");

            time = Environment.TickCount;
            Console.WriteLine(keyValuePairs2.ContainsKey(n.ToString()));
            Console.WriteLine("Position: " + keyValuePairs2.Keys.ToList().IndexOf((n.ToString())));
            Console.WriteLine(Environment.TickCount - time);
            Console.WriteLine("String/ResearchTeam search by value");
            time = Environment.TickCount;
            Console.WriteLine(keyValuePairs2.ContainsValue(new ResearchTeam { Name = n.ToString(), RegNumber = n }));
            Console.WriteLine("Position: " + keyValuePairs2.Values.ToList().IndexOf((new ResearchTeam { Name = n.ToString(), RegNumber = n })));
            Console.WriteLine(Environment.TickCount - time);

            Console.WriteLine("Finished");



        }



    }
}
