using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sino.JobExecutor.Biz;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sino.JobExecutor.Service
{
    /// <summary>
    /// 执行自动回调后台服务
    /// </summary>
    public class TriggerCallbackService : BackgroundService
    {
        private IAdminBizFactory _adminBizFactory;
        private ILogger<TriggerCallbackService> _logger;

        public TriggerCallbackService(IAdminBizFactory adminBizFactory, ILogger<TriggerCallbackService> logger)
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
