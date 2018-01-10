using System;
using System.Collections.Generic;
using System.Linq;
using GiftHub.API.Models;
using GiftHub.Contracts;
using GiftHub.Data;
using GiftHub.Models;

namespace GiftHub.Services
{
    public class GiftCardService : IGiftCardService
    {
        private readonly Guid _userId;

        public GiftCardService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<GiftCardViewModel> GetDonation()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context
                    .GiftCard
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new GiftCardViewModel
                        {
                            Amount = e.Amount
                        }
                    );


                return query.ToArray();
            }


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

        public bool CreateGiftCard(GiftCardCreateViewModel model)
        {
            using (var context = new ApplicationDbContext())
            {
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


        public List<string> CompaniesDropdown()
        {

            using (var context = new ApplicationDbContext())
            {
                

                List<string> list = (from c in context.Company
                                     select c.CompanyName.ToString()).ToList();

                return list;
            }
        }

    }
}
