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
        public Guid StadiumId { get; set; }
    }
    public class CreatePostDto
    {
        public Guid StadiumId { get; set; }
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

}
