using BaristaShop.Catalog.Dtos.SpecialOfferDtos;

namespace BaristaShop.Catalog.Services.SpecifalOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto specialOffer);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto specialOffer);
        Task DeleteSpecialOfferAsync(string id);
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
    }
}
