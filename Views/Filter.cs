using CatchingRegistry.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchingRegistry.Views
{
    public partial class Filter : Form
    {
        RegistryController registryController;
        DataGridView dataGridViewRegistry;
        int columnIndex;
        string key;
        Dictionary<string, string> dictionaryFilter;

        public Filter(RegistryController registryController, DataGridView dataGridViewRegistry, int columnIndex, string key, Dictionary<string, string> dictionaryFilter)
        {
            InitializeComponent();

            this.key = key;
            this.registryController = registryController;
            this.dataGridViewRegistry = dataGridViewRegistry;
            this.columnIndex = columnIndex;
            this.dictionaryFilter = dictionaryFilter;

            textBoxFilter.Text = dictionaryFilter[key];
        }

        private void buttonSearchByWord_Click(object sender, EventArgs e)
        {
            dictionaryFilter[key] = textBoxFilter.Text;

            registryController.UpdateRegistryTable(dataGridViewRegistry, dictionaryFilter);

            Close();
        }
    }
}
