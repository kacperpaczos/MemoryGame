using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Paczos.DataAccess.FS.AClasses;
using System.Drawing;

namespace Paczos.DataAccess.FS.Loaders
{
    internal class ImageFileLoader : FileLoader
    {
        public override void Save(string path, object data)
        {
            if (data is Image image)
            {
                image.Save(path);
            }
            else
            {
                throw new ArgumentException("Data must be an Image.");
            }
        }

        public override object Load(string path)
        {
            return Image.FromFile(path);
        }
    }
}

