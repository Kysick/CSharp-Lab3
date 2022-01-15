using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Raik
{
    class ResearchTeamCollection
    {
        private System.Collections.Generic.List<ResearchTeam> researchTeams;


        public void AddDefaults()
        {
            researchTeams = new System.Collections.Generic.List<ResearchTeam>();
            researchTeams.Add(new ResearchTeam());   
        }

        public void AddResearchTeams(params ResearchTeam[] rs)
        {
            researchTeams.AddRange(rs);
            
        }

        public override string ToString()
        {
            string streturn ="";
            foreach(var rs in researchTeams)
            {
                streturn += rs.ToString();
            }
            return streturn;
        }

        public string ToShortString()
        {
            string streturn = "";
            foreach (var rs in researchTeams)
            {
                streturn += rs.ToShortString();
            }
            return streturn;
        }

        public void SortByRegNumber()
        {
            researchTeams.Sort();
        }
        public void SortByTheme()
        {
            researchTeams.Sort(new ResearchTeam());
        }
        public void SortByAmountOfPublications()
        {
            researchTeams.Sort(new ComparerByPublicationsAmount());
        }

        public int MinRegNumber
        {
            get
            {
                if (researchTeams.Count == 0)
                    return 0;
                return researchTeams.Min(r => r.RegNumber);
            }
        }
        public IEnumerable<ResearchTeam> TwoYears
        {
            get
            {
                return researchTeams.Where(r => r.Period == TimeFrame.TwoYears);
            }
        }

        public List<ResearchTeam> NGroup(int value)
        {
            List<ResearchTeam> output = new List<ResearchTeam>();
            var NMembersTeams = researchTeams.GroupBy(r => r.Members.Count);
            foreach (var group in NMembersTeams)
            {
                if(group.Key == value)
                {
                    foreach(ResearchTeam r in group)
                    {
                        output.Add(r);
                    }
                }
            }
            return output;
          
           
        }




    }
}
