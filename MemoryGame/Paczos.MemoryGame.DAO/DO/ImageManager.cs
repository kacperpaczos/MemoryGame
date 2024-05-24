using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Paczos.MemoryGame.DAO.Entities;
using Paczos.MemoryGame.INTERFACES.DO;
using Paczos.MemoryGame.INTERFACES.Entities;

namespace Paczos.MemoryGame.DAO.DO
{
    public class ImageManager : IImageManager
    {
        private readonly DAOContext _context;

        public ImageManager(DAOContext context)
        {
            _context = context;
        }

        public void LoadImages(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*.png");
            foreach (var file in files)
            {
                byte[] imageData = File.ReadAllBytes(file);
                string id = GenerateUniqueId();
                string name = Path.GetFileName(file);
                AddImage(id, name, imageData);
            }
        }

        private string GenerateUniqueId()
        {
            string id;
            do
            {
                id = Guid.NewGuid().ToString();
            } while (_context.Images.Any(i => i.Id == id));
            return id;
        }

        public byte[] GetImageById(string id)
        {
            var image = _context.Images.FirstOrDefault(i => i.Id == id);
            return image?.ImageData;
        }

        public void AddImage(string id, string name, byte[] image)
        {
            var newImage = new Image
            {
                Id = id,
                Name = name,
                ImageData = image
            };
            _context.Images.Add(newImage);
            _context.SaveChanges();
        }

        public void RemoveImage(string id)
        {
            var image = _context.Images.FirstOrDefault(i => i.Id == id);
            if (image != null)
            {
                _context.Images.Remove(image);
                _context.SaveChanges();
            }
        }

        public void EditImage(string id, string name, byte[] newImage)
        {
            var image = _context.Images.FirstOrDefault(i => i.Id == id);
            if (image != null)
            {
                image.Name = name;
                image.ImageData = newImage;
                _context.SaveChanges();
            }
        }

        public List<string> GetAllImageIds()
        {
            return _context.Images.Select(i => i.Id).ToList();
        }

        public List<IImageInfo> GetAllImagesWithNames()
        {
            return _context.Images.Select(i => new ImageInfo { Id = i.Id, Name = i.Name }).Cast<IImageInfo>().ToList();
        }

        public void SendImagesToDatabase(List<IImage> images)
        {
            _context.Images.RemoveRange(_context.Images);
            foreach (var image in images)
            {
                AddImage(image.Id, image.Name, image.ImageData);
            }
            _context.SaveChanges();
        }

        public List<IImage> FetchImagesFromDatabase()
        {
            // Implementacja pobierania obrazów z bazy danych
            return _context.Images.Cast<IImage>().ToList();
        }

        public void ClearLocalData()
        {
            _context.Images.RemoveRange(_context.Images);
            _context.SaveChanges();
        }
    }
}