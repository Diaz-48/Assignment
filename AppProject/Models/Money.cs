using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppProject.Models
{
    public class Money
    {

        public int pennies { get; set; }
        public int nickels { get; set; }
        public int dimes { get; set; }
        public int quarters { get; set; }

        public Money(int _pennies, int _nickels, int _dimes, int _quarters)
        {
            this.pennies = _pennies;
            this.nickels = _nickels;
            this.dimes = _dimes;
            this.quarters = _quarters;
        }

        public string ToString()
        {
            return "{pennies: " + this.pennies.ToString() + ", nickels: " + this.nickels.ToString() + ", dimes: " + this.dimes.ToString() + ", quarters: " + this.quarters.ToString() + "}"; 
        }
    }
}
