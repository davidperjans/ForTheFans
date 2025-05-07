using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Queries.GetFriendsPosts
{
    public class GetFriendsPostsQueryHandler : IRequestHandler<GetFriendsPostsQuery, OperationResult<List<PostDto>>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;
        public GetFriendsPostsQueryHandler(IPostRepository postRepository, IFriendRepository friendRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _friendRepository = friendRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<PostDto>>> Handle(GetFriendsPostsQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _postRepository.GetAllWithUsersAsync();

            var friends = await _friendRepository.GetFriendsOfUserAsync(request.UserId);
            var friendIds = friends.Select(friends => friends.Id).ToList();

            var visiblePosts = allPosts
                .Where(post => post.User.IsPrivate == false || friendIds.Contains(post.UserId))
                .ToList();

            var result = _mapper.Map<List<PostDto>>(visiblePosts);

            return OperationResult<List<PostDto>>.Success(result);
        }
    }
}
