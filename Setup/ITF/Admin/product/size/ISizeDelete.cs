using Setup.DAL;
using Setup.Request.Admin.product.size;
using Setup.Response.Admin.product.size;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.product.size
{
    public interface ISizeDelete
    {
        CommonResponse<SizeDeleteResponse> DeleteSize(SizeDeleteRequest request);
    }
}
