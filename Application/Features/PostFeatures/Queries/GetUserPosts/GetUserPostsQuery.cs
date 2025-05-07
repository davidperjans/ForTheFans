using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Queries.GetUserPosts
{
    public class GetUserPostsQuery : IRequest<OperationResult<List<PostDto>>>
    {
        public Guid UserId { get; }
        public GetUserPostsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
