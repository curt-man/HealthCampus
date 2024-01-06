using Microsoft.EntityFrameworkCore;

namespace HealthCampus.Services.LocationAPI.Models.Dtos.Mapper
{
    public static class AddressMapper
    {

        public static Address ToAddress(this AddressCreateDto dto)
        {
            return new Address()
            {
                Id = Guid.NewGuid(),
                City = dto.City,
                Street = dto.Street,
                HouseNumber = dto.HouseNumber,
                FlatNumber = dto.FlatNumber,
                ZipCode = dto.ZipCode
            };
        }

        public static AddressResponseDto ToAddressResponseDto(this Address model)
        {
            return new AddressResponseDto()
            {
                Id = model.Id,
                City = model.City,
                Street = model.Street,
                HouseNumber = model.HouseNumber,
                FlatNumber = model.FlatNumber,
                ZipCode = model.ZipCode,
            };
        }

        public static async Task<List<AddressResponseDto>> ToAddressResponseDtoListAsync(this IQueryable<Address> models)
        {
            var dtos = new List<AddressResponseDto>();
            await foreach (var model in models.AsAsyncEnumerable())
            {
                dtos.Add(model.ToAddressResponseDto());
            }
            return dtos;
        }

        public static Address ToAddress(this AddressUpdateDto dto)
        {
            return new Address()
            {
                Id = dto.Id,
                City = dto.City,
                Street = dto.Street,
                HouseNumber = dto.HouseNumber,
                FlatNumber = dto.FlatNumber,
                ZipCode = dto.ZipCode
            };
        }
    }
}
