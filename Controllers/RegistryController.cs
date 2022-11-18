using CatchingRegistry.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchingRegistry.Controllers
{
    public class RegistryController
    {
        Form formInstance;
        Context context;
        public RegistryController(Form formInstance)
        {
            this.formInstance = formInstance;
            this.context = new Context();
        }

        public void AddCatchingAct(CatchingAct catchingAct)
        {
            context.CatchingActs.Add(catchingAct);
            context.SaveChanges();
        }

        public void RemoveCatchingAct(int catchingActId)
        {
            context.CatchingActs.Remove(new CatchingAct
            {
                Id = catchingActId
            });

            context.SaveChanges();
        }

        public void UpdateCatchingAct(int catchingActId, CatchingAct newCatchingAct)
        {
            CatchingAct? catchingAct = context.CatchingActs.Find(catchingActId);

            if (catchingAct != null)
            {
                catchingAct.Animal = newCatchingAct.Animal;
                catchingAct.CatchingPurpose = newCatchingAct.CatchingPurpose;
                catchingAct.DateTime = newCatchingAct.DateTime;
                // ...

                context.SaveChanges();
            }
        }

        public void UpdateRegistryTable(DataGridView dataGridViewRegistry)
        {
            dataGridViewRegistry.Rows.Clear();
            var catchingActs = context.CatchingActs.ToList();

            foreach (var catchingAct in catchingActs)
                dataGridViewRegistry.Rows.Add(catchingAct.Id, catchingAct.DateTime, catchingAct.CatchingPurpose);
        }

        public void UpdateRegistryTable(DataGridView dataGridViewRegistry, Dictionary<string, string> dictionaryFilter)
        {
            StringBuilder queryBuilder = new StringBuilder("SELECT Id, DateTime, CatchingPurpose FROM CatchingActs");

            // TODO: Для двух и более параметров добавить AND
            foreach (KeyValuePair<string, string> filter in dictionaryFilter)
            {
                if (filter.Value != "")
                {
                    if (!queryBuilder.ToString().Contains(" WHERE "))
                        queryBuilder.Append(" WHERE ");
                    queryBuilder.Append($" {filter.Key} LIKE '%{filter.Value}%'");
                }
            }

            var catchingActs = context.CatchingActs.FromSqlRaw(queryBuilder.ToString());


            dataGridViewRegistry.Rows.Clear();

            foreach (var catchingAct in catchingActs)
                dataGridViewRegistry.Rows.Add(catchingAct.Id, catchingAct.DateTime, catchingAct.CatchingPurpose);
        }
    }
}
