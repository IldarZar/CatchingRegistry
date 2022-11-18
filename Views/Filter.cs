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
        private Action action;
        private Dictionary<string, string> dictionaryFilter;
        private string key;

        public Filter(string key, Dictionary<string, string> dictionaryFilter, Action action)
        {
            InitializeComponent();

            textBoxFilter.Text = dictionaryFilter[key];
            this.action = action;
            this.dictionaryFilter = dictionaryFilter;
            this.key = key;
        }

        private void buttonSearchByWord_Click(object sender, EventArgs e)
        {
            dictionaryFilter[key] = textBoxFilter.Text;
            action();
            Close();
        }
    }
}
