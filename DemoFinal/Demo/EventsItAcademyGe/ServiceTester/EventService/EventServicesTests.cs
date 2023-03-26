using EventsItAcademyGe.Application.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Moq;
using EventsItAcademyGe.Infrastructure.Repositories;
using EventsItAcademyGe.Application.Services.Models;
using EventsItAcademyGe.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceTester
{
    public class EventServicesTests
    {
        private readonly EventService _eventService;
        public EventServicesTests()
        {
            WebApplicationFactory<Program> factory = new WebApplicationFactory<Program>();
            IServiceProvider ScopedServiceProvider = factory.Services.CreateScope().ServiceProvider;
            _eventService = (EventService)ScopedServiceProvider.GetRequiredService<IEventService>();

            //Mocking Event Repository
            FieldInfo _eventRepoFieldInfo = typeof(EventService).GetField("_eventRepo",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Mock<EventsRepository> MockedRepo = new Mock<EventsRepository>();
            
            
            //Mocking instructions
            MockedRepo.Setup(x => x.AddAsync(It.IsAny<Action<Event>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(123));


            //Setting Mocked object to _eventService
            _eventRepoFieldInfo.SetValue(_eventService, MockedRepo.Object);
        }


        [Theory]
        [InlineData(123)]
        public async Task Tests(int res)
        {
            EventRequestModel e = new EventRequestModel();
            CancellationToken token = CancellationToken.None;
            Assert.Equal(res, await _eventService.AddNewEvent(e, token));
        }


    }
}