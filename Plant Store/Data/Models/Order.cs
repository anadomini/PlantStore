using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plant_Store.Data.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "The Surname field is required")]
        public string Surname { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "The Address field is required")]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "The Phone Number field is required")]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The Email field is required")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
