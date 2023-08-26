using HealthCampus.CommonUtilities.Utilities;
using HealthCampus.Services.AuthenticationServiceAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthCampus.Services.AuthenticationServiceAPI.Data
{
    public class Seeder
    {
        private readonly AuthenticationDbContext _context;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly Random _random = new Random();

        public Seeder(AuthenticationDbContext context, RoleManager<IdentityRole<Guid>> roleManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        private void SeedLanguages()
        {
            if (_context.Languages.Any())
            {
                return;
            }
            _context.Languages.AddRange(
                new Language { Name = "English" },
                new Language { Name = "Polish" },
                new Language { Name = "German" },
                new Language { Name = "French" },
                new Language { Name = "Spanish" },
                new Language { Name = "Italian" },
                new Language { Name = "Russian" },
                new Language { Name = "Chinese" },
                new Language { Name = "Japanese" },
                new Language { Name = "Korean" },
                new Language { Name = "Arabic" },
                new Language { Name = "Hindi" },
                new Language { Name = "Portuguese" },
                new Language { Name = "Turkish" },
                new Language { Name = "Dutch" },
                new Language { Name = "Swedish" },
                new Language { Name = "Norwegian" },
                new Language { Name = "Danish" },
                new Language { Name = "Finnish" },
                new Language { Name = "Greek" },
                new Language { Name = "Czech" },
                new Language { Name = "Hungarian" },
                new Language { Name = "Romanian" },
                new Language { Name = "Bulgarian" },
                new Language { Name = "Croatian" },
                new Language { Name = "Slovak" },
                new Language { Name = "Ukrainian" },
                new Language { Name = "Hebrew" },
                new Language { Name = "Indonesian" },
                new Language { Name = "Malay" },
                new Language { Name = "Thai" },
                new Language { Name = "Kazakh" },
                new Language { Name = "Kyrgyz" }
            );
            _context.SaveChanges();
        }

        private void SeedProficiencies()
        {
            if (_context.Proficiencies.Any())
            {
                return;
            }
            _context.Proficiencies.AddRange(
                new Proficiency { Name = "Native" },
                new Proficiency { Name = "Fluent" },
                new Proficiency { Name = "Advanced" },
                new Proficiency { Name = "Intermediate" },
                new Proficiency { Name = "Beginner" }
            );
            _context.SaveChanges();
        }

        private void SeedGenders()
        {
            if (_context.Genders.Any())
            {
                return;
            }
            _context.Genders.Add(
                new Gender { Name = "Male", Description = "The Male gender." });
            _context.Genders.Add(
                new Gender { Name = "Female", Description = "The Female gender." });
            _context.Genders.Add(
                new Gender { Name = "Other", Description = "The Other gender." });

            _context.SaveChanges();
        }

        private void SeedUserStatuses()
        {
            _context.UserStatuses.AddRange(
                new UserStatus { Name = "Active", Description = "The Active status indicates that the user is currently engaged with the application and has unrestricted access to all features and functionalities." },
                new UserStatus { Name = "Inactive", Description = "The Inactive status signifies that the user is not currently engaged with the application." },
                new UserStatus { Name = "Banned", Description = "This Banned status indicates that the user is banned. Ban can be permanent or temporary." },
                new UserStatus { Name = "Deleted", Description = "The Deleted status represents that the user's account and associated data have been removed from the application." }
            );
            _context.SaveChanges();
        }

        private async Task SeedRolesAsync()
        {
            if (!_roleManager.Roles.Any())
            {
                List<IdentityRole<Guid>> roles = new List<IdentityRole<Guid>>
                {
                    new IdentityRole<Guid>(RolesAndPasswords.Admin.Role),
                    new IdentityRole<Guid>(RolesAndPasswords.SysAdmin.Role),
                    new IdentityRole<Guid>(RolesAndPasswords.Employee.Role),
                    new IdentityRole<Guid>(RolesAndPasswords.User.Role),
                    new IdentityRole<Guid>(RolesAndPasswords.Guest.Role)
                };
                foreach (var role in roles)
                {
                    await _roleManager.CreateAsync(role);
                }
            }
        }

        private void SeedAddresses()
        {
            if (_context.Addresses.Any())
            {
                return;
            }
            _context.Addresses.AddRange(
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
            );
            _context.SaveChanges();
        }


        private async Task SeedUsersAsync()
        {

            if (!_userManager.Users.Any())
            {
                List<byte> genderIds = _context.Genders.Select(g => g.Id).ToList();

                AppUser admin = new AppUser()
                {
                    FirstName = "Admin",
                    LastName = "Adminov",
                    SecondName = "Adminovich",
                    BirthDate = new DateTime(1000, 1, 1),
                    Email = "Admin@healthcampus.com",
                    RegistrationDate = DateTime.UtcNow,
                    PhoneNumber = "1234567890",
                    UserName = "Admin@healthcampus.com",

                };
                await _userManager.CreateAsync(admin, RolesAndPasswords.Admin.Password);
                await _userManager.AddToRoleAsync(admin, RolesAndPasswords.Admin.Role);

                AppUser sysAdmin = new AppUser()
                {
                    FirstName = "SysAdmin",
                    LastName = "SysAdminov",
                    SecondName = "SysAdminovich",
                    BirthDate = new DateTime(1500, 1, 1),
                    Email = "SysAdmin@healthcampus.com",
                    RegistrationDate = DateTime.UtcNow,
                    PhoneNumber = "0987654321",
                    UserName = "SysAdmin@healthcampus.com",
                    GenderId = genderIds[_random.Next(0, genderIds.Count)]

                };
                await _userManager.CreateAsync(sysAdmin, RolesAndPasswords.SysAdmin.Password);
                await _userManager.AddToRoleAsync(sysAdmin, RolesAndPasswords.SysAdmin.Role);

                AppUser employee = new AppUser()
                {
                    FirstName = "Employee",
                    LastName = "Employeenov",
                    SecondName = "Employeenovich",
                    BirthDate = new DateTime(2000, 1, 1),
                    Email = "Employee@healthcampus.com",
                    RegistrationDate = DateTime.UtcNow,
                    PhoneNumber = "1029384756",
                    UserName = "Employee@healthcampus.com",
                    GenderId = genderIds[_random.Next(0, genderIds.Count)]

                };
                await _userManager.CreateAsync(employee, RolesAndPasswords.Employee.Password);
                await _userManager.AddToRoleAsync(employee, RolesAndPasswords.Employee.Role);

                List<AppUser> users = new List<AppUser>()
                {
                    new AppUser
                    {
                        FirstName = "Elena",
                        LastName = "Ivanova",
                        SecondName = "Petrovna",
                        BirthDate = new DateTime(1988, 7, 5),
                        Email = "elena.petrovna@gmail.com",
                        RegistrationDate = DateTime.UtcNow.AddHours(-36),
                        PhoneNumber = "+996550987654",
                        UserName = "elena.petrovna@gmail.com"
                    },
                    new AppUser
                    {
                        FirstName = "Azamat",
                        LastName = "Abdullaev",
                        SecondName = "Rysbekovich",
                        BirthDate = new DateTime(1992, 11, 18),
                        Email = "azamat.rysbekovich@gmail.com",
                        RegistrationDate = DateTime.UtcNow.AddHours(-60),
                        PhoneNumber = "+996770543210",
                        UserName = "azamat.rysbekovich@gmail.com"
                    },
                    new AppUser
                    {
                        FirstName = "Eldar",
                        LastName = "Nurmatov",
                        SecondName = "Jenishovich",
                        BirthDate = new DateTime(1980, 9, 22),
                        Email = "eldar.jenishovich@gmail.com",
                        RegistrationDate = DateTime.UtcNow.AddHours(-12),
                        PhoneNumber = "+996555112233",
                        UserName = "eldar.jenishovich@gmail.com"
                    },

                    new AppUser
                    {
                        FirstName = "Aibek",
                        LastName = "Aibekov",
                        SecondName = "Bakytovich",
                        BirthDate = new DateTime(1995, 3, 12),
                        Email = "aibek.bakytovich@gmail.com",
                        RegistrationDate = DateTime.UtcNow.AddHours(-24),
                        PhoneNumber = "+996700123456",
                        UserName = "aibek.bakytovich@gmail.com"
                    },



                    new AppUser
                    {
                        FirstName = "Aliya",
                        LastName = "Sultanova",
                        SecondName = "Askarovna",
                        BirthDate = new DateTime(1997, 2, 8),
                        Email = "aliya.askarovna@gmail.com",
                        RegistrationDate = DateTime.UtcNow.AddHours(-72),
                        PhoneNumber = "+996702345678",
                        UserName = "aliya.askarovna@gmail.com"
                    },
                    new AppUser
                    {
                        FirstName = "Timur",
                        LastName = "Tursunov",
                        SecondName = "Tolibovich",
                        BirthDate = new DateTime(1997, 9, 8),
                        Email = "timur.tolibovich@gmail.com",
                        RegistrationDate = DateTime.UtcNow.AddHours(-120),
                        PhoneNumber = "+996702345612",
                        UserName = "timur.tolibovich@gmail.com"
                    },
                    new AppUser
                    {
                        FirstName = "Ekaterina",
                        LastName = "Sokolova",
                        SecondName = "Ivanovna",
                        BirthDate = new DateTime(1991, 12, 18),
                        Email = "ekaterina.ivanovna@gmail.com",
                        RegistrationDate = DateTime.UtcNow.AddHours(-132),
                        PhoneNumber = "+996772345623",
                        UserName = "ekaterina.ivanovna@gmail.com"
                    },
                    new AppUser
                    {
                        FirstName = "Bolot",
                        LastName = "Nurlanov",
                        SecondName = "Keldibekovich",
                        BirthDate = new DateTime(1989, 5, 27),
                        Email = "bolot.keldibekovich@gmail.com",
                        RegistrationDate = DateTime.UtcNow.AddHours(-144),
                        PhoneNumber = "+996707890123",
                        UserName = "bolot.keldibekovich@gmail.com"
                    },
                    new AppUser
                    {
                        FirstName = "Sofia",
                        LastName = "Sidorova",
                        SecondName = "Dmitrievna",
                        BirthDate = new DateTime(1993, 3, 7),
                        Email = "sofia.dmitrievna@gmail.com",
                        RegistrationDate = DateTime.UtcNow.AddHours(-156),
                        PhoneNumber = "+996555789034",
                        UserName = "sofia.dmitrievna@gmail.com"
                    },
                    new AppUser
                    {
                        FirstName = "Erkin",
                        LastName = "Bektemirov",
                        SecondName = "Kubanychbekovich",
                        BirthDate = new DateTime(1987, 8, 13),
                        Email = "erkin.kubanychbekovich@gmail.com",
                        RegistrationDate = DateTime.UtcNow.AddHours(-168),
                        PhoneNumber = "+996702312345",
                        UserName = "erkin.kubanychbekovich@gmail.com"
                    },
                    new AppUser
                    {
                        FirstName = "Aigul",
                        LastName = "Sadykova",
                        SecondName = "Mambetovna",
                        BirthDate = new DateTime(1990, 11, 25),
                        Email = "aigul.mambetovna@gmail.com",
                        RegistrationDate = DateTime.UtcNow.AddHours(-180),
                        PhoneNumber = "+996772301234",
                        UserName = "aigul.mambetovna@gmail.com"
                    }
                };

                foreach (var user in users)
                {
                    user.GenderId = genderIds[_random.Next(0, genderIds.Count)];
                    await _userManager.CreateAsync(user, RolesAndPasswords.User.Password);
                    await _userManager.AddToRoleAsync(user, RolesAndPasswords.User.Role);
                }

            }
        }

        private void SeedAppUsersAddresses()
        {
            if (_context.AppUsersAddresses.Any())
            {
                return;
            }
            List<Guid> appUsers = _context.AppUsers.Select(x => x.Id).ToList();
            List<Guid> addresses = _context.Addresses.Select(x => x.Id).ToList();
            for (int i = 0; i < appUsers.Count; i++)
            {
                _context.AppUsersAddresses.Add(
                    new AppUserAddress()
                    {
                        AppUserId = appUsers[i],
                        AddressId = addresses[i],
                        IsMainAddress = true,
                    });
            }
            if (addresses.Count > appUsers.Count)
            {
                var appUsersNumbers = getRandomNumberStack(0, appUsers.Count());
                for (int i = appUsers.Count; i < addresses.Count; i++)
                {
                    _context.AppUsersAddresses.Add(
                        new AppUserAddress()
                        {
                            AppUserId = appUsers[appUsersNumbers.Pop()],
                            AddressId = addresses[i],
                            IsMainAddress = false,
                        });
                }

            }
            _context.SaveChanges();
        }


        private void SeedAppUsersLanguages()
        {
            if (_context.AppUsersLanguages.Any())
            {
                return;
            }
            List<Guid> appUsers = _context.AppUsers.Select(x => x.Id).ToList();

            List<Language> languages = _context.Languages.ToList();
            var languagesNumbers = getRandomNumberStack(0, languages.Count);

            List<byte> proficiencies = _context.Proficiencies.Select(x => x.Id).ToList();

            for (int i = 0; i < appUsers.Count; i++)
            {
                var proficienciesNumbers = getRandomNumberStack(0, proficiencies.Count);
                _context.AppUsersLanguages.Add(
                    new AppUserLanguage()
                    {
                        AppUserId = appUsers[i],
                        LanguageId = languages.Where(x => x.Name == "Russian").First().Id,
                        ProficiencyId = proficiencies[proficienciesNumbers.Pop()],
                    });
                if (i % 2 == 0)
                {
                    _context.AppUsersLanguages.Add(
                        new AppUserLanguage()
                        {
                            AppUserId = appUsers[i],
                            LanguageId = languages.Where(x => x.Name == "Kyrgyz").First().Id,
                            ProficiencyId = proficiencies[proficienciesNumbers.Pop()],
                        });
                }
                if (i % 3 == 0)
                {
                    _context.AppUsersLanguages.Add(
                        new AppUserLanguage()
                        {
                            AppUserId = appUsers[i],
                            LanguageId = languages.Where(x => x.Name == "English").First().Id,
                            ProficiencyId = proficiencies[proficienciesNumbers.Pop()],
                        });
                }
                if (i % 5 == 0)
                {
                    _context.AppUsersLanguages.Add(
                       new AppUserLanguage()
                       {
                           AppUserId = appUsers[i],
                           LanguageId = languages.Where(x => x.Name != "English"
                                                          && x.Name != "Russian"
                                                          && x.Name != "Kyrgyz").First().Id,
                           ProficiencyId = proficiencies[proficienciesNumbers.Pop()],
                       });
                }

            }

            _context.SaveChanges();
        }

        private void SeedAppUsersUserStatuses()
        {
            if (_context.AppUsersUserStatuses.Any())
            {
                return;
            }
            List<Guid> appUsers = _context.AppUsers.Select(x => x.Id).ToList();

            List<byte> userStatuses = _context.UserStatuses.Select(x => x.Id).ToList();

            for (int i = 0; i < appUsers.Count; i++)
            {
                _context.AppUsersUserStatuses.Add(
                    new AppUserUserStatus()
                    {
                        AppUserId = appUsers[i],
                        UserStatusId = userStatuses[_random.Next(0, userStatuses.Count)],
                        LastTimeOnlineDate = DateTime.UtcNow.AddDays(-i/3)
                    }
                );
            }

            _context.SaveChanges();
        }


        public async Task SeedData()
        {
            SeedGenders();
            SeedLanguages();
            SeedProficiencies();
            SeedUserStatuses();
            SeedAddresses();
            await SeedRolesAsync();
            await SeedUsersAsync();
            SeedAppUsersLanguages();
            SeedAppUsersAddresses();
            SeedAppUsersUserStatuses();
        }

        Stack<int> getRandomNumberStack(int minValue, int maxValue)
        {
            Stack<int> numbers = new Stack<int>(Enumerable.Range(minValue, maxValue).OrderBy(x => _random.Next()).Take(maxValue - minValue));
            return numbers;
        }
    }
}
