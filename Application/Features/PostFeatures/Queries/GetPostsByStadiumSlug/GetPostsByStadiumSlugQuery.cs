using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeatures.Queries.GetPostsByStadiumSlug
{
    public class GetPostsByStadiumSlugQuery : IRequest<OperationResult<List<PostSummaryDto>>>
    {
        public string Slug { get; }
        public GetPostsByStadiumSlugQuery(string slug)
        {
            Slug = slug;
        }
    }
}
