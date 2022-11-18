using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchingRegistry.Models
{
    public class CatchingAct
    {
        public int Id { get; set; }
        public ICollection<Animal> Animal { get; set; }
        public DateTime DateTime { get; set; }
        public string CatchingPurpose { get; set; }


        public void ExportWordDocument()
        {

        }
    }
}
