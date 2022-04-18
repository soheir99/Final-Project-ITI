﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace USER_API.Authontaction
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name Is Requierd")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Is Requierd")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Requierd")]
        public string Password { get; set; }

        [Required(ErrorMessage = "FisrtName Is Requierd")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Is Requierd")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address Is Requierd")]
        public string Address { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}