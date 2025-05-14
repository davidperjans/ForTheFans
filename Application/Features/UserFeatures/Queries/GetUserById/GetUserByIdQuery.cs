using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<OperationResult<UserDetailDto>>
    {
        public Guid UserId { get; set; }
        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
