using System.Collections.Generic;
using Common.Application;
using Common.Core.Enums;
using Shop.Query.DTOs.Brands;

namespace Shop.Query.Brands.GetByFilter
{
    public record GetBrandByFilter(string Name) : IBaseQueryFilter<List<BrandDto>>
    {
        public SearchOn SearchOn { get; set; } = SearchOn.All;
    }
}