using CatchingRegistry.Controllers;
using CatchingRegistry.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CatchingRegistry.Views
{
    public partial class Registry : Form
    {
        readonly private Employee employee;
        readonly private RegistryController registryController;
        readonly private Context context;
        private Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>();

        public Registry(Employee employee)
        {
            InitializeComponent();

            this.employee = employee;

            labelRole.Text = employee.Role.Name;
            buttonAddRecord.Visible = employee.Role.CanUpdate;


            registryController = new RegistryController(this);
            dataGridView1.DataSource = new DataSet();




            context = new Context();
            SqlDataAdapter adapter = new SqlDataAdapter();
            var query = context.CatchingActs.Select(catchingAct => new 
            { 
                Id = catchingAct.Id,
                AnimalId = catchingAct.Animal.Id,
                DateTime = catchingAct.DateTime,
                Purpose = catchingAct.CatchingPurpose
            });

            dataGridView1.DataSource = query.ToList();
        }   

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var filterForm = new Filter();

            var data = dataGridView1.Columns[0].Name;

            filterForm.Show();
        }

        private void buttonOpenCard_Click(object sender, EventArgs e)
        {
            var rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int catchingActId = (int) dataGridView1.Rows[rowIndex].Cells["Id"].Value;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = new Button();
            button.Location = new Point(373, 500);
            button.Text = "123";
            Controls.Add(button);
        }
    }
}