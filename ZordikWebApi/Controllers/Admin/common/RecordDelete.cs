using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.common;
using Setup.Request.Admin.common;
using Setup.Response.Admin.common;

namespace ZordikWebApi.Controllers.Admin.common
{
    [Route("api/[action]")]
    [ApiController]
    public class RecordDelete : ControllerBase
    {
        private readonly IRecordDelete _recordDelete;

        public RecordDelete(IRecordDelete recordDelete)
        {
            _recordDelete = recordDelete;
        }

        [HttpPost]
        public CommonResponse<RecordDeleteResponse> DeleteRecord( [FromBody] RecordDeleteRequest request)
        {
            return _recordDelete.DeleteRecord(request);
        }
    }
}
