using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    public class Order : OrderDetails
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [Display(Name = "Статус заказу")]
        [Required]
        public string Status { get; set; }
        
    }
}
