using Application.Common;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Commands.CreatePost
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, OperationResult<bool>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public CreatePostHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<bool>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            //Mappa dto till post
            var post = _mapper.Map<Post>(dto);
            post.UserId = request.UserId;

            await _postRepository.AddAsync(post);

            return OperationResult<bool>.Success(true);
        }
    }
}
