using GiftHub.Models;
using GiftHub.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
    }
}
