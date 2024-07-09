using Setup.DAL;
using Setup.Request.Admin.blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.blog
{
    public interface IBlogUpdate
    {
        CommonResponse<BlogUpdateResponse> UpdateBlog(BlogUpdateRequest objRequest);
    }
}
