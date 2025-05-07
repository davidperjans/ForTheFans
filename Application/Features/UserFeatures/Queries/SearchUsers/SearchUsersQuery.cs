using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries.SearchUsers
{
    public class SearchUsersQuery : IRequest<OperationResult<List<UserInfoDto>>>
    {
        public string Query { get; }
        public Guid CurrentUserId { get; set; }
        public SearchUsersQuery(string query, Guid currentUserId)
        {
            Query = query;
            CurrentUserId = currentUserId;
        }
    }
}
