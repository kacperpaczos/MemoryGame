using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczos
{
    internal interface IMap
    {
        ImageState[,] GetImageStates();
    }
}

