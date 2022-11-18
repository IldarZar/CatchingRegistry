using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchingRegistry.Models
{
    public class Animal
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Features { get; set; }
    }
}
