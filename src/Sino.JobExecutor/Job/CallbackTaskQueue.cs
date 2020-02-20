using Microsoft.Extensions.Logging;
using Sino.JobExecutor.Biz;
using Sino.JobExecutor.Biz.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sino.JobExecutor.Job
{
    /// <summary>
    /// 负责异步执行回调
    /// </summary>
    public class CallbackTaskQueue
    {
        private readonly ILogger<CallbackTaskQueue> _logger;

        private readonly IAdminBizFactory _adminBizFactory;
        private readonly IJobLogger _jobLogger;
        private readonly ConcurrentQueue<HandleCallbackParam> taskQueue = new ConcurrentQueue<HandleCallbackParam>();

        private bool _stop;
        private bool _isRunning;
        private int _callbackInterval;
        private Task _runTask;

        public CallbackTaskQueue(IAdminBizFactory adminBizFactory, IJobLogger jobLogger, int callbackInterval)
        {

        }
    }
}
