using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczos.DataAccess.FS.Interfaces
{
    internal interface IFileLoader
    {
        void Save(string path, object data);
        object Load(string path);
    }
}
