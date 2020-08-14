using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanaguageFeatures.Models
{
    public interface IProductSelection
    {
        IEnumerable<Product> Products { get; }
    }
}
