using AspNetCore.Honeypot;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WeddingRSVP.Data;
using WeddingRSVP.Models;

namespace WeddingRSVP.Controllers
{
    public class HomeController(Services.MailingService mailingService, MongoDbService mongoDbService) : Controller
    {
        private readonly Services.MailingService _mailingService = mailingService;
        private readonly IMongoCollection<GuestRsvp> _guests = mongoDbService.Database.GetCollection<GuestRsvp>("rsvp");

        public IActionResult Index() => View();

        [Honeypot]
        public IActionResult GuestRsvp(GuestRsvp model)
        {
            // Assign Unique Id
            model.Id = Guid.NewGuid();

            // Add to Db Table
            _guests.InsertOne(model);

            // Send Email With Guest Info
            _mailingService.SendEmail(model);

            // Redirect User To Say Thank You Depending On Their Answer
            return model.IsAttending ? RedirectToAction("Attending") : RedirectToAction("NotAttending");
        }

        public IActionResult Attending() => View();

        public IActionResult NotAttending() => View();
    }
}
