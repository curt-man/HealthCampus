using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HealthCampus.Services.LocationAPI.Models.Dtos
{
    /// <summary>
    /// DTO representing a address in response form.
    /// </summary>
    public class AddressResponseDto
    {
        /// <summary>
        /// Unique identifier of the address.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// City of the address.
        /// </summary>
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// Street of the address.
        /// </summary>
        [MaxLength(50)]
        public string Street { get; set; }

        /// <summary>
        /// House number of the address.
        /// </summary>
        [MaxLength(50)]
        public string HouseNumber { get; set; }

        /// <summary>
        /// Flat number of the address.
        /// </summary>
        [MaxLength(50)]
        public string FlatNumber { get; set; }

        /// <summary>
        /// Zip code of the address.
        /// </summary>
        [StringLength(6)]
        public string ZipCode { get; set; }


        public override string ToString()
        {
            return $"{City}, {Street} {HouseNumber}/{FlatNumber}, {ZipCode}";
        }

        public static AddressResponseDto FromAddress(Address model)
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

        public static async Task<List<AddressResponseDto>> FromAddressQueryableAsync(IQueryable<Address> models)
        {
            var dtos = new List<AddressResponseDto>();
            await foreach (var model in models.AsAsyncEnumerable())
            {
                dtos.Add(FromAddress(model));
            }
            return dtos;
        }

    }
}
