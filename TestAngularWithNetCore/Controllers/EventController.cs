using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Services.EventService;
using EventApp.Services.GuestService;
using EventApp.Services.ImageStorageService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using TestAngularWithNetCore.Models;

namespace TestAngularWithNetCore.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private IEventService eventService;
        private IGuestService guestService;
        private IImageStorageService imageStorageService;

        public EventController(IEventService eventService, IGuestService guestService, IImageStorageService imageStorageService)
        {
            this.eventService = eventService;
            this.guestService = guestService;
            this.imageStorageService = imageStorageService;
        }

        [HttpGet("[action]")]
        public IEnumerable<EventModel> Index()
        {
            var eventModels = eventService.GetEvents().Select(x => new EventModel().InjectFrom(x) as EventModel);
            return eventModels;
        }
    }
}