using System;
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

        private GiftCardService CreateCardService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cardService = new GiftCardService(userId);
            return cardService;
        }

        //public IHttpActionResult GetBalance()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var cardService = new GiftCardService(userId);
        //    var balance = cardService.GetBalance();
        //    return Ok(balance);
        //}
    }
}
