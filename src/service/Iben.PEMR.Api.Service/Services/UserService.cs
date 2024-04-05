using Iben.PEMR.Api.Domain.API;
using Iben.PEMR.Api.Domain.API.User;
using Volo.Abp;

namespace Iben.PEMR.Api.Service
{
    [RemoteService(IsEnabled = true)]
    public class UserService : BaseApplicationService
    {
        /// <summary>
        /// 用户注册。
        /// </summary>
        /// <returns></returns>
        public async Task<RegisterUserResponse> Register(RegisterUserRequest request)
        {
            RegisterUserResponse response = new RegisterUserResponse();

            return response;
        }

        /// <summary>
        /// 更新用户信息。
        /// </summary>
        /// <returns></returns>
        public async Task<UpdateUserInfoResponse> UpdateUserInfo(UpdateUserInfoRequest request)
        {
            UpdateUserInfoResponse response = new UpdateUserInfoResponse();

            return response;
        }

        /// <summary>
        /// 修改用户密码。
        /// </summary>
        /// <returns></returns>
        public async Task<UpdateUserPwdResponse> UpdateUserPwd(UpdateUserPwdRequest request)
        {
            UpdateUserPwdResponse response = new UpdateUserPwdResponse();

            return response;
        }
    }
}
