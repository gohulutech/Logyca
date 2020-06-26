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
    public class CodeController : ControllerBase
    {
        private ICodeRepository codeRepository;

        public CodeController(ICodeRepository codeRepository)
        {
            this.codeRepository = codeRepository;
        }
        
        [HttpGet("id")]
        public async Task<Code> Get(int id)
        {
            return await this.codeRepository.GetCode(id);
        }

        [HttpPost]
        public async Task<Code> Post([FromBody] Code code)
        {
            return await this.codeRepository.Add(code);
        }

        [HttpPatch("id")]
        public async Task<Code> Patch(int id, [FromBody] JsonPatchDocument<Code> patchDocument)
        {
            var code = await this.codeRepository.GetCode(id);
            patchDocument.ApplyTo(code, ModelState);
            return await codeRepository.Update(code);
        }

        [HttpGet("ownerId")]
        public async Task<IList<Code>> GetCodes(int ownerId)
        {
            return await codeRepository.GetCodes(ownerId);
        }
    }
}
