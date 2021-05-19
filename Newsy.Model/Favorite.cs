using System.Collections.Generic;

namespace Newsy.Model
{
    public class Favorite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string NewsUrl { get; set; }

        //Navigation
        public List<UserFavorite> UserFavorites { get; set; }
    }
}
