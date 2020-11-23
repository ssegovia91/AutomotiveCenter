using AutomotiveCenter.Application.Entities;
using AutomotiveCenter.Infrastructure.Context;
using AutomotiveCenter.Infrastructure.Interfaces;
using AutomotiveCenter.Infrastructure.Repositories;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace AutomotiveCenter.Infrastructure.Unit.Tests
{
    public class RolesUnitTest
    {
        readonly Mock<AutomotiveCenterContext> _autoCenterContext;        

        public RolesUnitTest()
        {
            _autoCenterContext = new Mock<AutomotiveCenterContext>();            
        }

        [Fact]
        public async void Test1()
        {
            //Arrange
            _autoCenterContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            var roleRepository = new RoleRepository(_autoCenterContext.Object);

            //Act
            var result = await roleRepository.SaveRole(new Role());

            //Assert
            Assert.IsType<long>(result);
            Assert.True(result > 0);

        }
    }
}
