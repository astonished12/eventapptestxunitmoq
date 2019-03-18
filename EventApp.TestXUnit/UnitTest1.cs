using EventApp.Data.Entities;
using EventApp.Data.Infrastructure;
using EventApp.Services.EventService;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace EventApp.TestXUnit
{

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
      public void GetEvents_ReturnsEvents()
      {
        //Arrange
        mockEventRepo.Setup(er => er.GetAll())
                     .Returns(new List<Event> {
                         new Event()
                          { Description = "O manea",
                             StartTime = DateTime.Now,
                              EndTime = DateTime.Now.AddDays(2),
                             EstimatedBudget = 5,
                            Name = "Salamu de bucegi",
                          },
                       new Event()
                          { Description = "O manea 1",
                            StartTime = DateTime.Now,
                            EndTime = DateTime.Now.AddDays(2),
                            EstimatedBudget = 5,
                            Name = "Salamu de bucegi 1",
                          }
                     });

        //Act
        var outputEvents = eventService.GetEvents();
        var fmm = outputEvents.Count;

        //Assert
        Assert.Equal(2, fmm);
        mockEventRepo.Verify(x => x.GetAll(), Times.Exactly(1));
      }

      // method_return_casses
      [Theory]
      [InlineData(1, 10)]
      [InlineData(2, 5)]
      [InlineData(null, 5)]
      [InlineData(0, 5)]

      public void GetEventById_ReturnEvent_MultipleCasses(int? Id, decimal expectedResult)
      {
        //Arrange
        mockEventRepo.Setup(er => er.GetById(1))
                     .Returns(new Event()
                     {
                       Description = "O manea",
                       StartTime = DateTime.Now,
                       EndTime = DateTime.Now.AddDays(2),
                       EstimatedBudget = 10,
                       Name = "Salamu de bucegi",

                     });

        mockEventRepo.Setup(er => er.GetById(2))
                     .Returns(
                         new Event()
                         {
                           Description = "O manea 1",
                           StartTime = DateTime.Now,
                           EndTime = DateTime.Now.AddDays(2),
                           EstimatedBudget = 5,
                           Name = "Salamu de bucegi 1"
                         });

        //Act
        var evnt = eventService.GetEventById(Id);

        //Assert
        evnt.EstimatedBudget.Equals(expectedResult);
      }
    }

  }


}
