using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Business.Filters
{
    public class CustomAttribute
    {
        public readonly bool ContainsAttribute;
        public readonly bool Mandatory;

        public CustomAttribute(bool containsAttribute, bool mandatory)
        {
            ContainsAttribute = containsAttribute;
            Mandatory = mandatory;
        }
    }
}
