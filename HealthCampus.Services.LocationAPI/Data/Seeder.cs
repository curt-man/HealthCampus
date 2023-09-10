
using HealthCampus.Services.LocationAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HealthCampus.Services.LocationAPI.Data
{
    public class Seeder
    {
        private readonly LocationDbContext _context;
        private readonly Random _random;

        public Seeder(LocationDbContext context, Random random)
        {
            _context = context;
            _random = random;
        }

        private void SeedAddresses()
        {
            if (_context.Addresses.Any())
            {
                return;
            }
            var addresses = new List<Address>()
            { 
                new Address { City = "Bishkek", Street = "Chuy Avenue", HouseNumber = "123", FlatNumber = "5A", ZipCode = "720001" },                                          
                new Address { City = "Osh", Street = "Lenin Street", HouseNumber = "45", FlatNumber = "2B", ZipCode = "723456" },                                              
                new Address { City = "Karakol", Street = "Ala-Too Square", HouseNumber = "7", FlatNumber = "9C", ZipCode = "722200" },                                         
                new Address { City = "Tokmok", Street = "Erkindik Avenue", HouseNumber = "56", FlatNumber = "8D", ZipCode = "721111" },                                        
                new Address { City = "Jalal-Abad", Street = "Manas Street", HouseNumber = "89", FlatNumber = "3E", ZipCode = "724321" },                                       
                new Address { City = "Talas", Street = "Zhibek Zholu Street", HouseNumber = "34", FlatNumber = "7F", ZipCode = "725500" },                                     
                new Address { City = "Naryn", Street = "Karl Marx Street", HouseNumber = "12", FlatNumber = "4G", ZipCode = "726600" },                                        
                new Address { City = "Batken", Street = "Victory Avenue", HouseNumber = "78", FlatNumber = "6H", ZipCode = "727777" },                                         
                new Address { City = "Isfana", Street = "Alamedin Street", HouseNumber = "23", FlatNumber = "5J", ZipCode = "728888" },                                        
                new Address { City = "Tash-Kumyr", Street = "Sovetskaya Street", HouseNumber = "67", FlatNumber = "2K", ZipCode = "729999" },                                  
                new Address { City = "Kara-Balta", Street = "Panfilov Street", HouseNumber = "90", FlatNumber = "1L", ZipCode = "720123" },                                    
                new Address { City = "Kant", Street = "Chingiz Aitmatov Avenue", HouseNumber = "43", FlatNumber = "4M", ZipCode = "720456" },                                  
                new Address { City = "Kyzyl-Kiya", Street = "Kurmanjan Datka Street", HouseNumber = "56", FlatNumber = "9N", ZipCode = "720789" },                             
                new Address { City = "Balykchy", Street = "Issyk-Kul Avenue", HouseNumber = "78", FlatNumber = "3P", ZipCode = "720012" },                                     
                new Address { City = "Talas", Street = "Manas Avenue", HouseNumber = "34", FlatNumber = "7Q", ZipCode = "720345" },                                            
                new Address { City = "Cholpon-Ata", Street = "Ryskulov Street", HouseNumber = "12", FlatNumber = "6R", ZipCode = "720678" },                                   
                new Address { City = "Karakol", Street = "Karagul Akmatova Street", HouseNumber = "67", FlatNumber = "8S", ZipCode = "720901" },                               
                new Address { City = "Naryn", Street = "Aaly Tokombaev Street", HouseNumber = "90", FlatNumber = "2T", ZipCode = "721234" },                                   
                new Address { City = "Tash-Kumyr", Street = "Toktogul Street", HouseNumber = "43", FlatNumber = "5U", ZipCode = "721567" },                                    
                new Address { City = "Osh", Street = "Frunze Avenue", HouseNumber = "56", FlatNumber = "1V", ZipCode = "721890" },                                             
                new Address { City = "Bishkek", Street = "Manas Street", HouseNumber = "78", FlatNumber = "4W", ZipCode = "722123" }
            };
            foreach (Address address in addresses)
            {
                address.CreatedAt = DateTime.UtcNow.AddDays(_random.Next(-30, 1)).AddHours(_random.Next(-23, 24)).AddMinutes(_random.Next(-60, 60)).AddSeconds(_random.Next(-60, 60));
            }
            _context.Addresses.AddRange(addresses);
            _context.SaveChanges();
        }

        //private void SeedAppUsersAddresses()
        //{
        //    if (_context.AppUsersAddresses.Any())
        //    {
        //        return;
        //    }
        //    List<Guid> appUsers = _context.AppUsers.Select(x => x.Id).ToList();
        //    List<Guid> addresses = _context.Addresses.Select(x => x.Id).ToList();
        //    for (int i = 0; i < appUsers.Count; i++)
        //    {
        //        _context.AppUsersAddresses.Add(
        //            new AppUserAddress()
        //            {
        //                AppUserId = appUsers[i],
        //                AddressId = addresses[i],
        //                IsMainAddress = true,
        //            });
        //    }
        //    if (addresses.Count > appUsers.Count)
        //    {
        //        var appUsersNumbers = getRandomNumberStack(0, appUsers.Count());
        //        for (int i = appUsers.Count; i < addresses.Count; i++)
        //        {
        //            _context.AppUsersAddresses.Add(
        //                new AppUserAddress()
        //                {
        //                    AppUserId = appUsers[appUsersNumbers.Pop()],
        //                    AddressId = addresses[i],
        //                    IsMainAddress = false,
        //                });
        //        }

        //    }
        //    _context.SaveChanges();
        //}


        public void Seed()
        {
            SeedAddresses();
        }
    }
}
