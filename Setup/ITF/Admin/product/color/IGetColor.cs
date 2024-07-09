using Setup.DAL;
using Setup.RequestL.Admin.product.color;
using Setup.Response.Admin.product.color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.product.color
{
    public interface IGetColor
    {
        CommonResponse<GetColorResponse> FetchColor (GetColorRequest request);
    }
}
