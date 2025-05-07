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

namespace Application.Features.FriendRequestFeatures.Queries.GetFriendRequests
{
    public class GetFriendRequestsQueryHandler : IRequestHandler<GetFriendRequestsQuery, OperationResult<List<ReceivedFriendRequestDto>>>
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;
        public GetFriendRequestsQueryHandler(IFriendRepository friendRepository, IMapper mapper)
        {
            _friendRepository = friendRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<ReceivedFriendRequestDto>>> Handle(GetFriendRequestsQuery request, CancellationToken cancellationToken)
        {
            var friendRequests = await _friendRepository.GetPendingFriendRequestsAsync(request.CurrentUserId);
            
            var result = _mapper.Map<List<ReceivedFriendRequestDto>>(friendRequests);

            return OperationResult<List<ReceivedFriendRequestDto>>.Success(result);
        }
    }
}
