using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    public class Order : OrderDetails
    {
        //public Order()
        //{
        //    Products = new List<Product>();
        //}
        
        [Key]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [Display(Name = "Статус заказу")]
        [Required]
        public string Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        
      }
}
