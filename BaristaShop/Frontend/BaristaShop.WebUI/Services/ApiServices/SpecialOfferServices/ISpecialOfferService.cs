using BaristaShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;

namespace BaristaShop.WebUI.Services.ApiServices.SpecialOfferServices
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
