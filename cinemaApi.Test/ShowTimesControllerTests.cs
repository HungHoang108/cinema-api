using cinemaApi.Controllers;
using FluentAssertions;
using cinemaApi.Models;
using cinemaApi.Database;
using cinemaApi.Services.CinemaService;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace cinemaApi.Test
{
    public class ShowTimesControllerTests
    {

        private readonly DataContext _context;
        private readonly ICinemaService _service;

        public ShowTimesControllerTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "test")
            .Options;

            var configuration = A.Fake<IConfiguration>();
            _context = new DataContext(options, configuration);
            _service = A.Fake<ICinemaService>();
        }

        [Fact]
        public async Task CinemaController_GetShowTimes_ReturnsCorrectResult()
        {
            // Arrange
            var id = 1;
            var open = 16;
            var close = 3;
            var length = 120;
            var cinema = new Cinema { Id = 1, Name = "c1", OpeningHour = 13, ClosingHour = 16, ShowDuration = 60 };

            var controller = new CinemaController(_context, _service);

            // Act
            var result = await controller.GetShowTimes(id, open, close, length);

            // Assert
            result.Should().NotBeNull();
            var expected = new List<Tuple<int, int>> { Tuple.Create(16, 0), Tuple.Create(18, 15), Tuple.Create(20, 30), Tuple.Create(22, 45) };
            Assert.Equal(expected, result.Value!);

        }
    }
}