using Setup.DAL;
using Setup.Request.Admin.product;
using Setup.Request.Admin.product.variation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.product.variation
{
    public interface IVariationUpdate
    {
        CommonResponse<VariationUpdateResponse> UpdateVariation(VariationUpdateRequest objRequest);
    }
}
