using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.wishlist
{
    public class DeleteWishlistRequest
    {
        [Required(ErrorMessage = "Wishlist Id Required !")]
        public int WishlistId { get; set; }

        [Required(ErrorMessage = "User Id Required !")]
        public string? UserId { get; set; }
    }

    public class WishlistToCartRequest
    {
        [Required(ErrorMessage = "Wishlist Id Required !")]
        public int WishlistId { get; set; }

        [Required(ErrorMessage = "User Id Required !")]
        public string? UserId { get; set; }
    }
}
