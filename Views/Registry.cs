using CatchingRegistry.Controllers;
using CatchingRegistry.Models;
using System.Data;

namespace CatchingRegistry.Views
{
    public partial class Registry : Form
    {
        readonly private Employee employee;
        readonly private Context context;

        readonly private RegistryController registryController;
        readonly private CardController cardController;
        readonly private FilterController filterController;


        private int selectedRowIndex;
        private Dictionary<string, string> dictionaryFilter;

        public Registry(Employee employee)
        {
            InitializeComponent();
            dataGridViewRegistry.AutoGenerateColumns = false;
            this.employee = employee;

            labelName.Text = employee.Name;
            labelRole.Text = employee.Role.Name;
            buttonAddRecord.Visible = employee.Role.CanUpdate;

            registryController = new RegistryController(this);
            cardController = new CardController(this);

            context = new Context();




            dataGridViewRegistry.Columns.Add("Id", "Номер");
            dataGridViewRegistry.Columns.Add("DateTime", "Дата");
            dataGridViewRegistry.Columns.Add("CatchingPurpose", "Цель отлова");
            dataGridViewRegistry.Columns.Add("Animal", "Животные");
            dataGridViewRegistry.Columns["Animal"].Visible = false;

            registryController.UpdateRegistryTable(dataGridViewRegistry);


            FillFilterDictionary();
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void buttonOpenCard_Click(object sender, EventArgs e)
        {
            int catchingActId = (int) dataGridViewRegistry.Rows[selectedRowIndex].Cells["Id"].Value;
            var card = new Card(catchingActId);
            card.Show();
        }

        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
            //registryController.AddCatchingAct();
            var card = new Card();
            card.Show();
        }

        private void Registry_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonRemoveRecord_Click(object sender, EventArgs e)
        {
            //registryController.RemoveCatchingAct();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = new Button();
            button.Location = new Point(473, 500);
            button.Text = "123";
            Controls.Add(button);
        }

        private void dataGridViewRegistry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
        }

        private void dataGridViewRegistry_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: Пофиксить этот ужас
            if (e.RowIndex == -1)
            {
                //var filterForm = new Filter(registryController, 
                //    dataGridViewRegistry, 
                //    e.ColumnIndex, 
                //    dataGridViewRegistry.Columns[e.ColumnIndex].Name, 
                //    dictionaryFilter);



                registryController.ShowFilter(dictionaryFilter, dataGridViewRegistry, e);
            }
        }

        private void FillFilterDictionary()
        {
            dictionaryFilter = new Dictionary<string, string>();

            foreach (DataGridViewColumn column in dataGridViewRegistry.Columns)
                if (column.Visible)
                    dictionaryFilter.Add(column.Name, "");
            
        }
    }
}