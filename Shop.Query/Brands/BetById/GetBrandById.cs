using Common.Application;
using Shop.Query.DTOs.Brands;

namespace Shop.Query.Brands.BetById
{
    public record GetBrandById(int Id) : IBaseRequest<BrandDto>;
}