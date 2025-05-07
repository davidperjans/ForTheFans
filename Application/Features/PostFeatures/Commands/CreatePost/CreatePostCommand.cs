using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<OperationResult<bool>>
    {
        public Guid UserId { get; set; }
        public CreatePostDto Dto { get; set; }
        public CreatePostCommand(Guid userId, CreatePostDto dto)
        {
            UserId = userId;
            Dto = dto;
        }
    }
}
