using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Queries.GetPostsByStadiumSlug
{
    public class GetPostsByStadiumSlugQueryHandler : IRequestHandler<GetPostsByStadiumSlugQuery, OperationResult<List<PostSummaryDto>>>
    {
        private readonly IPostRepository _postRepository;
        public GetPostsByStadiumSlugQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<OperationResult<List<PostSummaryDto>>> Handle(GetPostsByStadiumSlugQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetPostsByStadiumSlugAsync(request.Slug);

            if (posts == null)
                return OperationResult<List<PostSummaryDto>>.Failure("No posts found");


            return OperationResult<List<PostSummaryDto>>.Success(posts);
        }
    }
}
