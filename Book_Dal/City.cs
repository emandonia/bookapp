using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Dal
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }
    }
}
