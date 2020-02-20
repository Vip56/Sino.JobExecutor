using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sino.JobExecutor.Biz;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sino.JobExecutor.Service
{
    /// <summary>
    /// 执行定时自动注册服务
    /// </summary>
    public class ExecutorRegistryService : BackgroundService
    {
        private IAdminBizFactory _adminBizFactory;
        private ILogger<ExecutorRegistryService> _logger;

        public ExecutorRegistryService(IAdminBizFactory adminBizFactory, ILogger<ExecutorRegistryService> logger)
        {
            _adminBizFactory = adminBizFactory;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
