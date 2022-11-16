using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchingRegistry.Models
{
    public class MunicipalContract
    {
        public int Id { get; set; }
        public DateTime ContractDate { get; set; }
        public string MunicipalName { get; set; }
        public string LocalGovernment { get; set; }

        public Organisation Organisation { get; set; }
        public string Locality { get; set; }
        public CatchingAct CatchingAct { get; set; }

    }
}
