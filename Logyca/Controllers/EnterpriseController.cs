using BusinessRules;
using DAL.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logyca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnterpriseController : ControllerBase
    {
        private IEnterpriseRepository enterpriseRepository;

        public EnterpriseController(IEnterpriseRepository enterpriseRepository)
        {
            this.enterpriseRepository = enterpriseRepository;
        }

        [HttpGet("id")]
        public async Task<Enterprise> Get([FromQuery] int id)
        {
            return await enterpriseRepository.Get(id);
        }

        [HttpPost]
        public async Task<Enterprise> Post([FromBody] Enterprise enterprise)
        {
            return await enterpriseRepository.Add(enterprise);
        }

        [HttpPatch("id")]
        public async Task<Enterprise> Patch(int id, [FromBody] JsonPatchDocument<Enterprise> patchDocument)
        {
            var enterprise = await enterpriseRepository.Get(id);
            patchDocument.ApplyTo(enterprise, ModelState);
            return await enterpriseRepository.Update(enterprise);
        }

        [HttpGet]
        public async Task<IList<Enterprise>> GetEnterprises()
        {
            return await enterpriseRepository.GetEnterprises();
        }

        [HttpGet("GetEnterpriseWithNit")]
        public async Task<Enterprise> GetEnterpriseWithNit(long nit)
        {
            return await enterpriseRepository.GetEnterpriseWithNit(nit);
        }

        [HttpGet("GetEnterprise")]
        public async Task<Enterprise> GetEnterprise(int codeId)
        {
            return await enterpriseRepository.GetEnterprise(codeId);
        }
    }
}
