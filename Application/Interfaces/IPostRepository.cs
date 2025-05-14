using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<List<Post>> GetAllWithUsersAsync();
        Task<Post?> GetByIdWithUserAsync(Guid postId);
        Task<List<PostSummaryDto>> GetPostsByStadiumSlugAsync(string slug);
        Task<List<PostWithViewPermissionDto>> GetPostsByUserAsync(Guid targetUserId, Guid currentUserId);
    }
}
