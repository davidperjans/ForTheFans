using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFriendRepository
    {
        Task<bool> FriendRequestExistsAsync(Guid fromUserId, Guid toUserId);
        Task AddFriendRequestAsync(FriendRequest friendRequest);
        Task<FriendRequest?> GetFriendRequestByIdAsync(Guid requestId);
        Task AddFriendshipAsync(Friendship friendship);
        Task<List<User>> GetFriendsOfUserAsync(Guid userId);
        Task<Friendship?> GetFriendshipAsync(Guid userId, Guid friendId);
        Task RemoveFriendshipAsync(Friendship friendship);
        Task<List<FriendRequest>> GetRelevantFriendRequestsAsync(Guid userId);
        Task<bool> AreUsersAlreadyFriendsAsync(Guid user1Id, Guid user2Id);
    }
}
