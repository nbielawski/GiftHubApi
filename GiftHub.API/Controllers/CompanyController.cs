using System;
using System.Web.Http;
using GiftHub.Models;
using GiftHub.Services;
using Microsoft.AspNet.Identity;

namespace GiftHub.API.Controllers
{
    public class CompanyController : ApiController
    {
        //  POST /api/Company
        public IHttpActionResult Post(CompanyCreateViewModel company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CompanyService companyService = CreateCompanyService();

            companyService.CreateCompany(company);

            return Ok();
        }

        //  GET /api/Company
        public IHttpActionResult Get()
        {
            CompanyService companyService = CreateCompanyService();

            var companies = companyService.GetCompanies();

            return Ok(companies);
        }

        //  GET /api/Company/{id}
        public IHttpActionResult Get(int id)
        {
            CompanyService companyService = CreateCompanyService();

            var company = companyService.GetCompanyById(id);

            return Ok(company);
        }

        private CompanyService CreateCompanyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var companyService = new CompanyService(userId);
            return companyService;
        }
    }
}
