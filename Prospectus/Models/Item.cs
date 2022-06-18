using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Models
{
    public abstract class Item
    {
        public Guid Id { get; set; }

        public Item()
        {
            Id = new Guid();
        }

    }
}
