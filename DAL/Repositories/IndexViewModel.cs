using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class IndexViewModel<T>
    {
        public ICollection<T> Data { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
