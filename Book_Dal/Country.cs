using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Dal
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<State> States { get; set; }
    }
}
