using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Business.Filters
{
    public interface ICustomAttribute
    {
        public bool IsMandatory { get; }
    }
}
