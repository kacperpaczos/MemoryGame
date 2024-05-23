using System;
using System.Collections.Generic;
using System.IO;
using Paczos.MemoryGame.INTERFACES.DO;

namespace Paczos.MemoryGame.DAO.DO
{
    public class ImageManager : IImageManager
    {
        private readonly Dictionary<string, byte[]> _images = new Dictionary<string, byte[]>();

        public void LoadImages(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*.png");

            foreach (var file in files)
            {
                byte[] imageData = File.ReadAllBytes(file);
                string id = Path.GetFileNameWithoutExtension(file);
                _images[id] = imageData;
            }
        }

        public byte[] GetImageById(string id)
        {
            _images.TryGetValue(id, out var image);
            return image;
        }

        public void AddImage(string id, byte[] image)
        {
            _images[id] = image;
        }

        public void RemoveImage(string id)
        {
            _images.Remove(id);
        }

        public void EditImage(string id, byte[] newImage)
        {
            if (_images.ContainsKey(id))
            {
                _images[id] = newImage;
            }
        }

        public List<string> GetAllImageIds()
        {
            return new List<string>(_images.Keys);
        }
    }
}