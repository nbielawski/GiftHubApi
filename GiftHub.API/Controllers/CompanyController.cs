using System;
using System.Web.Http;
using GiftHub.Models;
using GiftHub.Services;
using Microsoft.AspNet.Identity;

namespace GiftHub.API.Controllers
{
    public class CompanyController : ApiController
    {
        //  POST /api/Card
        public IHttpActionResult Post(CompanyCreateViewModel company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CompanyService companyService = CreateCompanyService();

            companyService.CreateCompany(company);

            return Ok();
        }

        private CompanyService CreateCompanyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var companyService = new CompanyService(userId);
            return companyService;
        }
    }
}
