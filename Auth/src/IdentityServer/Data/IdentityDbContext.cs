using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer.Models;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IdentityServer.Data
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //seed data
            UsersSeed(builder);
        }

        private void UsersSeed(ModelBuilder builder)
        {
            var password = "Jayanta@123";

            var jayanta = new ApplicationUser
            {
                Id = "1",
                UserName = "jayanta",
                NormalizedUserName = "JAYANTA",
                Email = "jayanta@jayantarimal.com.np",
                NormalizedEmail = "jayanta@jayantarimal.com.np".ToUpper(),
                EmailConfirmed = true
            };
            jayanta.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(jayanta, password);

            var code = new ApplicationUser
            {
                Id = "2",
                UserName = "code",
                NormalizedUserName = "CODE",
                Email = "code@code.com",
                NormalizedEmail = "code@code.com".ToUpper(),
                EmailConfirmed = true,
            };
            code.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(code, password);

            builder.Entity<ApplicationUser>()
                .HasData(jayanta, code);


            builder.Entity<IdentityUserClaim<string>>()
                .HasData(
                    new IdentityUserClaim<string>
                    {
                        Id = 1,
                        UserId = "1",
                        ClaimType = "name",
                        ClaimValue = "Jayanta Jayanta"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 2,
                        UserId = "1",
                        ClaimType = "given_name",
                        ClaimValue = "Jayanta"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 3,
                        UserId = "1",
                        ClaimType = "family_name",
                        ClaimValue = "Jayanta"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 4,
                        UserId = "1",
                        ClaimType = "email",
                        ClaimValue = "jayanta@jayanta.com"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 5,
                        UserId = "1",
                        ClaimType = "website",
                        ClaimValue = "https://jayantarimal.com.np"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 6,
                        UserId = "2",
                        ClaimType = "name",
                        ClaimValue = "Code Code"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 7,
                        UserId = "2",
                        ClaimType = "given_name",
                        ClaimValue = "Code"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 8,
                        UserId = "2",
                        ClaimType = "family_name",
                        ClaimValue = "Code"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 9,
                        UserId = "2",
                        ClaimType = "email",
                        ClaimValue = "code@code.com"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 10,
                        UserId = "2",
                        ClaimType = "website",
                        ClaimValue = "https://jayantarimal.com.np"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 11,
                        UserId = "1",
                        ClaimType = "email_verified",
                        ClaimValue = true.ToString()
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 12,
                        UserId = "2",
                        ClaimType = "email_verified",
                        ClaimValue = true.ToString()
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 13,
                        UserId = "1",
                        ClaimType = "address",
                        ClaimValue = @"{ 'street_address': 'Kathmandu', 'locality': 'Kathmandu', 'postal_code': 00000, 'country': 'Nepal' }"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 14,
                        UserId = "2",
                        ClaimType = "address",
                        ClaimValue = @"{ 'street_address': 'Kathmandu', 'locality': 'Kathmandu', 'postal_code': 00000, 'country': 'Nepal' }"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 15,
                        UserId = "1",
                        ClaimType = "location",
                        ClaimValue = "Nepal"
                    });
        }
    }
}
