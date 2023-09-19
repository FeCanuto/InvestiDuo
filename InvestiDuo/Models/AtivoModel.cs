using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestiDuo.Models
{
    public class AtivoModel
    {
        private int id;
        private string? name;
        private string? ticket;
        private int quantity;
        private decimal value;
        private decimal total;
        private DateTime date;

        public int Id { get => id; set => id = value; }

        [StringLength(50)]
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Name of asset is required.")]
        public string? Name { get => name; set => name = value; }

        [DisplayName("Ticket")]
        [RegularExpression(@"^[A - Z]{4}\d{1,2}$")]
        [Required(ErrorMessage = "Ticket of asset is required.")]
        public string? Ticket { get => ticket; set => ticket = value; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "Quantity of asset is required.")]
        public int Quantity { get => quantity; set => quantity = value; }

        [DisplayName("Valor")]
        [Required(ErrorMessage = "Value of asset is required.")]
        public decimal Value { get => value; set => this.value = value; }

        [DisplayName("Total")]
        [Required(ErrorMessage = "Total of asset is required.")]
        public decimal Total { get => total; set => total = value; }

        [DisplayName("Data")]
        [Required(ErrorMessage = "Date of asset is required.")]
        public DateTime Date { get => date; set => date = value; }
    }
}
