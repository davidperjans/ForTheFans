using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Friendship
    {
        public Guid Id { get; set; }
        public Guid User1Id { get; set; }
        public Guid User2Id { get; set; }
        public DateTime Since { get; set; }


        // Navigering
        public User User1 { get; set; }
        public User User2 { get; set; }
    }
}
