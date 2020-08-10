using System;
using System.Collections.Generic;
using ChoETL;
using BLL.Common;
using BLL.Common.Models.ChoETL;
using BLL.Helpers.Abstract;
using DAL.Entities;

namespace BLL.Helpers
{
    public class CandidatesCSVFileHelperEngine : IFileHelperEngine<Candidate>
    {
        private string _path { get; set; }

        public CandidatesCSVFileHelperEngine(string path)
        {
            _path = path;
        }

        public IEnumerable<Candidate> LoadData()
        {
            var candidates = new List<Candidate>();

            foreach (var candidate in new ChoCSVReader<CandidateModel>(_path).WithDelimiter(",").WithFirstLineHeader(true))
            { 
                var entityGuid = Guid.NewGuid();

                var entity = new Candidate()
                {
                    CandidateID = entityGuid,
                    Name = candidate.Name,
                    Surname = candidate.Surname,
                    Location = candidate.Location,
                    Competence = candidate.Competence,
                    CompetenceLevel = candidate.CompetenceLevel,
                    Contacts = GetFormattedContacts(candidate.Contacts),
                    LastModified = DateTime.Now,
                    TransactionID = new Random().Next(0, 10000)
                };

                entity.Contacts.ForEach(x => x.Candidate = entity);

                candidates.Add(entity);
            }

            return candidates;
        }

        private List<Contact> GetFormattedContacts(string contactsModel)
        {
            if (string.IsNullOrWhiteSpace(contactsModel))
            {
                return null;
            }

            var contacts = new List<Contact>();
            var splitContacts = contactsModel.Split(';');

            foreach (var contact in splitContacts)
            {
                var splitContact = contact.Split('=');

                if (string.IsNullOrWhiteSpace(splitContact[0]) || string.IsNullOrWhiteSpace(splitContact[1]))
                {
                    continue;
                }

                contacts.Add(new Contact()
                {
                    Name = splitContact[0],
                    Value = splitContact[1],
                    ContactType = GetContactType(splitContact[0])
                });
            }

            return contacts;
        }

        private ContactType GetContactType(string nameOfContact)
        {
            foreach (var item in Constants.Models.ContactsListByContactType)
            {
                if (item.Value.Contains(nameOfContact.Trim()))
                {
                    return item.Key;
                }
            }

            return ContactType.Unknown;
        }
    }
}
