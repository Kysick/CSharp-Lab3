using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1Raik
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
