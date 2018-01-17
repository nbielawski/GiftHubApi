using System;
using System.Linq;
using System.Web.Http;
using GiftHub.Models;
using GiftHub.Services;
using Microsoft.AspNet.Identity;

namespace GiftHub.API.Controllers
{
    public class CardController : ApiController
    {
        //  GET api/Card
        public IHttpActionResult Get()
        {
            GiftCardService cardService = CreateCardService();

            var cards = cardService.GetCards();

            return Ok(cards);
        }

        //  POST /api/Card
        public IHttpActionResult Post(GiftCardCreateViewModel card)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GiftCardService cardService = CreateCardService();

            cardService.CreateGiftCard(card);

            return Ok();
        }

        [HttpGet]
        [Route("api/CompanyNames")]
        public IHttpActionResult GetCompaniesDropdown()
        {
            GiftCardService svc = CreateCardService();
            var list = svc.CompaniesDropdown();
            return Ok(list);

            
        }

        private GiftCardService CreateCardService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cardService = new GiftCardService(userId);
            return cardService;
        }

        [HttpGet]
        [Route("API/TotalDonations")]
        public decimal TotalDonation()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cardService = new GiftCardService(userId);
            var total = cardService.GetDonation().Sum(e => e.Amount);
            return total;
        }
 
    }
}
