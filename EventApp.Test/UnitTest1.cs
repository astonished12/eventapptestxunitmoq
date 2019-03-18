using EventApp.Data.Entities;
using EventApp.Data.Infrastructure;
using EventApp.Services.EventService;
using EventApp.Services.EventService.EventDtos;
using Moq;
using Xunit;

namespace Tests
{
  public class Tests
  {
    private readonly Mock<IRepository<Event>> mockEventRepo;
    private readonly Mock<IUnitOfWork> mockUnitOfWork;
    private readonly Mock<IRepository<Guest>> mockGuestRepo;
    private readonly Mock<IRepository<EventGuest>> mockEventGuestRepo;
    public IEventService eventService;

    public Tests()
    {
      mockEventRepo = new Mock<IRepository<Event>>();
      mockUnitOfWork = new Mock<IUnitOfWork>();
      mockGuestRepo = new Mock<IRepository<Guest>>();
      mockEventGuestRepo = new Mock<IRepository<EventGuest>>();

      eventService = new EventService(
        mockEventRepo.Object,
        mockUnitOfWork.Object,
        mockEventGuestRepo.Object,
        mockGuestRepo.Object);
    }

    [Fact]
    public void GetEvents_ReturnsEvents ()
    {
      //Arrange

      //Act
      var outputEvents = eventService.GetEvents();

      //Assert
      Assert.Contains(null, outputEvents);
    }
  }
}

