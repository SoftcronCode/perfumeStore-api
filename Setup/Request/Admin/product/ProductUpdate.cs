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
    public class ProductUpdateRequest
    {
        [Required(ErrorMessage = "Product Id Required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Category Id Required")]
        public int Cat_Id { get; set; }

        [Required(ErrorMessage = "SubCategory Id Required")]
        public int Sub_Cat_Id { get; set; }

        [Required(ErrorMessage = "Brand Id Required")]
        public int Brand_Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Short Description is required")]
        public string? Short_Description { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Slug is required")]
        public string? Slug { get; set; }

        [Required(ErrorMessage = "Sku Code is required")]
        public string? Sku_Code { get; set; }

        [Required(ErrorMessage = "Hsn Code is required")]
        public string? Hsn_Code { get; set; }

        [Required(ErrorMessage = "GST Value Required")]
        public int Gst { get; set; }

        public int Cod { get; set; }

        [Required(ErrorMessage = "Price Required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "MRP Required")]
        public int Mrp { get; set; }

        [Required(ErrorMessage = "Quantity Required")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Size Id Required")]
        public int SizeId { get; set; }

        [Required(ErrorMessage = "Color Id Required")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "Product Material is required")]
        public string? Product_Material { get; set; }

        [Required(ErrorMessage = "Product Weight is required")]
        public string? Product_Weight { get; set; }

        [Required(ErrorMessage = "Shipping Weight is required")]
        public string? Shipping_Weight { get; set; }

        [Required(ErrorMessage = "Dispatch_Time is required")]
        public string? Dispatch_Time { get; set; }

        [Required(ErrorMessage = "Delivery Time is required")]
        public string? Delivery_Time { get; set; }

        [Required(ErrorMessage = "Packed By is required")]
        public string? Packed_By { get; set; }

        [Required(ErrorMessage = "Manufactured By is required")]
        public string? Manufactured_By { get; set; }

        public string? Video_Link { get; set; }
        
        public IFormFileCollection? Image { get; set; }

        public int Status { get; set; }
        public int Is_Delete { get; set; }
        public int Best_seller { get; set; }
        public int Featured_Products { get; set; }
        public int Discounted_Products { get; set; }
        public int New_Arrival { get; set; }
    }
    #endregion

    #region Response Class
    public class ProductUpdateResponse
    {
    }
    #endregion
}
