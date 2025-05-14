﻿using Application.Common.Responses;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StadiumInfoService : IStadiumInfoService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly HttpClient _client;
        private readonly string _apiKey;
        public StadiumInfoService(IMapper mapper, AppDbContext context, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _client = new HttpClient();
            _apiKey = configuration.GetValue<string>("ApiSettings:FootballApiKey");
            _client.DefaultRequestHeaders.Add("x-apisports-key", _apiKey);
        }

        public async Task<List<StadiumDto>> GetStadiumInfoAsync(string stadiumName)
        {
            // Check if the stadium already exists in the database
            var existingMatchningStadiums = await _context.Stadiums.Where(stadium => stadium.Name.Contains(stadiumName)).ToListAsync();

            if (existingMatchningStadiums.Any())
            {
                var stadiumDto = existingMatchningStadiums.Select(stadium => _mapper.Map<StadiumDto>(stadium)).ToList();
                return stadiumDto;
            }

            // If the stadium doesnt exist, call the API
            var response = await _client.GetAsync($"https://v3.football.api-sports.io/venues?search={stadiumName}");

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<StadiumApiResponse>(content);

            // List for storing mapped stadium DTOs
            var stadiumDtos = new List<StadiumDto>();

            foreach (var stadium in apiResponse.Response)
            {
                var newStadium = new Stadium
                {
                    Name = stadium.Name ?? "Uknown",
                    Slug = GenerateSlug(stadium.Name) ?? "Uknown",
                    Address = stadium.Address ?? "Uknown",
                    City = stadium.City ?? "Uknown",
                    Country = stadium.Country ?? "Uknown",
                    Capacity = stadium.Capacity > 0 ? stadium.Capacity : 0,
                    Surface = stadium.Surface ?? "Uknown",
                    ImageUrl = stadium.Image ?? "Uknown"
                };

                // Add the new stadium to the database
                _context.Stadiums.Add(newStadium);
                await _context.SaveChangesAsync();

                // Map the api-response to StadiumDto and add to the list
                stadiumDtos.Add(_mapper.Map<StadiumDto>(stadium));
            }

            return stadiumDtos;
        }
        private string GenerateSlug(string name)
        {
            return name?
                .ToLower()
                .Replace(" ", "-")
                .Replace(".", "")
                .Replace("'", "")
                .Replace(",", "")
                .Trim()!;
        }
    }
}
