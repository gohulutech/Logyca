using BusinessRules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEnterpriseRepository
    {
        Task<Enterprise> Get(int id);
        Task<Enterprise> Add(Enterprise enterprise);
        Task<IList<Enterprise>> GetEnterprises();
        Task<Enterprise> GetEnterpriseWithNit(long nit);
        Task<Enterprise> GetEnterprise(int codeId);
        Task<Enterprise> Update(Enterprise enterprise);
    }
}
