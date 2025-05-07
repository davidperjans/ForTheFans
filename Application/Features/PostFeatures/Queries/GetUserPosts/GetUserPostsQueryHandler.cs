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

namespace Application.Features.PostFeatures.Queries.GetUserPosts
{
    public class GetUserPostsQueryHandler : IRequestHandler<GetUserPostsQuery, OperationResult<List<PostDto>>>
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IMapper _mapper;
        public GetUserPostsQueryHandler(IRepository<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<PostDto>>> Handle(GetUserPostsQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _postRepository.GetAllAsync();
            var userPosts = allPosts.Where(p => p.UserId == request.UserId).ToList();

            var result = _mapper.Map<List<PostDto>>(userPosts);

            return OperationResult<List<PostDto>>.Success(result);
        }
    }
}
