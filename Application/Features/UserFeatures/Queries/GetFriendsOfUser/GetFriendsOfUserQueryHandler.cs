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

namespace Application.Features.UserFeatures.Queries.GetFriendsOfUser
{
    public class GetFriendsOfUserQueryHandler : IRequestHandler<GetFriendsOfUserQuery, OperationResult<List<UserInfoDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetFriendsOfUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<UserInfoDto>>> Handle(GetFriendsOfUserQuery request, CancellationToken cancellationToken)
        {
            var friends = await _userRepository.GetFriendsOfUserAsync(request.UserId);
            if (friends == null)
                return OperationResult<List<UserInfoDto>>.Failure("User not found or has no friends");

            var result = _mapper.Map<List<UserInfoDto>>(friends);

            return OperationResult<List<UserInfoDto>>.Success(result);
        }
    }
}
