using Setup.DAL;
using Setup.Request.Admin.blog;
using Setup.Request.Admin.company_detail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.blog
{
    public interface IGetBlog
    {
        CommonResponse<GetBlogResponse> FetchBlog (GetBlogRequest objRequest);
    }
}
