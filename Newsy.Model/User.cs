using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Newsy.Model
{

    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        //Navigation
        public List<UserFavorite> UserFavorites { get; set; }
    }
}
