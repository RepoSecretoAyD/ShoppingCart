using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Logic.Exceptions
{
    public class InsufficientQuantityException : Exception
    {
        public InsufficientQuantityException(string itemName)
            : base("'" + itemName + "' is either out of stock or there is an insufficient amount of it.")
        {
            
        }
    }
}
