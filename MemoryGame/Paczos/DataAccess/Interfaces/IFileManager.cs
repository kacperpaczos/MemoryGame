using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paczos.DataAccess.Interfaces
{
    internal interface IFileManager
    {
        void SaveText(string path, string data);
        string LoadText(string path);
        void SaveImage(string path, Image image);
        Image LoadImage(string path);
    }
}
