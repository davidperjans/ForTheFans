using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string PhotoUrl { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string MatchResult { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StadiumId { get; set; }

        public string Username { get; set; }
        public bool IsPrivate { get; set; }
    }
    public class CreatePostDto
    {
        public int StadiumId { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public string HomeTeam { get; set; } = string.Empty;
        public string AwayTeam { get; set; } = string.Empty;
        public string MatchResult { get; set; } = string.Empty;
    }
    public class UpdatePostDto
    {
        public string? PhotoUrl { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public string? HomeTeam { get; set; }
        public string? AwayTeam { get; set; }
        public string? MatchResult { get; set; }
    }
    public class PostSummaryDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public bool IsPrivate { get; set; }
        public string PhotoUrl { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class PostWithViewPermissionDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PhotoUrl { get; set; }
        public bool CanView { get; set; }
    }

}
