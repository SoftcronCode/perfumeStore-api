using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product
{
    #region Request Class
    public class AddProductRequest
    {        
        public int Cat_Id { get; set; }
        public int Sub_Cat_Id { get; set; }       

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Slug is required")]
        public string? Slug { get; set; }

        [Required(ErrorMessage = "Short Description is required")]
        public string? Short_Description { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "MRP is required")]
        public int Mrp { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Size ID required")]
        public int SizeId { get; set; }

        [Required(ErrorMessage = "Color ID required")]
        public int ColorId { get; set; }


        [Required(ErrorMessage = "Sku Code is required")]
        public string? Sku_Code { get; set; }

        [Required(ErrorMessage = "Hsn Code is required")]
        public string? Hsn_Code { get; set; }

        [Required(ErrorMessage = "Product Weight is required")]
        public int Product_Weight { get; set; }

        [Required(ErrorMessage = "Shipping Weight is required")]
        public int Shipping_Weight { get; set; }

        [Required(ErrorMessage = "Dispatch_Time is required")]
        public int Dispatch_Time { get; set; }

        [Required(ErrorMessage = "Delivery Time is required")]
        public int Delivery_Time { get; set; }


        public int Brand_Id { get; set; }

        [Required(ErrorMessage = "GST Value is required")]
        public int Gst { get; set; }

        [Required(ErrorMessage = "Packed By is required")]
        public string? Packed_By { get; set; }

        [Required(ErrorMessage = "Manufactured By is required")]
        public string? Manufactured_By { get; set; }

        [Required(ErrorMessage = "Product Material is required")]
        public string? Product_Material { get; set; }

        public int Cod { get; set; }  
        public int Best_seller { get; set; }
        public int Featured_Products { get; set; }
        public int Discounted_Products { get; set; }
        public int New_Arrival { get; set; }
        public int Status { get; set; }

        //[Required(ErrorMessage = "Video Link is required")]
        public string? Video_Link { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public IFormFileCollection? Image { get; set; }
    }
    #endregion

    #region Request Class
    public class AddProductResponse
    {
    }
    #endregion
}
