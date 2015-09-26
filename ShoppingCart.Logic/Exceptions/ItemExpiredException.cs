using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Logic.Exceptions
{
    public class ItemExpiredException : Exception
    {
        public ItemExpiredException(string itemName)
            : base("'" + itemName + "' has expired.")
        {
            
        }
    }
}
