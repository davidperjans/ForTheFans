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

namespace Application.Features.FriendFeatures.Queries.GetFriends
{
    public class GetFriendsQueryHandler : IRequestHandler<GetFriendsQuery, OperationResult<List<FriendDto>>>
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;
        public GetFriendsQueryHandler(IFriendRepository friendRepository, IMapper mapper)
        {
            _friendRepository = friendRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<FriendDto>>> Handle(GetFriendsQuery request, CancellationToken cancellationToken)
        {
            var friends = await _friendRepository.GetFriendsOfUserAsync(request.UserId);

            var result = _mapper.Map<List<FriendDto>>(friends);

            return OperationResult<List<FriendDto>>.Success(result);
        }
    }
}
