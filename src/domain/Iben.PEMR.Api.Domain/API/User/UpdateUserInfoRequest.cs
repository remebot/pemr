using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iben.PEMR.Api.Domain.API.User
{
    /// <summary>
    /// 更新用户信息
    /// </summary>
    public class UpdateUserInfoRequest
    {
        /// <summary>
        /// 用户ID 必填
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 中文姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 英文姓
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public string UpdateAt { get; set; }
    }
}
