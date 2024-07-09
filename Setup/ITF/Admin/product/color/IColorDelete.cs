using Setup.DAL;
using Setup.Request.Admin.product.color;
using Setup.Response.Admin.product.color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.product.color
{
    public interface IColorDelete
    {
        CommonResponse<ColorDeleteResponse> DeleteColor(ColorDeleteRequest request);
    }
}
