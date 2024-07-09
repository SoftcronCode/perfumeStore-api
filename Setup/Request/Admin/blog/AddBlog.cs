using Microsoft.AspNetCore.Http;
using Setup.BL.User.productFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.blog
{
    #region Request Class
    public class AddBlogRequest
    {
        [Required(ErrorMessage = "Blog Category Id is Required. ")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is Required.")]
        public string? CategoryName { get; set; }

        [Required(ErrorMessage = "Blog Category Id is Required. ")]
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is Required.")]
        public string? SubCategoryName { get; set; }

        public int BlogTagId { get; set; }        

        [Required(ErrorMessage = "{Blog Title is Required.")]
        public string? BlogTitle { get; set; }

        [Required(ErrorMessage = "{Blog Description is Required.")]
        public string? BlogDescription { get; set; }

        [Required(ErrorMessage = "{Blog Friendly Url is Required.")]
        public string? BlogFriendlyUrl { get; set; }

        [Required(ErrorMessage = "{Tag Name is Required.")]
        public string? TagName { get; set; }

        [Required(ErrorMessage = "{Page Title is Required.")]
        public string? PageTitle { get; set; }

        [Required(ErrorMessage = "{Meta Key is Required.")]
        public string? MetaKey { get; set; }

        [Required(ErrorMessage = "{Meta Description is Required.")]
        public string? MetaDescription { get; set; }

        [Required(ErrorMessage = "{Blog Image is Required.")]
        public IFormFile? Image { get; set; }

        public string? VideoLink { get; set; }

        public int? Status { get; set; }
    }
    #endregion

    #region Response Class
    public class AddBlogResponse
    {
    }
    #endregion
}
