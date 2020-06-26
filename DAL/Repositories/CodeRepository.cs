using BusinessRules;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CodeRepository : ICodeRepository
    {
        private MyWebApiContext myWebApiContext;

        public CodeRepository(MyWebApiContext myWebApiContext)
        {
            this.myWebApiContext = myWebApiContext;
        }

        public async Task<Code> Add(Code code)
        {
            await myWebApiContext.Codes.AddAsync(code);
            await myWebApiContext.SaveChangesAsync();
            return code;
        }

        public async Task<Code> GetCode(int id)
        {
            return await myWebApiContext.Codes
                .Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<IList<Code>> GetCodes(int ownerId)
        {
            return await myWebApiContext.Codes
                .Where(e => e.ownerId == ownerId).ToListAsync();
        }

        public async Task<Code> Update(Code code)
        {
            myWebApiContext.Codes.Update(code);
            await myWebApiContext.SaveChangesAsync();
            return code;
        }
    }
}
