using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Queries.GetPostsByUser
{
    public class GetPostsByUserQueryHandler : IRequestHandler<GetPostsByUserQuery, OperationResult<List<PostWithViewPermissionDto>>>
    {
        private readonly IPostRepository _postRepository;
        public GetPostsByUserQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<OperationResult<List<PostWithViewPermissionDto>>> Handle(GetPostsByUserQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetPostsByUserAsync(request.TargetUserId, request.CurrentUserId);
            return OperationResult<List<PostWithViewPermissionDto>>.Success(posts);
        }
    }
}
