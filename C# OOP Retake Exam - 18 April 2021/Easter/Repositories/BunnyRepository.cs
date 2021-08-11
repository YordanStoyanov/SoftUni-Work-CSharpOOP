using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Easter.Repositories.Contracts;
using Easter.Models.Bunnies.Contracts;
using System.Collections.ObjectModel;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private ICollection<IBunny> models;
        public BunnyRepository()
        {
            models = new Collection<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models { get; set; }

        public void Add(IBunny bunny)
        {
            this.models.Add(bunny);
        }

        public IBunny FindByName(string name)
        {
            IBunny bunny = models.FirstOrDefault(b => b.Name == name);
            if (bunny == null)
            {
                throw new ArgumentException();
            }
            return bunny;
        }

        public bool Remove(IBunny bunny)
        {
            if (bunny.Name == null)
            {
                return false;
            }
            return true;
            this.models.Remove(bunny);
        }
    }
}
