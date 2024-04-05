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
    public class RegisterUserRequest
    {
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
