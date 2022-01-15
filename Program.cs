using System;

namespace Lab1Raik
{
    enum TimeFrame
    {
        Year = 1,
        TwoYears = 2,
        Long = 10
    }


    class Program
    {
        static void Main(string[] args)
        {

            //Task from first lab; 

            /*
            ResearchTeam res = new ResearchTeam();
            Console.WriteLine(res);
            Console.WriteLine(res[TimeFrame.Year]);
            Console.WriteLine(res[TimeFrame.TwoYears]);
            Console.WriteLine(res[TimeFrame.Long]);
            res.Number = 11;
            res.Organization = "OAO ISSLEDOVANIE";
            res.Period = TimeFrame.Long;
            res.Theme = "Water";
            Console.WriteLine(res);

            
            Person firstPerson = new Person("Maksim", "Raikov", new DateTime(2002, 08, 14));
            Paper firstPaper = new Paper("First Lab" , firstPerson, new DateTime(2021, 09, 14));
            Paper secondPaper = new Paper("First Lab2", new Person(), new DateTime(2021, 09, 14));

            //    res.AddPaper(firstPaper);
            Paper[] papers = { firstPaper, secondPaper };
            res.AddPapers(papers);
            Console.WriteLine(res);
            Console.WriteLine(res.Publication);


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Entern nrow ncolumn: ");
            string str = Console.ReadLine();
            string[] subs = str.Split(' ');
            int nrow = Int32.Parse(subs[0]);
            int ncolumn = Int32.Parse(subs[1]);
            Paper[] p1 = new Paper[nrow * ncolumn];
            Paper[,] p2 = new Paper[nrow, ncolumn];
            Paper[][] p3 = new Paper[nrow][];
            for(int i = 0; i < nrow; i++)
            {
                p3[i] = new Paper[ncolumn];
            }
            
           for(int i = 0; i < nrow*ncolumn; i++)
            {
                p1[i] = new Paper();
            }
           for(int i = 0; i <nrow; i++)
            {
                for(int j = 0; j < ncolumn; j++)
                {
                    p2[i, j] = new Paper();
                }
            }
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    p3[i][j] = new Paper();
                }
            }

        

            int first;
            //1
            first = Environment.TickCount;
            for (int i = 0; i < nrow * ncolumn; i++)
            {
                p1[i].PublicationName = i.ToString();
            }
            Console.WriteLine(Environment.TickCount - first);
            first = Environment.TickCount;
            //2
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    p2[i, j].PublicationName = i.ToString();
                }
            }
            Console.WriteLine(Environment.TickCount - first);
            first = Environment.TickCount;
            //3
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    p3[i][j].PublicationName = i.ToString();
                }
            }
            Console.WriteLine(Environment.TickCount - first);
            */


            //2

            /*
            Team t1 = new Team("Test", 123);
            Team t2 = new Team("Test", 123);


            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());

            Console.WriteLine("Reference: ");
            Console.WriteLine(Object.ReferenceEquals(t1, t2));
            Console.WriteLine("Identity: ");
            Console.WriteLine(t1 == t2);

            try
            {
                t1.RegNumber = -1;
            }
            catch(ArgumentOutOfRangeException a)
            {
                Console.WriteLine(a);
            }

            ResearchTeam researchTeam = new ResearchTeam();
            Person me = new Person("Maxim", "Raikov", new DateTime(2002, 08, 14));
            Person[] people = {new Person("Vladimir","Ulyanov",new DateTime(1870,04,22)), new Person("TestName","Testsurname", new DateTime(2021,12,12)), me };
            Paper[] publicationList = { new Paper(), new Paper(), new Paper("MyPublication", me, DateTime.Now) };

            researchTeam.AddMembers(people);
            researchTeam.AddPapers(publicationList);

            Console.WriteLine(researchTeam.ToString());

            Console.WriteLine();

            Console.WriteLine(researchTeam.Team);

            Console.WriteLine();

            ResearchTeam researchTeam1 = (ResearchTeam) researchTeam.DeepCopy();

            researchTeam.Name = "ChangedName";
            researchTeam.RegNumber = 30;
   

            Console.WriteLine(researchTeam.ToShortString());
            Console.WriteLine(researchTeam1.ToShortString());
            Console.WriteLine("Unpublicated Authors:");
            foreach(Person p in researchTeam.UnpublicatedAuthors())
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Publications for 2 years:");

            foreach (Paper p in researchTeam.NYearsPublications(2))
            {
                Console.WriteLine(p.ToString());
            }
            */

            //3 
            
            ResearchTeamCollection rtc = new ResearchTeamCollection();
            rtc.AddDefaults();
            ResearchTeam rs1 = new ResearchTeam("name1", "aaa", 1000, TimeFrame.TwoYears);
            ResearchTeam rs2 = new ResearchTeam("name2", "bbb", 300, TimeFrame.TwoYears);
            ResearchTeam rs3 = new ResearchTeam("name3", "ccc", 400, TimeFrame.Year);

            Person[] people2 = { new Person(), new Person() };
            Person[] people3 = { new Person(), new Person(), new Person() };

            Paper[] p = { new Paper(), new Paper(), new Paper() };

            rs1.AddPapers(p);

            rs1.AddMembers(people3);

            Paper[] p2 = { new Paper() };

            rs2.AddPapers(p2);

            rs2.AddMembers(people3);

            Paper[] p3 = { new Paper(), new Paper()};

            rs3.AddPapers(p3);


            rs3.AddMembers(people2);

            ResearchTeam[] rsArr = { rs1, rs3, rs2 };

            rtc.AddResearchTeams(rsArr);
            Console.WriteLine("No sort");
            Console.WriteLine(rtc.ToShortString());

            Console.WriteLine("Theme sort");
            rtc.SortByTheme();
            Console.WriteLine(rtc.ToShortString());

            Console.WriteLine("Amount of Publications sort");
            rtc.SortByAmountOfPublications();
            Console.WriteLine(rtc.ToShortString());

            Console.WriteLine("RegNumber sort");
            rtc.SortByRegNumber();
            Console.WriteLine(rtc.ToShortString());

            Console.WriteLine("Min RegNumber");
            Console.WriteLine(rtc.MinRegNumber);


            Console.WriteLine("Two Years");
            foreach(var r in rtc.TwoYears)
            {
                Console.WriteLine(r.ToShortString());
            }

            Console.WriteLine("Nmembers = 3");
            foreach (var item in rtc.NGroup(3))
            {
                Console.WriteLine(item.ToShortString());
            }


            TestCollections testCollections = new TestCollections(100000);

            Console.WriteLine("Search for 1");
            testCollections.SearchInCollections(1);


            Console.WriteLine("Search for 5000000");
            testCollections.SearchInCollections(50000);


            Console.WriteLine("Search for 9999999");
            testCollections.SearchInCollections(99999);


            Console.WriteLine("Search for 20000000");
            testCollections.SearchInCollections(2000000);
            


        }
    }
}
