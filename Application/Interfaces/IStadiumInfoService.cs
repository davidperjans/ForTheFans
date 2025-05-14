using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStadiumInfoService
    {
        Task<List<StadiumDto>> GetStadiumInfoAsync(string stadiumName);
    }
}
