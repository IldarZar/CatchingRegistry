using CatchingRegistry.Models;

namespace CatchingRegistry.Views
{
    public partial class Registry : Form
    {
        readonly private Employee employee;

        // Important to detect which filter form is opened and show last typed data
        private Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>();
        public Registry(Employee employee)
        {
            InitializeComponent();

            this.employee = employee;
            labelName.Text = employee.Name;
            labelRole.Text = employee.Role.Name;
            buttonAddRecord.Visible = employee.Role.CanUpdate;
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var filterForm = new Filter();

            var data = dataGridView1.Columns[0].Name;

            filterForm.Show();
        }

        private void buttonOpenCard_Click(object sender, EventArgs e)
        {
            var card = new Card();
            card.Show();
        }

        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
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