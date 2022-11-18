using CatchingRegistry.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchingRegistry.Controllers
{
    public class FilterController
    {
        DataGridView dataGridViewRegistry;

        public FilterController(DataGridView dataGridViewRegistry)
        {
            this.dataGridViewRegistry = dataGridViewRegistry;
        }

    }
}
