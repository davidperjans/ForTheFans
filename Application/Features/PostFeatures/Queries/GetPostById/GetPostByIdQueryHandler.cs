using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Queries.GetPostById
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, OperationResult<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;
        public GetPostByIdQueryHandler(IPostRepository postRepository, IFriendRepository friendRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _friendRepository = friendRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<PostDto>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdWithUserAsync(request.PostId);

            if (post == null)
                return OperationResult<PostDto>.Failure("Post not found");

            var isOwner = post.UserId == request.CurrentUserId;

            if (!isOwner && post.User.IsPrivate == true)
            {
                var friends = await _friendRepository.GetFriendsOfUserAsync(request.CurrentUserId);
                var isFriend = friends.Any(f => f.Id == post.UserId);

                if (!isFriend)
                    return OperationResult<PostDto>.Failure("This posts owner is private and you are not friends");
            }

            var postDto = _mapper.Map<PostDto>(post);

            return OperationResult<PostDto>.Success(postDto);
        }
    }
}
