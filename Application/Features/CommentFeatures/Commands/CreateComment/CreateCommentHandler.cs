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

namespace Application.Features.CommentFeatures.Commands.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, OperationResult<bool>>
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly IMapper _mapper;
        public CreateCommentHandler(IRepository<Comment> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<bool>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request.Dto);
            comment.UserId = request.UserId;
            comment.CreatedAt = DateTime.UtcNow;

            await _commentRepository.AddAsync(comment);

            return OperationResult<bool>.Success(true);
        }
    }
}
