using System;

namespace DAL.Entities
{
    public class Contact
    {
        public Guid ContactID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public ContactType ContactType { get; set; }

        public Candidate Candidate { get; set; } 
    }

    public enum ContactType : byte
    {
        VoIPService,
        SocaialNetwork,
        Post,
        Telephone,
        Unknown
    }
}
