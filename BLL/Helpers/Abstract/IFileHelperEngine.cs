using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers.Abstract
{
    public interface IFileHelperEngine<T>
    {
        IEnumerable<T> LoadData();
    }
}
