using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private ICollection<IEgg> eggs;
        public EggRepository()
        {
            this.eggs = new Collection<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models { get; set; }
        public void Add(IEgg egg)
        {
            this.eggs.Add(egg);
        }

        public IEgg FindByName(string name)
        {
            IEgg egg = eggs.FirstOrDefault(e => e.Name == name);
            if (egg == null)
            {
                throw new ArgumentException();
            }
            return egg;
        }

        public bool Remove(IEgg egg)
        {
            if (egg.Name == null)
            {
                return false;
            }
            return true;
            eggs.Remove(egg);
        }
    }
}
