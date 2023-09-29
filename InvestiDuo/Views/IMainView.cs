using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestiDuo.Views
{
    public interface IMainView
    {
        event EventHandler ShowAtivoView;
        event EventHandler ShowOwnerView;
        event EventHandler ShowChartView;
    }
}
