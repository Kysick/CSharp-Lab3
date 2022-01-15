using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1Raik
{
    class Paper
    {
        private string publicationName;
        private Person author;
        private System.DateTime publicationDate;
        public Paper()
        {
            this.publicationName = "TestPubName";
            this.author = new Person();
            this.publicationDate = DateTime.Now;
        }

        public Paper(string publicationName, Person author, System.DateTime publicationDate)
        {
            this.publicationDate = publicationDate;
            this.publicationName = publicationName;
            this.author = author;
        }

        public string PublicationName {
            get {return publicationName; }
            set {publicationName = value; } 
        }
        public System.DateTime PublicationDate
        {
            get { return publicationDate; }
            set { publicationDate = value; }
        }
        public Person Author
        {
            get { return author; }
            set { author = value; }
        }

        public override string ToString()
        {
            return "[" + publicationName + " " + author.Name + " " + author.Surname + " " + publicationDate.ToString() + "]";
        }
    }
}
