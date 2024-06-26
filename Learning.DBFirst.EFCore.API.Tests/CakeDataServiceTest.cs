using Learning.DBFirst.EFCore.API.Controller;
using Learning.DBFirst.EFCore.API.Data.Entities;
using Learning.DBFirst.EFCore.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Learning.DBFirst.EFCore.API.Tests
{
    public class CakeDataServiceTest
    {
        int successCode = 200;
        int notFound = 404;

        [Fact]
        public async Task GetAllCake_ShouldReturn200Status()
        {
            var cakeService = new Mock<ICake>();
            cakeService.Setup(_ => _.GetAll()).ReturnsAsync(GetProjectData());
            var getCake = new CakeController(cakeService.Object);

            var result = await getCake.GetAsync();
            var okObjectResult = (OkObjectResult)result;
            okObjectResult?.StatusCode.Value.Equals(200);
            Assert.Equal(successCode, okObjectResult?.StatusCode.Value);
        }

        [Fact]
        public async Task GetAllCake_ShouldReturn404Status()
        {
            var cakeService = new Mock<ICake>();
            cakeService.Setup(_ => _.GetAll()).ReturnsAsync(GetProjectData2());
            var getCake = new CakeController(cakeService.Object);
            var response = await getCake.GetAsync();
            var result = (NotFoundResult)response;
            Assert.Equal(notFound, result.StatusCode);
        }

        [Fact]
        public async Task GetCakeById_ShouldReturn200Status()
        {
            var cakeService = new Mock<ICake>();
            var ProjectList = GetProjectData();
            cakeService.Setup(_ => _.GetById(1)).ReturnsAsync(ProjectList[0]);
            var getCake = new CakeController(cakeService.Object);

            var result = await getCake.GetCakeByIdAsync(1);
            var okObjectResult = (OkObjectResult)result;
            okObjectResult?.StatusCode.Value.Equals(200);
            StatusCodeResult.Equals(okObjectResult?.StatusCode.Value, 200);
            Assert.Equal(successCode, okObjectResult?.StatusCode.Value);
        }

        [Fact]
        public async Task GetCakeById_ShouldReturn404Status()
        {
            var cakeService = new Mock<ICake>();
            var ProjectList = GetProjectData();
            cakeService.Setup(_ => _.GetById(5));
            var getCake = new CakeController(cakeService.Object);

            var result = await getCake.GetCakeByIdAsync(5);
            var notFoundResult = (NotFoundObjectResult)result;
            notFoundResult?.StatusCode.Equals(404);

            //Assert
            Assert.Equal(notFound, notFoundResult?.StatusCode);
        }

        [Fact]
        public async Task GetCakeById_ItemNotFound_ReturnsNotFoundObjectResult()
        {
            // Arrange
            var mockService = new Mock<ICake>();
            mockService.Setup(service => service.GetById(It.IsAny<int>()));

            var controller = new CakeController(mockService.Object);

            // Act
            var result = await controller.GetCakeByIdAsync(4);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            dynamic value = notFoundResult.Value;

            Assert.Equal(notFound, notFoundResult?.StatusCode);
        }

        private List<Cake> GetProjectData()
        {
            List<Cake> Project = new List<Cake>
            {
                new Cake {
                    Id = 1,
                    Name = "School Management System",
                    Price = 10.25M,
                    Description = "fdsfad"
                },
                new Cake {
                    Name = "Food System",
                    Price = 10.25M,
                    Description = "fdsfad"
                },
                new Cake {
                    Name = "Food System asdfds",
                    Price = 10.25M,
                    Description = "fdsdfsafdfad"
                },

            };
            return Project;

        }

        private List<Cake> GetProjectData2()
        {
            List<Cake> Project = new List<Cake>();
            return Project;

        }
    }
}