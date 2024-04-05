using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iben.PEMR.Api.Domain.API
{
    /// <summary>
    /// Api通用响应体。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse
    {
        public string Code { get; set; } = "";
        public string Message { get; set; } = "";
    }
}
