using CatchingRegistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchingRegistry.Controllers
{
    public class CardController
    {
        private Form formInstance;
        private Context context;
        public CardController(Form formInstance)
        {
            this.formInstance = formInstance;
            this.context = new Context();
        }

        public void AddAnimals(IEnumerable<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                context.Animals.Add(animal);
                context.SaveChanges();
            }
        }
    }
}
