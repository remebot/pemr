using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iben.PEMR.Api.Domain.API.User
{
    /// <summary>
    /// 修改用户密码
    /// </summary>
    public class UpdateUserPwdRequest
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 当前密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword { get; set; }
    }
}
