using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Stadium
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }


        // Navigering
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
