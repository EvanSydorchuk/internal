using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DAL.Entities.Abstract;

namespace DAL.Entities
{
    public class Candidate : IEntityTracker
    {
        public Guid CandidateID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Location { get; set; }
        public string Competence { get; set; }
        public string CompetenceLevel { get; set; }

        public DateTime LastModified { get; set; }
        public int TransactionID { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public Candidate()
        {
            Contacts = new Collection<Contact>();
        }

        public Candidate(Guid candidateGuid) : this()
        {
            CandidateID = candidateGuid;
        }
    }
}
