using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iben.PEMR.Api.Domain.API.User
{
    /// <summary>
    /// 用户注册接口
    /// </summary>
    public class RegisterUserResponse : BaseResponse
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string? UserId { get; set; }
    }
}
