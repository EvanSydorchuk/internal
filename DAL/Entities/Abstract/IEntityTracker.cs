using System;

namespace DAL.Entities.Abstract
{
    public interface IEntityTracker
    {
        DateTime LastModified { get; set; }
        int TransactionID { get; set; }
    }
}
