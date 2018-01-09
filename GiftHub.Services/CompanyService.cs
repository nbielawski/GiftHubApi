using System;
using System.Collections.Generic;
using System.Linq;
using GiftHub.API.Models;
using GiftHub.Contracts;
using GiftHub.Data;
using GiftHub.Models;

namespace GiftHub.Services
{
    public class CompanyService : ICompanyService
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

        public CompanyDetailViewModel GetCompanyById(int companyId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Company
                        .Single(e => e.CompanyId == companyId);

                return
                    new CompanyDetailViewModel
                    {
                        CompanyName = entity.CompanyName,
                        CompanyAmount = entity.CompanyAmount
                    };
            }
        }

        public IEnumerable<CompanyDetailViewModel> GetCompanies()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context
                                .Company
                                .Select(
                                    e =>
                                    new CompanyDetailViewModel
                                    {
                                        CompanyName = e.CompanyName,
                                        CompanyAmount = e.CompanyAmount
                                    }
                                );

                return query.ToArray();
            }
        }
    }
}
