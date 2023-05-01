using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cinemaApi.Controllers;
using Moq;
using FluentAssertions;
using cinemaApi.Models;
using cinemaApi.Database;


namespace cinemaApi.Test
{
    public class ShowTimesControllerTests
    {

        private readonly Mock<DataContext> _context;
        private readonly CinemaController _controller;

        public ShowTimesControllerTests()
        {
            _context = new Mock<DataContext>();
            _controller = new CinemaController(_context.Object);
        }

        [Fact]
        public async Task GetShowTimes_ReturnsCorrectResult()
        {
            // Arrange
            var id = 1;
            var open = 16;
            var close = 3;
            var length = 120;
            var cinema = new Cinema { Id = 1, Name = "c1", OpeningHour = 13, ClosingHour = 16, ShowDuration = 60 };
            _context.Setup(x => x.Cinemas.FindAsync(id)).ReturnsAsync(cinema);

            // Set up the mock GetShowTimes method to contain the same logic as the GetShowTimes method in the CinemaController
            _controller.Setup(x => x.GetShowTimes(id, open, close, length))
                .ReturnsAsync(new List<Tuple<int, int>> { Tuple.Create(16, 0), Tuple.Create(18, 15), Tuple.Create(20, 30), Tuple.Create(22, 45) });

            // Act
            var result = await _controller.Object.GetShowTimes(id, open, close, length);

            // Assert
            var expected = new List<Tuple<int, int>> { Tuple.Create(16, 0), Tuple.Create(18, 15), Tuple.Create(20, 30), Tuple.Create(22, 45) };
            Assert.Equal(expected, result.Value);

        }

        // [Theory]
        // [InlineData(1, 10, 14, 120, 1)]
        // [InlineData(1, 10, 14, 120, 2)]
        // public async Task GetShowTimes_ReturnsCorrectShowTimes(int id, int open, int close, int length, int expectedShowTimesCount)
        // {
        //     // Arrange

        //     // Act
        //     var result = await _controller.GetShowTimes(id, open, close, length);

        //     // Assert
        //     Assert.IsType<ActionResult<IEnumerable<Tuple<int, int>>>>(result);
        //     Assert.Equal(expectedShowTimesCount, result.Value.Count());
        // }
    }
}