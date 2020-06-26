using BusinessRules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICodeRepository
    {
        Task<Code> GetCode(int id);
        Task<IList<Code>> GetCodes(int ownerId);
        Task<Code> Add(Code code);
        Task<Code> Update(Code code);
    }
}
