using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid StadiumId { get; set; }
        public string PhotoUrl { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string MatchResult { get; set; }
        public DateTime CreatedAt { get; set; }


        // Navigering
        public User User { get; set; }
        public Stadium Stadium { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
