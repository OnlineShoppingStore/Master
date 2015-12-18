using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingStore.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="User name is requied")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is requied")]
        //[StringLength(50,MinimumLength=6)]
        public string Password { get; set; }
    }
}