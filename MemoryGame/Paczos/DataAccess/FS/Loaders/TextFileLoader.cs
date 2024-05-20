using Paczos.DataAccess.FS.AClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Paczos.DataAccess.FS.Loaders
{
    internal class TextFileLoader : FileLoader
    {
        public override void Save(string path, object data)
        {
            if (data is string text)
            {
                File.WriteAllText(path, text);
            }
            else
            {
                throw new ArgumentException("Data must be a string.");
            }
        }

        public override object Load(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
