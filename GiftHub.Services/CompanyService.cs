using System;
using GiftHub.API.Models;
using GiftHub.Data;
using GiftHub.Models;

namespace GiftHub.Services
{
    public class CompanyService
    {
        private readonly Guid _userId;

        public CompanyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCompany(CompanyCreateViewModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    new Company()
                    {
                        CompanyAmount = 0,
                        CompanyName = model.CompanyName
                    };
                context.Company.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
