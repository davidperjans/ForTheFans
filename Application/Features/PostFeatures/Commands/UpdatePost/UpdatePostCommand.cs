using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<OperationResult<bool>>
    {
        public Guid PostId { get; }
        public Guid CurrentUserId { get;}
        public UpdatePostDto Dto { get; }
        public UpdatePostCommand(Guid postId, Guid currentUserId, UpdatePostDto dto)
        {
            PostId = postId;
            CurrentUserId = currentUserId;
            Dto = dto;
        }
    }
}
