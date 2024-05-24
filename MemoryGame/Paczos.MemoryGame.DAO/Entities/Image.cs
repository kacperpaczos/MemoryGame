using Paczos.MemoryGame.INTERFACES.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczos.MemoryGame.DAO.Entities
{
    public class Image : IImage
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
    }
}
