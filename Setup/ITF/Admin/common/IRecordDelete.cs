using Setup.DAL;
using Setup.Request.Admin.common;
using Setup.Response.Admin.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.common
{
    public interface IRecordDelete
    {
        CommonResponse<RecordDeleteResponse> DeleteRecord(RecordDeleteRequest request);
    }
}
