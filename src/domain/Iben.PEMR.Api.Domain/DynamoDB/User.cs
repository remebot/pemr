using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iben.PEMR.Api.Domain.DynamoDB
{
    public class User
    {
        /// <summary>
        /// 账户ID
        /// </summary>
        public string? UserID { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// 中文姓名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 英文姓
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string? Mobile { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string? Email { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateAt { get; set; }
    }
}
