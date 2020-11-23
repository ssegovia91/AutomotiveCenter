using AutomotiveCenter.Application.Entities;
using AutomotiveCenter.Application.Services;
using AutomotiveCenter.Infrastructure.Context;
using AutomotiveCenter.Infrastructure.Interfaces;
using AutomotiveCenter.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AutomotiveCenter.Infrastructure.Integration.Tests
{
    public class RolesIntegrationTest
    {
        [Fact(Skip ="using db data")]
        public async void Test1()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<AutomotiveCenterContext>()
               .UseSqlServer("Server=localhost;Database=AutomotiveCenter;Trusted_Connection=True;")
               .Options;

            using (var autoCenterContext = new AutomotiveCenterContext(options))
            {                
                var foo = new RoleRepository(autoCenterContext);

                Role role = new Role()
                {
                    roleName = "Standard",
                    UserNameCreated = "SysAdmin"
                };

                var result = await foo.SaveRole(role);

                Assert.True(result > 0);                
            }
        }
    }
}
