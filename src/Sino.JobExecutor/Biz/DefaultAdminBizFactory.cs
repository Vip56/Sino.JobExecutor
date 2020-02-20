using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sino.JobExecutor.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace Sino.JobExecutor.Biz
{
    /// <summary>
    /// 默认<see cref="IAdminBiz"/>管理工厂
    /// </summary>
    public class DefaultAdminBizFactory : IAdminBizFactory
    {
        private List<IAdminBiz> _adminBizs;

        public DefaultAdminBizFactory(IOptions<ExecutorOptions> options, IHttpClientFactory httpClientFactory, ILoggerFactory factory)
        {
            if (options?.Value == null)
            {
                throw new ArgumentNullException("ExecutorOptions");
            }

            if (options.Value.AdminAddresses == null || options.Value.AdminAddresses.Count <= 0)
            {
                throw new ArgumentNullException("ExecutorOptions.AdminAddresses");
            }

            _adminBizs = new List<IAdminBiz>();

            foreach(var address in options.Value.AdminAddresses)
            {
                _adminBizs.Add(new AdminBizClient(httpClientFactory, factory.CreateLogger<AdminBizClient>(), address, options.Value.AccessToken));
            }
        }

        public IReadOnlyList<IAdminBiz> GetAll()
        {
            return _adminBizs;
        }

        /// <summary>
        /// 获取单个服务，后续将考虑采用引用计数以及服务状态等进行智能的分配。
        /// </summary>
        public IAdminBiz GetService()
        {
            return _adminBizs.First();
        }
    }
}
