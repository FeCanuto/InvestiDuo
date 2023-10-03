using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestiDuo.Models
{
    public interface IAtivoRepository
    {
        void Add(AtivoModel ativoModel);
        void Edit(AtivoModel ativoModel);
        void Delete(int id);
        IEnumerable<AtivoModel> GetAll();
        IEnumerable<AtivoModel> GetByValue(string value);
    }
}
