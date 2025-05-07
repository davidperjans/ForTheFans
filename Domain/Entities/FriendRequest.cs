using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FriendRequest
    {
        public Guid Id { get; set; }
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime? AcceptedOrRejectedAt { get; set; }


        // Navigering
        public User FromUser { get; set; }
        public User ToUser { get; set; }
    }
}
