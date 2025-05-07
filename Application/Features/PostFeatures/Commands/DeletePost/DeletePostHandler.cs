using Application.Common;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Commands.DeletePost
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, OperationResult<bool>>
    {
        private readonly IPostRepository _postRepository;
        public DeletePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<OperationResult<bool>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);

            if (post == null)
                return OperationResult<bool>.Failure("Post not found");

            if (post.UserId != request.CurrentUserId)
                return OperationResult<bool>.Failure("You are not the owner of this post");

            var result = await _postRepository.DeleteAsync(request.PostId);

            if (!result)
                return OperationResult<bool>.Failure("Failed to delete post");

            return OperationResult<bool>.Success(true);
        }
    }
}
