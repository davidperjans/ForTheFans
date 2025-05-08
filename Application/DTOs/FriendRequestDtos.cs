using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SendFriendRequestDto
    {
        public Guid ToUserId { get; set; }
    }
    public class FriendRequestDto
    {
        public Guid RequestId { get; set; }
    }
    public class ReceivedFriendRequestDto
    {
        public Guid RequestId { get; set; }
        public Guid FromUserId { get; set; }
        public string FromUsername { get; set; }
        public string? FromProfilePictureUrl { get; set; }
        public DateTime SentAt { get; set; }
    }
}
