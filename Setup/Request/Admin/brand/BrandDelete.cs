
using System.ComponentModel.DataAnnotations;


namespace Setup.Request.Admin.brand
{
    public class BrandDeleteRequest
    {
        [Required(ErrorMessage = "Brand ID Required")]
        public int ID { get; set; }
    }
    public class BrandDeleteResponse { }

}
