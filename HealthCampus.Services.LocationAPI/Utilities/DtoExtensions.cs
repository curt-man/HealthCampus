using HealthCampus.Services.LocationAPI.Models;
using HealthCampus.Services.LocationAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.LocationAPI.Utilities
{
    public static class DtoExtensions
    {


        public static async Task<List<AddressResponseDto>> ToAddressResponseDtoListAsync(this IQueryable<Address> models)
        {
            var dtos = new List<AddressResponseDto>();
            await foreach (var model in models.AsAsyncEnumerable())
            {
                dtos.Add(AddressResponseDto.FromAddress(model));
            }
            foreach (var item in dtos)
            {
                
            }
            return dtos;
        }

    }
}
