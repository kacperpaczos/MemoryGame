using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paczos.MemoryGame.INTERFACES.DO;

namespace Paczos.MemoryGame.DAO.DO
{
    public class ImageInfo : IImageInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
