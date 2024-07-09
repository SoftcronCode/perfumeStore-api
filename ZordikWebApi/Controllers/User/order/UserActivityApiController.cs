using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.order;
using Setup.ITF.User.wishlist;
using Setup.Request.User.order;
using Setup.Response.User.order;

namespace ZordikWebApi.Controllers.User.order
{
    [Route("api/[action]")]
    [ApiController]
    public class UserActivityApiController : ControllerBase
    {

        private readonly IUserActivity _userActivity;

        public UserActivityApiController(IUserActivity userActivity)
        {
            _userActivity = userActivity;
        }

        [HttpPost]
        public CommonResponse<UserActivityResponse> UserActivityData([FromBody] UserActivityRequest objRequest)
        {
            return _userActivity.UserActivityData(objRequest);
        }
    }
}
