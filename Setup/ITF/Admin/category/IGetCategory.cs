using Setup.DAL;
using Setup.Request.Admin.category;
using Setup.Response.Admin.category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.category
{
    public interface IGetCategory
    {
        CommonResponse<GetCategoryResponse> FetchCategory(GetCategoryRequest objRequest);
    }
}
