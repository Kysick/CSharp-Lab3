using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab1Raik
{
    class ComparerByPublicationsAmount : System.Collections.Generic.IComparer<ResearchTeam>
    {
        public int Compare( ResearchTeam x,  ResearchTeam y)
        {
            if (x.Publications.Count < y.Publications.Count)
                return 1;
            if (x.Publications.Count > y.Publications.Count)
                return -1;
            else
                return 0;
        }
    }
}
