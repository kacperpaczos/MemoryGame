using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paczos.DataAccess.FS.Interfaces;

namespace Paczos.DataAccess.FS.AClasses
{
    internal abstract class FileLoader : IFileLoader
    {
        public abstract void Save(string path, object data);
        public abstract object Load(string path);
    }
}
