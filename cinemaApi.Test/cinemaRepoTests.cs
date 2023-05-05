using Moq;
using cinemaApi.Models;
using FluentAssertions;
using cinemaApi.Repositories.BaseRepo;
using cinemaApi.Repositories.CinemaRepo;

namespace cinemaApi.Test;

public class CinemaRepoTests
{

    [Fact]
    public async void CinemaRepo_CreateCinema_ReturnsCinema()
    {
        //Arrange
        var request = new Cinema() { Id = 1, Name = "c1", OpeningHour = 13, ClosingHour = 16, ShowDuration = 60 };
        var mockRepo = new Mock<ICinemaRepo>();
        mockRepo.Setup(repo => repo.CreateAsync(request))
            .ReturnsAsync(new Cinema() { Id = 1, Name = "c1", OpeningHour = 13, ClosingHour = 16, ShowDuration = 60 });
        var cinemaRepo = mockRepo.Object;

        //Act
        var result = await cinemaRepo.CreateAsync(request);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Cinema>();
        result.Id.Should().BeGreaterThan(0);
    }

    [Fact]
    public async void CinemaRepo_GetCinema_ReturnsCinema()
    {
        //Arrange
        var mockRepo = new Mock<ICinemaRepo>();
        mockRepo.Setup(repo => repo.GetAsync(1))
            .ReturnsAsync(new Cinema() { Id = 1, Name = "c1", OpeningHour = 13, ClosingHour = 16, ShowDuration = 60 });
        var cinemaRepo = mockRepo.Object;

        //Act
        var result = await cinemaRepo.GetAsync(1);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Cinema>();
    }
}