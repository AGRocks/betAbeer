﻿using System.ComponentModel.DataAnnotations;

namespace BetABeer.Auth
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool HasValidUsernameAndPassword
        {
            get
            {
                return Password == "password";
            }
        }
    }
}
