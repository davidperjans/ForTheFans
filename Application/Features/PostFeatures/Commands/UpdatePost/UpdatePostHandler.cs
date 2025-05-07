using Application.Common;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Commands.UpdatePost
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, OperationResult<bool>>
    {
        private readonly IPostRepository _postRepository;
        public UpdatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<OperationResult<bool>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);
            if (post == null)
                return OperationResult<bool>.Failure("Post not found");

            if (post.UserId != request.CurrentUserId)
                return OperationResult<bool>.Failure("You are not the owner of this post");

            var dto = request.Dto;

            if (dto.PhotoUrl is not null)
                post.PhotoUrl = dto.PhotoUrl;

            if (dto.Rating.HasValue)
                post.Rating = dto.Rating.Value;

            if (!string.IsNullOrEmpty(dto.Comment))
                post.Comment = dto.Comment;

            if (!string.IsNullOrWhiteSpace(dto.HomeTeam))
                post.HomeTeam = dto.HomeTeam;

            if (!string.IsNullOrWhiteSpace(dto.AwayTeam))
                post.AwayTeam = dto.AwayTeam;

            if (!string.IsNullOrWhiteSpace(dto.MatchResult))
                post.MatchResult = dto.MatchResult;

            await _postRepository.UpdateAsync(post);

            return OperationResult<bool>.Success(true);
        }
    }
}
