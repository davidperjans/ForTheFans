using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Queries.GetPostsByUser
{
    public class GetPostsByUserQuery : IRequest<OperationResult<List<PostWithViewPermissionDto>>>
    {
        public Guid TargetUserId { get; }
        public Guid CurrentUserId { get; }
        public GetPostsByUserQuery(Guid targetUserId, Guid currentUserId)
        {
            TargetUserId = targetUserId;
            CurrentUserId = currentUserId;
        }
    }
}
