using Setup.DAL;
using Setup.Request.Admin.common;
using Setup.Request.Admin.product.ToggleProductFeature;
using Setup.Response.Admin.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.product.ToggleProductFeature
{
    public interface IBulkToggleUpdate
    {
        CommonResponse<UpdateBulkToggleResponse> BulkToggle(UpdateBulkToggleRequest objRequest);
    }
}
