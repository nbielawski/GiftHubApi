using GiftHub.API.Models;
using GiftHub.Contracts;
using GiftHub.Data;
using GiftHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                context.GiftCard.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
