using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter first line address")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter province")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Please enter postal code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter country")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
