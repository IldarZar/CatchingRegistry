using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatchingRegistry.Models;
using CatchingRegistry.Views;

namespace CatchingRegistry.Controllers
{
    internal class LoginController
    {
        private Form formInstance;
        public LoginController(Form instance)
        {
            formInstance = instance;
        }

        private void GetData(object sender, EventArgs e)
        {
        }

        public void Authorize(string name, string password)
        {
            var employee = new Employee(name, password);
            if (employee.IsUserExists())
            {
                var registry = new Registry(employee);
                registry.Show();
                formInstance.Hide();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}
