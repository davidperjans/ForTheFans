using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FavoriteTeam { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigeringsproperties
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<FriendRequest> SentFriendRequests { get; set; } = new List<FriendRequest>();
        public ICollection<FriendRequest> ReceivedFriendRequests { get; set; } = new List<FriendRequest>();
        public ICollection<Friendship> FriendshipsInitiated { get; set; } = new List<Friendship>();
        public ICollection<Friendship> FriendshipsReceived { get; set; } = new List<Friendship>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
