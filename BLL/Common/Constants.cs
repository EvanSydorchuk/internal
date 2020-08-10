using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Common
{
    public static class Constants
    {
        public static class Models
        {
            public static Dictionary<ContactType, List<string>> ContactsListByContactType = new Dictionary<ContactType, List<string>>
            { 
                [ContactType.Post] = new List<string> { "Email" },
                [ContactType.SocaialNetwork] = new List<string> { "Facebook", "Twitter", "LinkedIn" },
                [ContactType.Telephone] = new List<string> { "Phone" },
                [ContactType.VoIPService] = new List<string> { "ICQ", "Skype" },
                [ContactType.Unknown] = new List<string>()
            };
        }
    }
}
