using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.Common.Entities
{
    public class SalesCustomer
    {
        public int BusinessEntityID { get; set; }
	    
        public string FirstName { get; set; }
	    
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public decimal SalesLastYear { get; set; }
    }
}
