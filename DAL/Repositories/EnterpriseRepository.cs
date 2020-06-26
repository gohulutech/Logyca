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
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private MyWebApiContext myWebApiContext;

        public EnterpriseRepository(MyWebApiContext myWebApiContext)
        {
            this.myWebApiContext = myWebApiContext;
        }

        public async Task<Enterprise> Add(Enterprise enterprise)
        {
            await myWebApiContext.Enterprises.AddAsync(enterprise);
            await myWebApiContext.SaveChangesAsync();
            return enterprise;
        }

        public async Task<Enterprise> Get(int id)
        {
            return await myWebApiContext.Enterprises
                .Include(c => c.Codes)
                .Where(e => e.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Enterprise> GetEnterprise(int codeId)
        {
            var code = await myWebApiContext.Codes.Where(c => c.Id == codeId).SingleOrDefaultAsync();
            return await myWebApiContext.Enterprises.Where(e => e.Id == code.ownerId).SingleOrDefaultAsync();
        }

        public async Task<IList<Enterprise>> GetEnterprises()
        {
            return await myWebApiContext.Enterprises
                .Include(c => c.Codes)
                .ToListAsync();
        }

        public async Task<Enterprise> GetEnterpriseWithNit(long nit)
        {
            return await myWebApiContext.Enterprises
                .Include(c => c.Codes)
                .Where(e => e.Nit == nit)
                .SingleOrDefaultAsync();
        }

        public async Task<Enterprise> Update(Enterprise enterprise)
        {
            myWebApiContext.Enterprises.Update(enterprise);
            await myWebApiContext.SaveChangesAsync();
            return enterprise;
        }
    }
}
