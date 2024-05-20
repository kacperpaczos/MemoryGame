using Paczos.DataAccess.FS.Loaders;
using Paczos.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paczos.DataAccess.FS
{
    internal class FileManager : IFileManager
    {
        private TextFileLoader textLoader = new TextFileLoader();
        private ImageFileLoader imageLoader = new ImageFileLoader();

        public void SaveText(string path, string data)
        {
            textLoader.Save(path, data);
        }

        public string LoadText(string path)
        {
            return (string)textLoader.Load(path);
        }

        public void SaveImage(string path, Image image)
        {
            imageLoader.Save(path, image);
        }

        public Image LoadImage(string path)
        {
            return (Image)imageLoader.Load(path);
        }
    }


}
