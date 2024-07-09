using Setup.DAL;
using Setup.Request.Admin.product;
using Setup.Request.Admin.product.ToggleProductFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.product.ToggleProductFeature
{
    public interface ISingleToggleUpdate
    {
        CommonResponse<UpdateSingleToggleResponse> UpdateSingleToggle(UpdateSingleToggleRequest objRequest);
    }
}
