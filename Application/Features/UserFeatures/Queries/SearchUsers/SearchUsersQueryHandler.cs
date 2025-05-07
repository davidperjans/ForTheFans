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

namespace Application.Features.UserFeatures.Queries.SearchUsers
{
    public class SearchUsersQueryHandler : IRequestHandler<SearchUsersQuery, OperationResult<List<UserInfoDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public SearchUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<UserInfoDto>>> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
        {
            var results = await _userRepository.SearchUsersAsync(request.Query, request.CurrentUserId);
            var dtoList = _mapper.Map<List<UserInfoDto>>(results);

            return OperationResult<List<UserInfoDto>>.Success(dtoList);
        }
    }
}
