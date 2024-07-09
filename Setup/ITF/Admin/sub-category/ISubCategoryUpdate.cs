using Setup.DAL;
using Setup.Request.Admin.sub_category;
using Setup.Response.Admin.sub_category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.sub_category
{
    public interface ISubCategoryUpdate
    {
        CommonResponse<SubCategoryUpdateResponse> UpdateSubCategory(SubCategoryUpdateRequest request);
    }
}
