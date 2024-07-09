using System.ComponentModel.DataAnnotations;


namespace Setup.Request.Admin.contact
{
    #region Request Class
    public class ContactDeleteRequest
    {
        [Required(ErrorMessage = "Contact ID Required")]
        public int ID { get; set; }
    }
    #endregion

    #region Response Class
    public class ContactDeleteResponse
    {
    }
    #endregion
}
