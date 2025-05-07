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

namespace Application.Features.CommentFeatures.Queries.GetComments
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, OperationResult<List<CommentDto>>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentsQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<CommentDto>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetCommentsWithUserAsync(request.PostId);

            var result = _mapper.Map<List<CommentDto>>(comments);

            return OperationResult<List<CommentDto>>.Success(result);
        }
    }
}
