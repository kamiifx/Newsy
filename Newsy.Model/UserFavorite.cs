using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Newsy.Model
{
    [Table("UserFavorite")]

    public class UserFavorite
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int FavoriteId { get; set; }
        public Favorite Favorite { get; set; }
    }
}
