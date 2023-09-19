using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestiDuo.Views
{
    public interface IAtivoView
    {
        int Id { get; set; }
        string? Name { get; set; }
        string? Ticket { get; set; }
        int Quantity { get; set; }
        decimal Value { get; set; }
        decimal Total { get; set; }
        DateTime Date { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSucessful { get; set; }
        string Message { get; set; }

        //Eventos
        event EventHandler SearchEvent;
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        //Métodos
        void SetAssetListBindingSource(BindingSource assetList);
        void Show();



    }
}
