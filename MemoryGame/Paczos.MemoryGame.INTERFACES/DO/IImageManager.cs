using System.Collections.Generic;

namespace Paczos.MemoryGame.INTERFACES.DO
{
    public interface IImageManager
    {
        void LoadImages(string folderPath);
        byte[] GetImageById(string id);
        void AddImage(string id, byte[] image);
        void RemoveImage(string id);
        void EditImage(string id, byte[] newImage);
        List<string> GetAllImageIds();
    }
}