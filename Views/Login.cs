using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using CatchingRegistry.Controllers;
using CatchingRegistry.Models;

namespace CatchingRegistry.Views
{
    public partial class Login : Form
    {
        readonly private LoginController loginController;
        public Login()
        {
            InitializeComponent();

            loginController = new LoginController(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginController.Authorize("admin", "admin");
        }
    }
}
