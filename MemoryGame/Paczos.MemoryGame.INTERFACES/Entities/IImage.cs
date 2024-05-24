using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Paczos.MemoryGame.INTERFACES.Entities
{
    public interface IImage
    {
        string Id { get; set; }
        string Name { get; set; }
        byte[] ImageData { get; set; }
    }
}
