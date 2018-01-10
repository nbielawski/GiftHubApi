using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using GiftHub.API.Models;
using GiftHub.Contracts;
using GiftHub.Data;
using GiftHub.Models;
using Microsoft.VisualBasic.ApplicationServices;

namespace GiftHub.Services
{
    public class GiftCardService : IGiftCardService
    {
        private readonly Guid _userId;

        public GiftCardService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<GiftCardViewModel> GetCards()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context
                                .GiftCard
                                .Where(e => e.OwnerId == _userId)
                                .Select(
                                    e => new GiftCardViewModel
                                    {
                                        CompanyName = e.Company.CompanyName,
                                        Amount = e.Amount,
                                        DonationUtc = e.DonationUtc
                                    }
                                );

                return query.ToArray();
            }
        }
        
        //public ApplicationUser GetBalance()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx.Users.Single(e => e.Email == email);

        //        return
        //            new ApplicationUser
        //            {
        //                TotalDonation = entity.TotalDonation
        //            };
        //    }
        //}
        //separate service method grabbin all the specific users donations, adding them, then displaying to user.
        //giftcard table, and account donation column

        public bool CreateGiftCard(GiftCardCreateViewModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                //var appuser = context
                //    .Users
                //    .Where(e => e.Id == Guid.Parse(_userId))
                //    .FirstOrDefault();

                //appuser.TotalDonation += model.Amount;

                //context.Users.Add(appuser);

                var company = context
                                .Company
                                .Where(e => e.CompanyName == model.CompanyName)
                                .FirstOrDefault();

                var companyId = company.CompanyId;

                var entity =
                            new GiftCard()
                            {
                                OwnerId = _userId,
                                Amount = model.Amount,
                                CardNumber = model.CardNumber,
                                DonationUtc = DateTime.Now,
                                CompanyId = companyId,

                                //  Optional 
                                ExpirationDate = model.ExpirationDate,
                                AccessNumber = model.AccessNumber
                            };

                company.CompanyAmount = company.CompanyAmount + entity.Amount;

                context.GiftCard.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

    }
}
