using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestiDuo.Models
{
    public interface IAtivoRepository
    {
        void Add();
        void Edit();
        void Delete();
        IEnumerable<AtivoModel> GetAll();
        IEnumerable<AtivoModel> GetByValue();
    }
}
