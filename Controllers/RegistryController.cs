using CatchingRegistry.Models;
using CatchingRegistry.Views;
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
            StringBuilder queryBuilder = new StringBuilder("SELECT ");
            List<string> filterConditions = new List<string>();




            foreach (KeyValuePair<string, string> filter in dictionaryFilter)
            {
                queryBuilder.Append($"{filter.Key}");

                if (dictionaryFilter.Last().Key != filter.Key)
                    queryBuilder.Append(", ");
                else
                    queryBuilder.Append(" ");
            }



            queryBuilder.Append("FROM CatchingActs");




            // TODO: Для двух и более параметров добавить AND
            foreach (KeyValuePair<string, string> filter in dictionaryFilter)
            {
                if (filter.Value != "")
                {
                    if (!queryBuilder.ToString().Contains(" WHERE "))
                        queryBuilder.Append(" WHERE ");

                    filterConditions.Add($" {filter.Key} LIKE '%{filter.Value}%'");
                }
            }

            if (filterConditions.Count > 1)
            {
                var conditions = string.Join(" AND ", filterConditions);
                queryBuilder.Append(conditions);
            }
            else if (filterConditions.Count == 1)
            {
                queryBuilder.Append(filterConditions[0]);
            }

            var catchingActs = context.CatchingActs.FromSqlRaw(queryBuilder.ToString());


            dataGridViewRegistry.Rows.Clear();

            foreach (var catchingAct in catchingActs)
                dataGridViewRegistry.Rows.Add(catchingAct.Id, catchingAct.DateTime, catchingAct.CatchingPurpose);
        }

        public void ShowFilter(Dictionary<string, string> dictionaryFilter, DataGridView dataGridViewRegistry, DataGridViewCellEventArgs e)
        {
            string key = dataGridViewRegistry.Columns[e.ColumnIndex].Name;

            var filterForm = new Filter(
                key,
                dictionaryFilter, 
                () => UpdateRegistryTable(dataGridViewRegistry, dictionaryFilter)
            );
            filterForm.Show();
        }
    }
}
