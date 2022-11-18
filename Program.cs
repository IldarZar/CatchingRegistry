using Microsoft.EntityFrameworkCore;
using CatchingRegistry.Models;
using CatchingRegistry.Controllers;
using CatchingRegistry.Views;

namespace CatchingRegistry
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}