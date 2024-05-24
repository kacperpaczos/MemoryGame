using Paczos.MemoryGame.INTERFACES.Entities;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Paczos.MemoryGame.INTERFACES.DO
{
    public interface IImageManager
    {
        void LoadImages(string folderPath);
        byte[] GetImageById(string id);
        void AddImage(string id, string name, byte[] image);
        void RemoveImage(string id);
        void EditImage(string id, string name, byte[] newImage);
        List<string> GetAllImageIds();
        List<IImageInfo> GetAllImagesWithNames();
        void SendImagesToDatabase(List<IImage> images);
        List<IImage> FetchImagesFromDatabase();
        void ClearLocalData();
    }
}