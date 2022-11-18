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
        Form formInstance;
        DataGridView dataGridViewRegistry;
        int columnIndex;
        Dictionary<string, string> dictionaryFilter;

        public FilterController(DataGridView dataGridViewRegistry, int columnIndex, Dictionary<string, string> dictionaryFilter)
        {
            this.formInstance = formInstance;
            this.dataGridViewRegistry = dataGridViewRegistry;
        }

        public void SetFilter(Dictionary<string, string> dictionaryFilter, string key, string value)
        {
            dictionaryFilter[key] = value;

            formInstance.Close();
        }
    }
}
