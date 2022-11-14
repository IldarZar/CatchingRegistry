using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchingRegistry.Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee Employee { get; set; }
    }
}
